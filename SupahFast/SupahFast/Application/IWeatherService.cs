using SupahFast.Common;
using SupahFast.Infrastructure;

namespace SupahFast.Application;

public interface IWeatherService
{
    WeatherResponse GetWeatherData(string city);
}