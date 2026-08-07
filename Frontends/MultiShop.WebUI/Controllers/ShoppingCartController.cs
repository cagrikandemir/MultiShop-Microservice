using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            return View();
        }
        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.DeleteBasketItem(productId);
            return RedirectToAction("Index");
        }
    }
}
