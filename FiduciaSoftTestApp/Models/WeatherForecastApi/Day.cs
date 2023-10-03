using System.Text.Json.Serialization;

namespace FiduciaSoftTestApp.Models.WeatherForecastApi
{
    public class Day
    {
        [JsonPropertyName("maxtemp_c")]
        public double MaxTempC { get; set; }

        [JsonPropertyName("maxtemp_f")]
        public double MaxTempF { get; set; }

        [JsonPropertyName("mintemp_c")]
        public double MinTempC { get; set; }

        [JsonPropertyName("mintemp_f")]
        public double MinTempF { get; set; }

        [JsonPropertyName("avgtemp_c")]
        public double AvgTempC { get; set; }

        [JsonPropertyName("avgtemp_f")]
        public double AvgTempF { get; set; }

        [JsonPropertyName("maxwind_mph")]
        public double MaxWindMph { get; set; }

        [JsonPropertyName("maxwind_kph")]
        public double MaxWindKph { get; set; }

        [JsonPropertyName("totalprecip_mm")]
        public double TotalPrecipMm { get; set; }

        [JsonPropertyName("totalprecip_in")]
        public double TotalPrecipIn { get; set; }

        [JsonPropertyName("totalsnow_cm")]
        public double TotalSnowCm { get; set; }

        [JsonPropertyName("avgvis_km")]
        public double AvgVisKm { get; set; }

        [JsonPropertyName("avgvis_miles")]
        public double AvgVisMiles { get; set; }

        [JsonPropertyName("avghumidity")]
        public double AvgHumidity { get; set; }

        [JsonPropertyName("daily_will_it_rain")]
        public double DailyWillItRain { get; set; }

        [JsonPropertyName("daily_chance_of_rain")]
        public double DailyChanceOfRain { get; set; }

        [JsonPropertyName("daily_will_it_snow")]
        public double DailyWillItSnow { get; set; }

        [JsonPropertyName("daily_chance_of_snow")]
        public int DailyChanceOfSnow { get; set; }

        [JsonPropertyName("condition")]
        public Condition Condition { get; set; } = new();

        [JsonPropertyName("uv")]
        public double UV { get; set; }
    }
}
