using FiduciaSoftTestApp.Models;
using FiduciaSoftTestApp.Models.WeatherForecastApi;
using RestSharp;

namespace FiduciaSoftTestApp.Services
{
    public class WeatherForecastService
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;

        public WeatherForecastService(IConfiguration configuration)
        {
            this._apiKey = configuration["WeatherApi:ApiKey"];
            this._apiUrl = configuration["WeatherApi:ApiUrl"];
        }

        public async Task<WeatherForecast?> GetWeatherForecastAsync(string city)
        {
            var client = new RestClient(this._apiUrl);
            var request = new RestRequest();

            request.AddQueryParameter("key", this._apiKey);
            request.AddQueryParameter("q", city);
            request.AddQueryParameter("days", "1");

            var response = await client.ExecuteAsync<WeatherForecastApiResponse>(request);
            if (response.IsSuccessful && response.Data != null)
            {
                var dateStr = response.Data.Forecast.ForecastDays[0].Date;
                if (DateTime.TryParse(dateStr, out var date))
                {
                    var weatherForecast = new WeatherForecast
                    {
                        City = response.Data.Location.Name,
                        Date = date,
                        Precipitation = response.Data.Forecast.ForecastDays[0].Day.Condition.Text,
                        HighTemperature = response.Data.Forecast.ForecastDays[0].Day.MaxTempC,
                        LowTemperature = response.Data.Forecast.ForecastDays[0].Day.MinTempC
                    };

                    return weatherForecast;
                }

                throw new FormatException($"Error parsing date from weather forecast: {response.ErrorMessage}");
            }

            return null;
        }
    }
}
