using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
   // [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBrandService _brandService;

        public BrandController(IHttpClientFactory httpClientFactory, IBrandService brandService)
        {
            _httpClientFactory = httpClientFactory;
            _brandService = brandService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var response = await _brandService.GetAllBrandAsync();
            return View(response);
        }
        [Route("CreateBrand")]
        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }
        [Route("CreateBrand")]
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
           await _brandService.CreateBrandAsync(createBrandDto);
           return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("DeleteBrand/{Id}")]
        public async Task<IActionResult>DeleteBrand(string Id)
        {
           await _brandService.DeleteBrandAsync(Id);
           return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
        [Route("UpdateBrand/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string Id)
        {
            var response = await _brandService.GetByIdBrandAsync(Id);
            return View(response);
        }
        [Route("UpdateBrand/{Id}")]
        [HttpPost]
        public async Task<IActionResult>UpdateBrand(UpdateBrandDto updateBrandDto)
        {
                await _brandService.UpdateBrandAsync(updateBrandDto);
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
