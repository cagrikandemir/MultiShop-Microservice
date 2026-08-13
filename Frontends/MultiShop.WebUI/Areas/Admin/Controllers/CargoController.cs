using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")] // Rota şablonunu otomatikleştiriyoruz
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllResultCargoCompanyAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCargoCompany()
        {
            CargoCompanyViewbagList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteCargoCompany(string id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCargoCompany(string id)
        {
            CargoCompanyViewbagList();
            var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
        void CargoCompanyViewbagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Kargo";
            ViewBag.v3 = "Firma Listesi";
            ViewBag.v0 = "Kargo";
        }
    }
}
