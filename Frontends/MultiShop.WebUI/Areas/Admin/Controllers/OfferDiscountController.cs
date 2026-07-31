using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IHttpClientFactory httpClientFactory, IOfferDiscountService offerDiscountService)
        {
            _httpClientFactory = httpClientFactory;
            _offerDiscountService = offerDiscountService;
        }
        void ViewBagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Offer Discounts";
            ViewBag.v3 = "Offer Discounts";
            ViewBag.v0 = "Offer Discount";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBagList();
            var response = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(response);
        }
        [Route("CreateOfferDiscount")]
        [HttpGet]
        public async Task<IActionResult> CreateOfferDiscount()
        {
            ViewBagList();
            return View();
        }
        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
           await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
           return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            
        }
        [Route("DeleteOfferDiscount/{Id}")]
        public async Task<IActionResult>DeleteOfferDiscount(string Id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(Id);
           return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("UpdateOfferDiscount/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string Id)
        {
            var response = await _offerDiscountService.GetByIdOfferDiscount(Id);
            return View(response);

        }
        [HttpPost]
        [Route("UpdateOfferDiscount/{Id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
           return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

    }
}
