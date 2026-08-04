using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var response = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);
            return View(response);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7084/Product/GetProductWithCategoryById?Id="+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var JsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var result = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(JsonData);
            //    return View(result);
            //}
            //return View();
        }
    }
}
