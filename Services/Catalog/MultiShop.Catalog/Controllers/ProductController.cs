using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var values = await _productService.GetAllProductsAsync();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdProduct(string Id)
        {
            var value = await _productService.GetByIdProductAsync(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProduct(string Id)
        {
            await _productService.DeleteProductAsync(Id);
            return Ok("Ürün Başarıyla Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
    }
}
