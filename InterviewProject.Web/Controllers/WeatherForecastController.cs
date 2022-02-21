using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interviewproject.api.application.DTO;
using interviewproject.api.application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewProject.Controllers
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
        private readonly IWeatherAppService _weatherAppService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherAppService weatherAppService)
        {
            _logger = logger;
            _weatherAppService = weatherAppService;
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

        [HttpGet]
        [Route("GetLocationSearch")]
        public async Task<IEnumerable<LocationSearchResponseDTO>> GetLocationSearch(string query)
        {
            return await _weatherAppService.LocationSearch(query);
        }

        [HttpGet]
        [Route("GetSearch")]
        public async Task<SearchResponseDTO> GetSearch(string woeid)
        {
            return await _weatherAppService.Search(woeid);
        }
    }
}
