using System;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace Cli
{
    internal static class Program
    {
        
        private static async Task Main(string[] args)
        {
            if (args.Length == 0 || args.First() == "-h" || args.First() == "--help")
            {
                Console.WriteLine("Пожалуйста, введите список интересующих вас городов через запятую.");
                return;
            }
            
            var cities = args.First().Split(",");
            foreach (var city in cities)
            {
                try
                {
                    await ShowWeather(city);
                }
                catch
                {
                    Console.WriteLine($"{city}: прогноз погоды получить не удалось!");
                }

                Console.WriteLine("---------------------------------");
            }

        }

        /// <summary>
        /// Отображает в консоли информацию о погоде для <paramref name="city"/>.
        /// <remarks>Для отображения символов погоды используйте терминал с поддержкой Unicode.</remarks>
        /// </summary>
        /// <param name="city">город</param>
        /// <returns></returns>
        private static async Task ShowWeather(string city)
        {
            var weather = await WeatherService.GetWeather(city);
            
            var cityIcon = weather.IconId.Last() switch
            {
                'd' => "🏙️",
                'n' => "🌃",
                _ => ""
            };
            var weatherIcon = weather.IconId.Substring(0, 2) switch
            {
                "01" => "☀️",
                "02" => "⛅",
                var id when id == "03" || id == "04" => "☁️",
                var id when id == "09" || id == "10" => "🌧️",
                "11" => "⛈️",
                "13" => "🌨️",
                "50" => "🌁",
                _ => ""
            };

            Console.WriteLine($"{cityIcon}\t{weather.City}\n" +
                              $"{weatherIcon}\t{weather.Description}\n" +
                              $"🌡️\t{weather.Temperature} ℃");
        }
    }
}