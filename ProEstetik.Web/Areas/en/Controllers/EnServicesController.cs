using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnServicesController : Controller
    {
        private readonly DatabaseContext _context;

        public EnServicesController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("en/services/{slug}")]
        public IActionResult Index(string slug)
        {
            var service = _context.Services
                .Where(x => x.Language.ToString() == "En")
                .FirstOrDefault(s => s.Slug == slug);

            if (service == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var serviceUrl = $"{siteUrl}/en/services/{service.Slug}";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, service.Image);

            var serviceSchema = SchemaGenerator.MedicalService(
                siteUrl: siteUrl,
                serviceUrl: serviceUrl,
                title: service.Title,
                shortDescription: service.ShortDescription,
                description: service.Description,
                imageUrl: imageUrl,
                clinicName: SchemaDefaults.ClinicNameEn
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("Services", $"{siteUrl}/en#services"),
                (service.Title, serviceUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                serviceSchema,
                breadcrumbSchema
            );

            return View(service);
        }
    }
}