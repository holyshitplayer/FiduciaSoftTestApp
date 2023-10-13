using FiduciaSoftTestApp.Models;
using FiduciaSoftTestApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace FiduciaSoftTestApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly WeatherForecastService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastService> logger, WeatherForecastService weatherService)
        {
            this._logger = logger;
            this._weatherService = weatherService;
        }

        public IActionResult Index()
        {
            string? lastCity = this.HttpContext.Session.GetString("LastCity");
            if (!string.IsNullOrWhiteSpace(lastCity))
            {
                this.TempData["LastCity"] = lastCity;
            }
            
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLastWeather()
        {
            return await this.GetWeather(this.HttpContext.Session.GetString("LastCity") ?? string.Empty);
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string city)
        {
            this._logger.LogInformation($"Receiving a weather forecast by request \"{city}\"");

            try
            {
                var weatherForecast = await this._weatherService.GetWeatherForecastAsync(city);

                if (weatherForecast != null)
                {
                    if (weatherForecast.Precipitation.ToLower().Contains("rain"))
                    {
                        if (this.HasDayPassedSinceLastWarning(weatherForecast.City))
                        {
                            this.ViewBag.Warning = "Rain is expected today!";
                            this.UpdateLastWarningTime(weatherForecast.City);
                        }
                    }

                    this.TempData["LastCity"] = weatherForecast.City;
                    this.HttpContext.Session.SetString("LastCity", weatherForecast.City);

                    this._logger.LogInformation($"Successfully received weather forecast for the city \"{weatherForecast.City}\"");
                }
                else
                {
                    this._logger.LogInformation($"No weather forecast found for the city \"{city}\"");
                }

                return this.View("WeatherResult", weatherForecast);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Error retrieving weather data for city \"{city}\"");
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        private bool HasDayPassedSinceLastWarning(string city)
        {

            DateTime? warningInfo = null;
            if (this.HttpContext.Session.TryGetValue(city, out byte[]? dateBytes) && dateBytes != null)
            {
                warningInfo = new DateTime(BitConverter.ToInt64(dateBytes, 0));
            }

            if (warningInfo != null)
            {
                return (DateTime.Now - warningInfo.Value).TotalDays >= 1;
            }

            return true;
        }

        private void UpdateLastWarningTime(string city)
        {
            this.HttpContext.Session.Set(city, BitConverter.GetBytes(DateTime.Now.Ticks));
        }
    }
}
