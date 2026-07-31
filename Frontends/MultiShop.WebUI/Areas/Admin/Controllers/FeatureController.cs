using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    //[AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFeatureService _featureService;

        public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService featureService)
        {
            _httpClientFactory = httpClientFactory;
            _featureService = featureService;
        }
        void ViewBagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Features";
            ViewBag.v3 = "Feature Listesi";
            ViewBag.v0 = "Feature";
        }
        [HttpGet]
        [Route("Index")]
        public async Task< IActionResult> Index()
        {
            var response = await _featureService.GetAllFeaturesAsync();
            return View(response);
        }
        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            ViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            
                await _featureService.CreateFeatureAsync(createFeatureDto);
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            
        }
        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult>DeleteFeature(string id)
        {
                await _featureService.DeleteFeatureAsync(id);
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBagList();
            var response = await _featureService.GetByIdFeatureAsync(id);
            return View(response);          
        }
        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult>UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
           await _featureService.UpdateFeatureAsync(updateFeatureDto);
           return RedirectToAction("Index", "Feature", new { area = "Admin" });
            
        }
    }
}
