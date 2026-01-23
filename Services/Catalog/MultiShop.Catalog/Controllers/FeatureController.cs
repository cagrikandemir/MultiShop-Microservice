using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFeature()
        {
            return Ok(await _featureService.GetAllFeaturesAsync());
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdFeature(string id)
        {
            return Ok(await _featureService.GetFeatureByIdAsync(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Feature Başarıyla Eklendi");
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult>DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Feature Başarıyla Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Feature Başarıyla Güncellendi");
        }
    }
}
