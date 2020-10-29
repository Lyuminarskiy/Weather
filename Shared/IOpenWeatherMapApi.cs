using System.Threading.Tasks;
using Refit;

namespace Shared
{
    /// <summary>
    /// Интерфейс для доступа к REST API сайта OpenWeatherMap.
    /// </summary>
    /// <seealso cref="https://reactiveui.github.io/refit/"/>
    internal interface IOpenWeatherMapApi
    {
        /// <summary>
        /// Ключ доступа к API. Подставьте сюда свой ключ.
        /// </summary>
        private const string ApiKey = "";
        
        [Get("/data/2.5/weather?lang=ru&units=metric&q={city name}&appid={API key}")]
        Task<WeatherData> GetWeather([AliasAs("city name")] string cityName,
            [AliasAs("API key")] string apiKey = ApiKey);
        
        [Get("/data/2.5/weather?lang=ru&units=metric&lat={lat}&lon={lon}&appid={API key}")]
        Task<WeatherData> GetWeather([AliasAs("lat")] double latitude,
            [AliasAs("lon")] double longitude,
            [AliasAs("API key")] string apiKey = ApiKey);
    }
}