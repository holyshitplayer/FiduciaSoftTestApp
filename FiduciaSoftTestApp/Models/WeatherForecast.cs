namespace FiduciaSoftTestApp.Models
{
    public class WeatherForecast
    {
        public string City { get; set; } = string.Empty;
        
        public DateTime Date { get; set; }

        public string Precipitation { get; set; } = string.Empty;

        public double HighTemperature { get; set; }

        public double LowTemperature { get; set; }
    }
}
