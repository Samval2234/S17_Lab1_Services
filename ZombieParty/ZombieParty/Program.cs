using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.Services;

var builder = WebApplication.CreateBuilder(args);
#region Langues supportées
CultureInfo[] supportedCultures = new[]
  {
                new CultureInfo("en-US"),
                new CultureInfo("fr-CA")
 };
#endregion


// Add services to the container.
// Injecter la localisation ICI
#region Localizer configuration
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion

builder.Services.AddDbContext<ZombiePartyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBaseAsync<>));
builder.Services.AddScoped<IZombieTypeService, ZombieTypeService>();
var app = builder.Build();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
