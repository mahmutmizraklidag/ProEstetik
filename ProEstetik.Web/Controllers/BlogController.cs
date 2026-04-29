using Microsoft.AspNetCore.Mvc;
using ProEstetik.Web.Data;
using ProEstetik.Web.Services;

namespace ProEstetik.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly DatabaseContext _context;

        public BlogController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("blog")]
        public IActionResult Index()
        {
            var model = _context.Blogs
                .Where(x => x.Language.ToString() == "Tr")
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var blogUrl = $"{siteUrl}/blog";

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Blog", blogUrl)
            });

            ViewBag.SchemaJson = SchemaGenerator.ToScript(breadcrumbSchema);

            return View(model);
        }

        [Route("blog/{slug}")]
        public IActionResult Detail(string slug)
        {
            var model = _context.Blogs
                .Where(x => x.Language.ToString() == "Tr")
                .FirstOrDefault(x => x.Slug == slug);

            if (model == null)
                return NotFound();

            var siteUrl = $"{Request.Scheme}://{Request.Host}";
            ViewBag.HreflangTags = HreflangGenerator.GenerateBasic(siteUrl, Request.Path);
            var blogUrl = $"{siteUrl}/blog/{model.Slug}";
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
                authorName: SchemaDefaults.ClinicNameTr,
                publisherName: SchemaDefaults.ClinicNameTr,
                publisherLogoUrl: publisherLogoUrl
            );

            var breadcrumbSchema = SchemaGenerator.BreadcrumbList(new List<(string Name, string Url)>
            {
                ("Anasayfa", siteUrl),
                ("Blog", $"{siteUrl}/blog"),
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