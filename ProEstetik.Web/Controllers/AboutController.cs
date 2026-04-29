using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly DatabaseContext _context;

        public AboutController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("hakkimizda")]
        public IActionResult Index()
        {
            var model = _context.Abouts
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault();

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            var aboutUrl = $"{siteUrl}/hakkimizda";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var aboutSchema = SchemaGenerator.AboutPage(
                siteUrl: siteUrl,
                aboutUrl: aboutUrl,
                title: model.Title,
                description: !string.IsNullOrWhiteSpace(model.MetaDescription)
                    ? model.MetaDescription
                    : model.Description,
                clinicName: SchemaDefaults.ClinicNameTr
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Hakkımızda", aboutUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                aboutSchema,
                breadcrumbSchema
            );

            return View(model);
        }
    }
}