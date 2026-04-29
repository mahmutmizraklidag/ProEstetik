using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnHomeController : Controller
    {
        [Route("en")]
        public IActionResult Index()
        {
            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var enHomeUrl = $"{siteUrl}/en";

            var organizationSchema = SchemaGenerator.MedicalOrganization(
                siteUrl: enHomeUrl,
                clinicName: SchemaDefaults.ClinicNameEn,
                description: "Pro Estetik is a professional clinic providing health, aesthetics and beauty services.",
                logoUrl: $"{siteUrl}{SchemaDefaults.LogoPath}",
                imageUrl: $"{siteUrl}{SchemaDefaults.DefaultImagePath}",
                phone: SchemaDefaults.Phone,
                email: SchemaDefaults.Email,
                address: SchemaDefaults.AddressEn,
                city: SchemaDefaults.City,
                district: SchemaDefaults.District,
                postalCode: SchemaDefaults.PostalCode,
                countryCode: SchemaDefaults.CountryCode,
                sameAs: SchemaDefaults.SameAs
            );

            ViewBag.SchemaJson = SchemaGenerator.ToScript(organizationSchema);

            return View();
        }
    }
}