using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDiscount()
        {
            return Ok(await _discountService.GetAllCouponAsync());
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdDiscount(string Id)
        {
            return Ok(await _discountService.GetByIdCouponAsync(Id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateDiscount(CreateCouponDto createCouponDto)
        {
             await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon Kodu Eklendi!");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteDiscount(string Id)
        {
            await _discountService.DeleteCouponAsync(Id);
            return Ok("Kupon Kodu Silindi!");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDiscount(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon Kodu Güncellendi!");
        }
    }
}
