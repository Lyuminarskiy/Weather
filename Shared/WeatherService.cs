using System.Threading.Tasks;
using Refit;

namespace Shared
{
    public static class WeatherService
    {
        private const string BaseUrl = "https://api.openweathermap.org";
        private static readonly IOpenWeatherMapApi OpenWeatherMapApi = RestService
            .For<IOpenWeatherMapApi>(BaseUrl);
        
        /// <summary>
        /// Получить погоду для города <paramref name="city"/>.
        /// </summary>
        /// <param name="city">имя города.</param>
        /// <returns>Данные о погоде.</returns>
        /// <seealso cref="https://openweathermap.org/current#name"/>
        public static Task<WeatherData> GetWeather(string city) => OpenWeatherMapApi.GetWeather(city.Trim());
        
        /// <summary>
        /// Получить погоду по географическим координатам.
        /// </summary>
        /// <param name="latitude">широта.</param>
        /// <param name="longitude">долгота.</param>
        /// <returns>Данные о погоде.</returns>
        /// <seealso cref="https://openweathermap.org/current#geo"/>
        public static Task<WeatherData> GetWeather(double latitude, double longitude) => 
            OpenWeatherMapApi.GetWeather(latitude, longitude);
    }
}