using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAboutService _aboutService;

        public AboutController(IHttpClientFactory httpClientFactory, IAboutService aboutService)
        {
            _httpClientFactory = httpClientFactory;
            _aboutService = aboutService;
        }
        [Route("Index")]
        public async Task< IActionResult> Index()
        {
            var response = await _aboutService.GetAllResultAboutAsync();
            return View(response);
        }
        [Route("CreateAbout")]
        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }
        [Route("CreateAbout")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });   
        }
        [Route("DeleteAbout/{Id}")]
        public async Task<IActionResult> DeleteAbout(string Id)
        {        
                await _aboutService.DeleteAboutAsync(Id);
                return RedirectToAction("Index", "About", new { area = "Admin" });         
        }
        [Route("UpdateAbout/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string Id)
        {
            var response = await _aboutService.GetByIdAboutAsync(Id);
            return View(response);
        }
        [Route("UpdateAbout/{Id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {   
                await _aboutService.UpdateAboutAsync(updateAboutDto);
                return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
