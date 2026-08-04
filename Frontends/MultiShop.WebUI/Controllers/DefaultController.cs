using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Anaa Sayfa";
            ViewBag.directory3 = "Ürün Listesi";
            var user = User.Claims;
            int x;
            return View();
        }
    }
}
