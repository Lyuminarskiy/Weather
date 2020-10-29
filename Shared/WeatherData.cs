using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Shared
{
    /// <summary>
    /// Информация о содержимом ответа:
    /// <see cref="https://openweathermap.org/current#current_JSON"/>
    /// </summary>
    public struct WeatherData
    {
        /// <summary>
        /// Возможные состояния погоды:
        /// <see cref="https://openweathermap.org/weather-conditions"/>
        /// </summary>
        private struct Weather
        {
            public string Description;
            public string Icon;
        }

        private struct Main
        {
            public double Temp;
        }
        
        [JsonProperty("weather")]
        private IEnumerable<Weather> _weather;
        
        [JsonProperty("main")]
        private Main _main;

        /// <summary>
        /// Показания темературы.
        /// </summary>
        public double Temperature => _main.Temp;
        
        /// <summary>
        /// Описание погоды.
        /// </summary>
        public string Description => _weather.First().Description;
        
        /// <summary>
        /// Идентификатор иконки погоды.
        /// </summary>
        public string IconId => _weather.First().Icon;
        
        /// <summary>
        /// Название города.
        /// </summary>
        [JsonProperty("name")]
        public string City;
    }
}