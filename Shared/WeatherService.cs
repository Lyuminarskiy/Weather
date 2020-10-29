using System;
using System.Threading.Tasks;
using Refit;

namespace Shared
{
    public static class WeatherService
    {
        private const string BaseUrl = "https://api.openweathermap.org";
        private static readonly IOpenWeatherMapApi OpenWeatherMapApi = RestService
            .For<IOpenWeatherMapApi>(BaseUrl);
        
        public static Task<WeatherData> GetWeather(string city) => OpenWeatherMapApi.GetWeather(city);
        public static Task<WeatherData> GetWeather(double latitude, double longitude) => 
            OpenWeatherMapApi.GetWeather(latitude, longitude);
    }
}