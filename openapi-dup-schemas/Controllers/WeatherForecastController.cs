using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<WeatherForecast> Create([FromBody] WeatherForecast weatherForecast)
    {
        return weatherForecast;
    }
}
