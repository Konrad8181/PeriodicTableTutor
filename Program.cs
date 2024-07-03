using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using PeriodicTableTutor.Data;
using PeriodicTableTutor.Interfaces;
using PeriodicTableTutor.Models.Entities;
using PeriodicTableTutor.Providers;
using PeriodicTableTutor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

// Set localization resources file path
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Define supported languages codes
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("pl-PL"),
    };

    options.SupportedUICultures = supportedCultures;
});

// Dependency injection - DI
builder.Services.AddSingleton<ElementModel>();
builder.Services.AddSingleton<IElementsProvider, ElementsProvider>();
builder.Services.AddSingleton<IPeriodicTableDataProvider, PeriodicTableDataProvider>();
builder.Services.AddDbContext<ElementModelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ElementsDatabase")));
builder.Services.AddScoped<ElementsController>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
