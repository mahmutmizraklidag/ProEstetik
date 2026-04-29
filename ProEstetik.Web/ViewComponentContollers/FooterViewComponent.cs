using Microsoft.AspNetCore.Mvc;

namespace ProEstetik.Web.ViewComponentContollers
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
