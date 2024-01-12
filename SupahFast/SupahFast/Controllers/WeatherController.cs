using Microsoft.AspNetCore.Mvc;
using SupahFast.Application;

namespace SupahFast.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [Route("{city}")]
    [HttpGet]
    public IActionResult GetWeatherData(string city)    
    {
        try
        {
            var result = _weatherService.GetWeatherData(city);
            return new OkObjectResult(result);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}