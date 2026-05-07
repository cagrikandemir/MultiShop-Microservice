using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOfferDiscounts()
        {
            return Ok (await _offerDiscountService.GetAllOfferDiscountOffer());  
        }
        [HttpGet("[Action]/{Id}")]
        public async Task <IActionResult> GetByIdOfferDiscount(string Id)
        {
            return Ok (await _offerDiscountService.GetByIdOfferDiscount(Id));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult>CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscount(createOfferDiscountDto);
            return Ok("Offer Discount Başarıyla Eklendi");
        }
        [HttpDelete("[Action]/{Id}")]
        public async Task<IActionResult>DeleteOfferDiscount(string Id)
        {
            await _offerDiscountService.DeleteOfferDiscount(Id);
            return Ok("Offer Discount Başarıyla Silindi");
        }
        [HttpPut("[Action]")]
        public async Task<IActionResult>UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscount(updateOfferDiscountDto);
            return Ok("Offer Discount Güncellendi");
        }
    }
}
