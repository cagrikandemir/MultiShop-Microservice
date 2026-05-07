using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllAbouts()
        {
            return Ok(await _aboutService.GetAllAboutAsync());
        }
        [HttpGet("[Action]/{Id}")]
        public async Task<IActionResult> GetAboutById(string Id)
        {
            return Ok(await _aboutService.GetByIdAboutAsync(Id));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("About Eklendi");
        }
        [HttpDelete("[Action]/{Id}")]
        public async Task<IActionResult> DeleteAbout(string Id)
        {
            await _aboutService.DeleteAboutAsync(Id);
            return Ok("About Silindi");

        }
        [HttpPut("[Action]")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("About Güncellendi");
        }
    }
}
