using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()

        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://global-weather-api1.p.rapidapi.com/weather?city=sivas"),
                Headers =
    {
        { "x-rapidapi-key", "8a4f9155abmsh795c451a32a5397p1f9115jsna7cd9883d4c3" },
        { "x-rapidapi-host", "global-weather-api1.p.rapidapi.com" },
        { "x-api-key", "29gcWxc1xHP498ntsy" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherModel>(body);
                var values1 = JsonConvert.DeserializeObject<WeatherModel>(body);
                ViewBag.Weather = values.temperature_c;
                ViewBag.City = values1.city;
                return View(values);
            }
        }
        

        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "8a4f9155abmsh795c451a32a5397p1f9115jsna7cd9883d4c3" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeModel.Rootobject>(body);
                ViewBag.ExchangeRatedolar = values.data.exchange_rate;
                ViewBag.CloseExchangedolar = values.data.previous_close;
            }

            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "8a4f9155abmsh795c451a32a5397p1f9115jsna7cd9883d4c3" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response1 = await client1.SendAsync(request1))
            {
                response1.EnsureSuccessStatusCode();
                var body1 = await response1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ExchangeModel.Rootobject>(body1);
                ViewBag.ExchangeRateEuro = values1.data.exchange_rate;
                ViewBag.CloseExchangeEuro = values1.data.previous_close;
            }
            return View();
        }
    }
}
