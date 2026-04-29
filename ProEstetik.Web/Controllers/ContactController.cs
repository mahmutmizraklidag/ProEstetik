using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class ContactController : Controller
    {
        [Route("iletisim")]
        public IActionResult Index()
        {
            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            return View();
        }
    }
}
