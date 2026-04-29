using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly DatabaseContext _context;

        public TeamController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("ekip")]
        public IActionResult Index()
        {
            var model = _context.Teams
                .Where(x => x.Language.ToString() == "Tr")
                .ToList();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var teamUrl = $"{siteUrl}/ekip";

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Ekibimiz", teamUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToScript(breadcrumbSchema);

            return View(model);
        }

        [Route("ekip/{slug}")]
        public IActionResult Detail(string slug)
        {
            var model = _context.Teams
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault(x => x.Slug == slug);

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var doctorUrl = $"{siteUrl}/ekip/{model.Slug}";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, model.Image);

            var physicianSchema = SchemaGenerator.Physician(
                siteUrl: siteUrl,
                doctorUrl: doctorUrl,
                name: model.Name,
                position: model.Position,
                description: model.Description,
                imageUrl: imageUrl,
                clinicName: SchemaDefaults.ClinicNameTr
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Ekibimiz", $"{siteUrl}/ekip"),
                (model.Name, doctorUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                physicianSchema,
                breadcrumbSchema
            );

            return View(model);
        }
    }
}