using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIAdminLayoutComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
