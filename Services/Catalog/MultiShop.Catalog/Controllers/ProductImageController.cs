using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductImage()
        {
            var values = await _productImageService.GetAllProductImagesAsync();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdProductImage(string Id)
        {
            var value = await _productImageService.GetProductImageByIdAsync(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Resmi Yüklendi.");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage(string Id)
        {
            await _productImageService.DeleteProductImageAsync(Id);
            return Ok("Ürün Resmi Silindi.");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Resmi Güncellendi.");
        }
    }
}
