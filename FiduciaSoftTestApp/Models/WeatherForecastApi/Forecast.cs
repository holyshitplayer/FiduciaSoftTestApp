using System.Text.Json.Serialization;

namespace FiduciaSoftTestApp.Models.WeatherForecastApi
{
    public class Forecast
    {
        [JsonPropertyName("forecastday")]
        public List<ForecastDay> ForecastDays { get; set; } = new();
    }
}
