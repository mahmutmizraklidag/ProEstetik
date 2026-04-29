using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Areas.en.Controllers
{
    [Area("en")]
    public class EnBlogController : Controller
    {
        private readonly DatabaseContext _context;

        public EnBlogController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("en/blog")]
        public IActionResult Index()
        {
            var model = _context.Blogs
                .Where(x => x.Language.ToString() == "En")
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var blogUrl = $"{siteUrl}/en/blog";

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("Blog", blogUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToScript(breadcrumbSchema);

            return View(model);
        }

        [Route("en/blog/{slug}")]
        public IActionResult Detail(string slug)
        {
            var model = _context.Blogs
                .Where(x => x.Language.ToString() == "En")
                .FirstOrDefault(x => x.Slug == slug);

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var blogUrl = $"{siteUrl}/en/blog/{model.Slug}";
            var imageUrl = SchemaGenerator.AbsoluteImageUrl(siteUrl, model.Image);
            var publisherLogoUrl = $"{siteUrl}{SchemaDefaults.LogoPath}";

            var blogSchema = SchemaGenerator.BlogPosting(
                siteUrl: siteUrl,
                blogUrl: blogUrl,
                title: model.Title,
                description: !string.IsNullOrWhiteSpace(model.MetaDescription)
                    ? model.MetaDescription
                    : model.Description,
                imageUrl: imageUrl,
                createdAt: model.CreatedAt,
                authorName: SchemaDefaults.ClinicNameEn,
                publisherName: SchemaDefaults.ClinicNameEn,
                publisherLogoUrl: publisherLogoUrl
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Home", $"{siteUrl}/en"),
                ("Blog", $"{siteUrl}/en/blog"),
                (model.Title, blogUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToMultipleScripts(
                blogSchema,
                breadcrumbSchema
            );

            return View(model);
        }
    }
}