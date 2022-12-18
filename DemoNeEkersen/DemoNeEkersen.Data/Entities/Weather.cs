using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNeEkersen.Data.Entities
{
    public class Weather
    {
        public string Date { get; set; }
        public string Day { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Degree { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Night { get; set; }
        public string Humidity { get; set; }
    }

    public class RequestWeather
    {
        public string City { get; set; } = "izmir";
        public string Lang { get; set; } = "tr";
    }

    public class ResponseWeather
    {
        public string Day { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
    }

    public class ResponseWeatherData
    {
        public List<ResponseWeather> WeatherData { get; set; }
        public string Hata { get; set; }
    }
}
