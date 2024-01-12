using SupahFast.Application;
using SupahFast.Common;
using SupahFast.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure OpenWeatherMapSettings
var openWeatherMapSettings = builder.Configuration.GetSection("OpenWeatherMap").Get<OpenWeatherMapSettings>();
builder.Services.AddSingleton(openWeatherMapSettings);

// Configure HttpClient via IHttpClientFactory
builder.Services.AddHttpClient();

// Register your services
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherGateway, WeatherGateway>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/weather/{city}", async (string city, IWeatherService weatherService) =>
{
    try
    {
        var result = weatherService.GetWeatherData(city);
        return Results.Ok(result);
    }
    catch (Exception e)
    {
        return Results.Problem(e.Message);
    }
});

app.Run();