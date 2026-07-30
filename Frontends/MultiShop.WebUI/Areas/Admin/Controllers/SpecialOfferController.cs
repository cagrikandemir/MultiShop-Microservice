using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
        {
            _httpClientFactory = httpClientFactory;
            _specialOfferService = specialOfferService;
        }
        void ViewBagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif Ekle";
            ViewBag.v0 = "Özel Teklif Ekle";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagList();
            var response = await _specialOfferService.GetAllSpecialAsync();
            return View(response);
        }
        [HttpGet]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer()
        {
            ViewBagList();
            return View();
        }
        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
               await _specialOfferService.CreateSpecialAsync(createSpecialOfferDto);
               return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

        }
        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
                await _specialOfferService.DeleteSpecialAsync(id);
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });  
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
           var response= await _specialOfferService.GetByIdSpecialAsync(id);
            return View(response);
        }
        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
                await _specialOfferService.UpdateSpecialAsync(updateSpecialOfferDto);
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
