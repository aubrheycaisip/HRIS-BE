using HRIS_BE.Helpers.Interfaces;
using HRIS_BE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRIS_BE.Controllers
{
    [ApiController]
    [Route("Weather")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository<DemoTable, long> repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<DemoTable, long> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet("WeatherForecast")]
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

        [HttpGet("SampleDemoTable")]
        public IEnumerable<DemoTable> GetSampleDemoTable()
        {
            return repository.GetAll();
        }
    }
}