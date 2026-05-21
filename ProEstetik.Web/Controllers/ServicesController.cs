using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DatabaseContext _context;

        public ServicesController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("hizmetler/{slug}")]
        public IActionResult Index(string slug)
        {
            var service = _context.Services
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault(s => s.Slug == slug);

            if (service == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var serviceUrl = $"{siteUrl}/hizmetler/{service.Slug}";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, service.Image);

            var serviceSchema = SchemaGenerator.MedicalService(
                siteUrl: siteUrl,
                serviceUrl: serviceUrl,
                title: service.Title,
                shortDescription: service.ShortDescription,
                description: service.Description,
                imageUrl: imageUrl,
                clinicName: SchemaDefaults.ClinicNameTr
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Hizmetler", $"{siteUrl}/#hizmetler"),
                (service.Title, serviceUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                serviceSchema,
                breadcrumbSchema
            );

            return View(service);
        }
        [Route("hizmetler/{slug}/landing")]
        public IActionResult Landing(string slug)
        {
            var service = _context.Services
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault(s => s.Slug == slug);

            if (service == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);

            var serviceUrl = $"{siteUrl}/hizmetler/{service.Slug}/landing";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, service.Image);

            var serviceSchema = SchemaGenerator.MedicalService(
                siteUrl: siteUrl,
                serviceUrl: serviceUrl,
                title: service.Title,
                shortDescription: service.ShortDescription,
                description: service.Description,
                imageUrl: imageUrl,
                clinicName: SchemaDefaults.ClinicNameTr
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
    {
        ("Anasayfa", siteUrl),
        ("Hizmetler", $"{siteUrl}/#hizmetler"),
        ($"{service.Title} Landing Page", serviceUrl)
    });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                serviceSchema,
                breadcrumbSchema
            );

            return View(service);
        }
    }
}