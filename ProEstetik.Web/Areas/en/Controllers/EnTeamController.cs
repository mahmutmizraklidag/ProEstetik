using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnTeamController : Controller
    {
        private readonly DatabaseContext _context;

        public EnTeamController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("en/team")]
        public IActionResult Index()
        {
            var model = _context.Teams
                .Where(x => x.Language.ToString() == "En")
                .ToList();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var teamUrl = $"{siteUrl}/en/team";

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("Team", teamUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToScript(breadcrumbSchema);

            return View(model);
        }

        [Route("en/team/{slug}")]
        public IActionResult Detail(string slug)
        {
            var model = _context.Teams
                .Where(x => x.Slug == slug && x.Language.ToString() == "En")
                .FirstOrDefault();

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var doctorUrl = $"{siteUrl}/en/team/{model.Slug}";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, model.Image);

            var physicianSchema = SchemaGenerator.Physician(
                siteUrl: siteUrl,
                doctorUrl: doctorUrl,
                name: model.Name,
                position: model.Position,
                description: model.Description,
                imageUrl: imageUrl,
                clinicName: SchemaDefaults.ClinicNameEn
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("Team", $"{siteUrl}/en/team"),
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