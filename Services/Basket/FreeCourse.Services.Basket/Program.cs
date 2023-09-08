using FreeCourse.Services.Basket.Services;
using FreeCourse.Services.Basket.Settings;
using FreeCourse.Shared.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

builder.Services.AddSingleton<RedisService>(serviceProvider =>
{
    var redisSettings = serviceProvider.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisSettings.Host, redisSettings.Port);

    redis.Connect();

    return redis;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
builder.Services.AddScoped<IBasketService, BasketService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
