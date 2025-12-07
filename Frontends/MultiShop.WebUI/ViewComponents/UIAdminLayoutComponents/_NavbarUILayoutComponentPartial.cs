using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIAdminLayoutComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
