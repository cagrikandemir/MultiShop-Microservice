using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async  Task<IActionResult> UserList()
        {
            var users= await _userIdentityService.GetAllUserListAsync();
            return View(users);
        }
        public async Task<IActionResult> UserAddressInfo(string Id)
        {
            var values = await _cargoCustomerService.GetCargoCustomerInfoByIdAsync(Id);
            return View(values);
        }
    }
}
