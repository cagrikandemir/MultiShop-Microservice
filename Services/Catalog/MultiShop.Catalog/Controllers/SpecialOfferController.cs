using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpeacialOfferService _speacialOfferService;

        public SpecialOfferController(ISpeacialOfferService speacialOfferService)
        {
            _speacialOfferService = speacialOfferService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSpecialOffers()
        {
            return Ok(await _speacialOfferService.GetAllSpecialOfferAsync());
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _speacialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpeacialOfferDto createSpeacialOfferDto)
        {
            await _speacialOfferService.CreateSpecialOfferAsync(createSpeacialOfferDto);
            return Ok("Special Offer Başarıyla Eklendi");
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _speacialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Special Offer Başarıyla Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpeacialOfferDto updateSpeacialOfferDto)
        {
            await _speacialOfferService.UpdateSpecialOfferAsync(updateSpeacialOfferDto);
            return Ok("Special Offer Başarıyla Güncellendi");
        }
    }
}
