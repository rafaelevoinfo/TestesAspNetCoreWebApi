using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebApi.Controllers
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
        private ContextId _contextId;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ContextId contextId)
        {
            _logger = logger;
            _contextId = contextId;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


    [HttpPost]
        public ActionResult<string> Post([FromBody] JsonDocument ipJson)
        {
            ipJson.RootElement.TryGetProperty("ipValue", out JsonElement ip);
            ipJson.RootElement.TryGetProperty("ipOpt", out JsonElement opt);
            
            var id = _contextId.Id.ToString();
            if (opt.ValueKind != JsonValueKind.Undefined){
                id = opt.GetString();
            }
             
            Console.WriteLine($"{ip.GetString()} - {id}");
            return Ok("teste");
        }
    }


}
