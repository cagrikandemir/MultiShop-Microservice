using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Offer Discounts";
            ViewBag.v3 = "Offer Discounts";
            ViewBag.v0 = "Offer Discount";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/OfferDiscount/GetAllOfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpGet]
        public async Task<IActionResult> CreateOfferDiscount()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Offer Discounts";
            ViewBag.v3 = "Offer Discount Ekle";
            ViewBag.v0 = "Offer Discounts";
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/OfferDiscount/CreateOfferDiscount", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteOfferDiscount/{Id}")]
        public async Task<IActionResult>DeleteOfferDiscount(string Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7084/OfferDiscount/DeleteOfferDiscount/"+Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateOfferDiscount/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/OfferDiscount/GetByIdOfferDiscount/"+Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Result = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(JsonData);
                return View(Result);
            }
            return View();

        }
        [HttpPost]
        [Route("UpdateOfferDiscount/{Id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "Application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/OfferDiscount/UpdateOfferDiscount/",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

    }
}
