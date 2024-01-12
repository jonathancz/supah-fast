using Newtonsoft.Json;
using OpenWeatherMap.Models;
using SupahFast.Common;
using Xunit;

namespace SupahFast.Infrastructure;

public class WeatherGateway_IntegrationTests
{
    private readonly WeatherGateway _weatherGateway = new(new HttpClient(), new OpenWeatherMapSettings()
    {
        BaseUrl = "https://api.openweathermap.org/data/2.5/weather",
        ApiKey = "95a3ec4e5404cb3565f1b9206d79d9be"
    });

    [Fact]
    public async Task CanMakeApiCall()
    {
        var result = _weatherGateway.GetWeatherData("london");
        
        Assert.NotNull(result);
    }


    [Fact]
    public async Task CanGetWeatherData()
    {
        // var weatherInfo = await _openWeatherMapService.GetCurrentWeatherAsync(latitude: 47.1823761d, longitude: 8.4611036d);

        // Assert.NotNull(weatherInfo);
    }
}