using SupahFast.Common;

namespace SupahFast.Infrastructure;

public interface IWeatherGateway
{
    WeatherResponse GetWeatherData(string city);
}