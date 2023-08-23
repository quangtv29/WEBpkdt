using LoggerService;
using Microsoft.AspNetCore.Mvc;
using NLog.Fluent;

namespace API.Controllers
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
        private readonly ILoggerManager _loggerManager;
    

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = loggerManager;
    }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }
        [HttpGet("hihi")]

        public async Task<IActionResult> Test ()
        {
            _loggerManager.LogError("Lỗi rồi");
            _loggerManager.LogDebug("meo");
            return Ok();
        }
    }
}