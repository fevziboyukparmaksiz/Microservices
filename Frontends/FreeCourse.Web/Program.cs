using FreeCourse.Shared.Service;
using FreeCourse.Web.Handler;
using FreeCourse.Web.Models;
using FreeCourse.Web.Services.Interfaces;
using FreeCourse.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

var serviceApiSettings = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddHttpClient<IUserService, UserService>(options =>
{
    options.BaseAddress = new Uri(serviceApiSettings.IdentityBaseUri);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICatalogService, CatalogService>(options =>
{
    options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Catalog.Path}");
});

builder.Services.AddAuthentication().AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Auth/SignIn";
    options.ExpireTimeSpan = TimeSpan.FromDays(60);
    options.SlidingExpiration = true;
    options.Cookie.Name = "webcookie";
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
