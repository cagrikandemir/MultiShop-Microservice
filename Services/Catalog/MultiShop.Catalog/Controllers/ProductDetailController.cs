using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdProductDetail(string Id)
        {
            var value = await _productDetailService.GetProductDetailByIdAsync(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayı Oluşturuldu.");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductDetail(string Id)
        {
            await _productDetailService.DeleteProductDetailAsync(Id);
            return Ok("Ürün Detayı Silindi.");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayı Güncellendi.");
        }
    }
}
