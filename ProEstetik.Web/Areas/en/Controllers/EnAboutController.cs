using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnAboutController : Controller
    {
        private readonly DatabaseContext _context;

        public EnAboutController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("en/about-us")]
        public IActionResult Index()
        {
            var model = _context.Abouts
                .Where(x => x.Language.ToString() == "En")
                .FirstOrDefault();

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var aboutUrl = $"{siteUrl}/en/about-us";

            var aboutSchema = SchemaGenerator.AboutPage(
                siteUrl: siteUrl,
                aboutUrl: aboutUrl,
                title: model.Title,
                description: !string.IsNullOrWhiteSpace(model.MetaDescription)
                    ? model.MetaDescription
                    : model.Description,
                clinicName: SchemaDefaults.ClinicNameEn
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("About Us", aboutUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                aboutSchema,
                breadcrumbSchema
            );

            return View(model);
        }
    }
}