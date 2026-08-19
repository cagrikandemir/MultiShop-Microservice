using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Models
{
    public class WeatherModel
    {

        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string localtime { get; set; }
        public double temperature_c { get; set; }
        public double temperature_f { get; set; }
        public string condition { get; set; }
        public string icon_url { get; set; }
        public double wind_kph { get; set; }
        public int humidity { get; set; }
        public double feelslike_c { get; set; }
        public double uv_index { get; set; }

    }
}