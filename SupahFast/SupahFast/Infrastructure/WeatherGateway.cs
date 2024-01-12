using Newtonsoft.Json;
using SupahFast.Common;

namespace SupahFast.Infrastructure;

public class WeatherGateway : IWeatherGateway
{
    private readonly HttpClient _httpClient;
    private readonly OpenWeatherMapSettings _openWeatherMapSettings;


    public WeatherGateway(HttpClient httpClient, OpenWeatherMapSettings openWeatherMapSettings)
    {
        _openWeatherMapSettings = openWeatherMapSettings;
        _httpClient = httpClient;
    }

    public WeatherResponse GetWeatherData(string city)
    {
        city = city.ToLower();
        var url =
            $"{_openWeatherMapSettings.BaseUrl}?q={city}&appid={_openWeatherMapSettings.ApiKey}&units=metric";

        var response = _httpClient.GetAsync(url).Result;
        
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Could not find weather information");
        }
        var jsonString = response.Content.ReadAsStringAsync().Result;
        var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(jsonString);

        return weatherData;
    }
}