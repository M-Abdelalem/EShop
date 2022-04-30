using Basket.API.IRedisRepository;
using Basket.API.IServices;
using Basket.API.RedisRepository;
using Basket.API.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = $"{ builder.Configuration.GetValue<string>("Redis:Server")}:{ builder.Configuration.GetValue<int>("Redis:Port")}"; });

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICacheRepository, CacheRepository>();
builder.Services.AddScoped<IShopingCartService, ShopingCartService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
