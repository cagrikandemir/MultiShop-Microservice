using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService)
        {
            _httpClientFactory = httpClientFactory;
            _featureSliderService = featureSliderService;
        }
        void ViewBagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Listesi";
            ViewBag.v0 = "Öne Çıkanlar";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagList();
            var response = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(response);

        }
        [HttpGet]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            ViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            //createFeatureSliderDto.Status = true;
                await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
                return RedirectToAction("Index","FeatureSlider", new { area = "Admin" });
        }
        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
                await _featureSliderService.DeleteFeatureSliderAsync(id);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });

        }
        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult>UpdateFeatureSlider(string id)
        {
            var response = await _featureSliderService.GetByIdCategoryAsync(id);
            return View(response);
        }
        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
                ViewBagList();
                await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
