using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
#if (IndividualLocalAuth)
using Microsoft.AspNetCore.Authorization;
#endif
using Microsoft.Extensions.Logging;

namespace Company.WebApplication1.Controllers
{
    #if (IndividualLocalAuth)
    [Authorize]
    #endif
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly ILogger<SampleDataController> logger;

        public SampleDataController(ILogger<SampleDataController> _logger)
        {
            logger = _logger;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
