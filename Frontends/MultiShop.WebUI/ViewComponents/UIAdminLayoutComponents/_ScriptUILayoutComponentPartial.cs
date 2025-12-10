using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UIAdminLayoutComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
