using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnContactController : Controller
    {
        [Route("en/contact")]
        public IActionResult Index()
        {
            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            return View();
        }
    }
}
