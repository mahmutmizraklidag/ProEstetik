using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProEstetik.Web.ViewComponentContollers
{
    
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
