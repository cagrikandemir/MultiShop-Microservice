using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("UpdateProductDetail/{Id}")]
        public async  Task<IActionResult> UpdateProductDetail(string Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/ProductDetail/GetByIdProductDetailByProductId/"+Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Result = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(Result);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateProductDetail/{Id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(JsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/ProductDetail/UpdateProductDetail", stringContent);
            if (responseMessage.IsSuccessStatusCode) {

                return RedirectToAction("ProductListWithCategory", "Product" , new {area="Admin"});
            }
            return View();
        }
    }
}
