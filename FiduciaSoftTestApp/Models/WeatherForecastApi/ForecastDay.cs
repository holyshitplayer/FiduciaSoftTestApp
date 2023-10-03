using System.Text.Json.Serialization;

namespace FiduciaSoftTestApp.Models.WeatherForecastApi
{
    public class ForecastDay
    {
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("date_epoch")]
        public int DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public Day Day { get; set; } = new();

        [JsonPropertyName("astro")]
        public Astro Astro { get; set; } = new();

        [JsonPropertyName("hour")]
        public List<Hour> Hour { get; set; } = new();
    }
}
