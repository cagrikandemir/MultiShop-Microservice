using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductDetailImageService _productDetailImageService;

        public _ProductDetailImageSliderComponentPartial(IProductDetailImageService productDetailImageService)
        {
            _productDetailImageService = productDetailImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var response = await _productDetailImageService.GetByProductIdProductImageAsync(id);

            return View(response);
        }
    }
}