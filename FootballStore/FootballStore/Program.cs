using FootballStore.Configuration;
using FootballStore.Core.Interfaces;
using FootballStore.Core.Interfaces.Services;
using FootballStore.Core.Models;
using FootballStore.Infrastructure;
using FootballStore.Infrastructure.Data;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
FootballStore.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Dependencies
builder.Services.AddScoped(typeof(IRepository<CatalogItem>), typeof(EfRepository<CatalogItem>));
builder.Services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();

builder.Services.AddCoreServices();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Logger.LogDebug("Starting the app");
app.Run();
