using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class WeatherInfo
    {
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Weather[] Weather { get; set; } // Array to hold multiple weather conditions
        public string Name { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }

    public class Weather
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
