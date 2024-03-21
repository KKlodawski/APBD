using Microsoft.AspNetCore.Mvc;

namespace Zadanie3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var list = new List<WeatherForecast>();
            foreach (var item in Summaries)
            {
                list.Add(new WeatherForecast { Date = new DateOnly(2015, 12, 31), Summary = item, TemperatureC = -1 });
            }
            return list;
        }
    }
}