using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _environment;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                string dataPath = Path.Combine(_environment.ContentRootPath, "Data", "weatherData.json");
                if (System.IO.File.Exists(dataPath))
                {
                    string jsonData = System.IO.File.ReadAllText(dataPath);
                    var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonData);
                    
                    if (forecasts != null)
                    {
                        _logger.LogInformation("Successfully retrieved {count} weather forecasts", forecasts.Count);
                        return forecasts;
                    }
                }
                
                _logger.LogWarning("Weather data file not found or empty. Returning default data.");
                
                // Return default data if file doesn't exist or is empty
                return GetDefaultForecasts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving weather forecast data");
                return GetDefaultForecasts();
            }
        }

        private static IEnumerable<WeatherForecast> GetDefaultForecasts()
        {
            string[] summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            string[] windDirections = new[]
            {
                "N", "NE", "E", "SE", "S", "SW", "W", "NW"
            };

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)],
                Humidity = Random.Shared.Next(0, 100),
                WindDirection = windDirections[Random.Shared.Next(windDirections.Length)],
                WindSpeed = Math.Round(Random.Shared.NextDouble() * 30, 1)
            })
            .ToArray();
        }
    }
}