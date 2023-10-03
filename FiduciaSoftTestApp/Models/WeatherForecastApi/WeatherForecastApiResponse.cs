using System.Text.Json.Serialization;

namespace FiduciaSoftTestApp.Models.WeatherForecastApi
{
    public class WeatherForecastApiResponse
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; } = new();

        [JsonPropertyName("current")]
        public Current Current { get; set; } = new();

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; } = new();
    }
}
