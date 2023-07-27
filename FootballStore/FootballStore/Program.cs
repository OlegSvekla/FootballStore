using FootballStore.Configuration;
using FootballStore.Core;
using FootballStore.Core.Interfaces;
using FootballStore.Core.Interfaces.Services;
using FootballStore.Core.Servicess;
using FootballStore.Infrastructure.Data;
using FootballStore.Infrastructure.Identity;
using FootballStore.Interfaces;
using FootballStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
FootballStore.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

//TODO SET the ASP.Net Identity Integration
//Configure Identity
builder.Services
	.AddIdentity<ApplicationUser, IdentityRole>()
	.AddDefaultUI()
	.AddEntityFrameworkStores<AppIdentityDbContext>()
	.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


//IoC
builder.Services.AddCoreServices();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
builder.Services.AddSingleton<IUriComposer>(new UriComposer(builder.Configuration.Get<CatalogSettings>()));
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketViewModelService, BasketViewModelService>();

var app = builder.Build();
app.Logger.LogInformation("App Created");
app.Logger.LogInformation("Database migration running...");

using(var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
	try
	{
		var catalogContext = scopedProvider.GetRequiredService<CatalogContext>();
		if (catalogContext.Database.IsSqlServer())
		{
			catalogContext.Database.Migrate();
		}
		await CatalogContextSeed.SeedAsync(catalogContext, app.Logger);

		var identityContext = scopedProvider.GetRequiredService<AppIdentityDbContext>();
		if (identityContext.Database.IsSqlServer())
		{
			identityContext.Database.Migrate();
		}
	}
	catch (Exception ex)
	{
		app.Logger.LogError(ex, "An error occured addition migrations to Database");
	}
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Logger.LogDebug("Starting the app");
app.Run();
