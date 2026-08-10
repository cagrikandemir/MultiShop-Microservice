using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscoutCoupon()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscoutCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);
            return View(values);
        }
    }
}
