using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();

builder.Services.AddAuthentication()
    .AddJwtBearer("GatewayAuthenticationScheme", options =>
    {
        options.Authority = builder.Configuration["IdentityServerURL"];
        options.Audience = "resource_gateway";
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddOcelot();


var app = builder.Build();

await app.UseOcelot();

app.Run();
