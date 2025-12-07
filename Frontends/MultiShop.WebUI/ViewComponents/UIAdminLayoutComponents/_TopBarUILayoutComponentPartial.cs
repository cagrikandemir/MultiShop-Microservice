using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIAdminLayoutComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
