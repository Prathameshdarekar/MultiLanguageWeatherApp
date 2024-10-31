using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly string _apiKey = "b322426ad71ea488c55272053d35a206";
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<WeatherInfo> GetWeatherAsync(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_baseUrl}?q={city}&appid={_apiKey}&units=metric");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherInfo>(jsonResult);
                }
                return null;
            }
        }
    }
}
