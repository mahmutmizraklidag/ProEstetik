using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Models;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var about = _context.Abouts
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault();

            var description = about != null
                ? (!string.IsNullOrWhiteSpace(about.MetaDescription) ? about.MetaDescription : about.Description)
                : "Pro Estetik sağlık, estetik ve güzellik alanlarında hizmet veren profesyonel kliniktir.";

            var organizationSchema = SchemaGenerator.MedicalOrganization(
                siteUrl: siteUrl,
                clinicName: SchemaDefaults.ClinicNameTr,
                description: description,
                logoUrl: $"{siteUrl}{SchemaDefaults.LogoPath}",
                imageUrl: $"{siteUrl}{SchemaDefaults.DefaultImagePath}",
                phone: SchemaDefaults.Phone,
                email: SchemaDefaults.Email,
                address: SchemaDefaults.AddressTr,
                city: SchemaDefaults.City,
                district: SchemaDefaults.District,
                postalCode: SchemaDefaults.PostalCode,
                countryCode: SchemaDefaults.CountryCode,
                sameAs: SchemaDefaults.SameAs
            );

            ViewBag.SchemaJson = SchemaGenerator.ToScript(organizationSchema);

            return View();
        }

        [Route("404")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}