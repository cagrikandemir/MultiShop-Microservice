using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFeatureSliders()
        {
            return Ok(await _featureSliderService.GetAllFeatureSlidersAsync());
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            
            var values = await _featureSliderService.GetFeatureSliderByIdAsync(id);
            return Ok(values);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {    
            await _featureSliderService.CreateFeatureSlider(createFeatureSliderDto);
            return Ok("Feature Slider Başarıyla Eklendi");
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSlider(id);
            return Ok("Feature Slider Başarıyla Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSlider(updateFeatureSliderDto);
            return Ok("Feature Slider Başarıyla Güncellendi");
        }
    }
}
