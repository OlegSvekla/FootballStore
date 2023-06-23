using FootballStore.Configuration;
using FootballStore.Core.Interfaces;
using FootballStore.Core.Interfaces.Services;
using FootballStore.Core.Models;
using FootballStore.Infrastructure;
using Microsoft.Build.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Dependencies
builder.Services.AddScoped(typeof(IRepository<CatalogItem>), typeof(LocalCatalogItemRepository));
builder.Services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();

builder.Services.AddCoreServices();

var app = builder.Build();

app.Logger.LogInformation("App Created");
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
