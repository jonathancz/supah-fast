using SupahFast.Infrastructure;

namespace SupahFast.Application;

public class WeatherService : IWeatherService
{
    private readonly IWeatherGateway _weatherGateway;

    public WeatherService(IWeatherGateway weatherGateway)
    {
        _weatherGateway = weatherGateway;
    }

    public WeatherResponse GetWeatherData(string city)
    {
        return _weatherGateway.GetWeatherData(city);
    }
}