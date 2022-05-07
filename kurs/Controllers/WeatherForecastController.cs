using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kurs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public IEnumerable<WeatherForecast> Get(int min, int max, int maxResults)
        {
            var rng = new Random();
            return Enumerable.Range(1, maxResults).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(min, max),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();
        }

        [HttpPost("generate/{maxResults}")]
        public ActionResult<WeatherForecast> Post([FromBody] Config config, [FromRoute] int maxResults)
        {
            if(config.Max < config.Min)
            {
                return BadRequest($"Invalid data. Max ({config.Max}) can't be smaller than min ({config.Min})");
            }

            HttpContext.Response.StatusCode = 200;

            return Ok(Get(config.Min, config.Max, maxResults));
        }
    }
}
