using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ProEstetik.Web.Services
{
    public static class SchemaGenerator
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        public static string ToScript(object schema)
        {
            var json = JsonSerializer.Serialize(schema, JsonOptions);

            return $"""
            <script type="application/ld+json">
            {json}
            </script>
            """;
        }

        public static string ToMultipleScripts(params object?[] schemas)
        {
            return string.Join("\n", schemas
                .Where(x => x != null)
                .Select(x => ToScript(x!)));
        }

        public static object MedicalOrganization(
            string siteUrl,
            string clinicName,
            string description,
            string logoUrl,
            string imageUrl,
            string phone,
            string email,
            string address,
            string city,
            string district,
            string postalCode,
            string countryCode,
            List<string>? sameAs = null)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "MedicalOrganization",
                ["@id"] = $"{siteUrl.TrimEnd('/')}/#medicalorganization",
                ["name"] = clinicName,
                ["url"] = siteUrl,
                ["description"] = StripHtml(description),
                ["logo"] = logoUrl,
                ["image"] = imageUrl,
                ["telephone"] = phone,
                ["email"] = email,
                ["address"] = new Dictionary<string, object?>
                {
                    ["@type"] = "PostalAddress",
                    ["streetAddress"] = address,
                    ["addressLocality"] = district,
                    ["addressRegion"] = city,
                    ["postalCode"] = postalCode,
                    ["addressCountry"] = countryCode
                },
                ["sameAs"] = sameAs ?? new List<string>()
            };
        }

        public static object AboutPage(
            string siteUrl,
            string aboutUrl,
            string title,
            string description,
            string clinicName)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "AboutPage",
                ["@id"] = $"{aboutUrl.TrimEnd('/')}/#aboutpage",
                ["url"] = aboutUrl,
                ["name"] = title,
                ["description"] = StripHtml(description),
                ["about"] = new Dictionary<string, object?>
                {
                    ["@type"] = "MedicalOrganization",
                    ["@id"] = $"{siteUrl.TrimEnd('/')}/#medicalorganization",
                    ["name"] = clinicName,
                    ["url"] = siteUrl
                }
            };
        }

        public static object BlogPosting(
            string siteUrl,
            string blogUrl,
            string title,
            string description,
            string imageUrl,
            DateTime createdAt,
            string authorName,
            string publisherName,
            string publisherLogoUrl)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "BlogPosting",
                ["@id"] = $"{blogUrl.TrimEnd('/')}/#blogposting",
                ["mainEntityOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebPage",
                    ["@id"] = blogUrl
                },
                ["headline"] = title,
                ["description"] = StripHtml(description),
                ["image"] = imageUrl,
                ["datePublished"] = createdAt.ToString("yyyy-MM-dd"),
                ["dateModified"] = createdAt.ToString("yyyy-MM-dd"),
                ["author"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Organization",
                    ["name"] = authorName
                },
                ["publisher"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Organization",
                    ["@id"] = $"{siteUrl.TrimEnd('/')}/#medicalorganization",
                    ["name"] = publisherName,
                    ["logo"] = new Dictionary<string, object?>
                    {
                        ["@type"] = "ImageObject",
                        ["url"] = publisherLogoUrl
                    }
                }
            };
        }

        public static object MedicalService(
            string siteUrl,
            string serviceUrl,
            string title,
            string shortDescription,
            string description,
            string imageUrl,
            string clinicName)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "MedicalService",
                ["@id"] = $"{serviceUrl.TrimEnd('/')}/#medicalservice",
                ["name"] = title,
                ["url"] = serviceUrl,
                ["description"] = !string.IsNullOrWhiteSpace(shortDescription)
                    ? StripHtml(shortDescription)
                    : StripHtml(description),
                ["image"] = imageUrl,
                ["provider"] = new Dictionary<string, object?>
                {
                    ["@type"] = "MedicalOrganization",
                    ["@id"] = $"{siteUrl.TrimEnd('/')}/#medicalorganization",
                    ["name"] = clinicName,
                    ["url"] = siteUrl
                },
                ["areaServed"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Country",
                    ["name"] = "Türkiye"
                }
            };
        }

        public static object Physician(
            string siteUrl,
            string doctorUrl,
            string name,
            string position,
            string description,
            string imageUrl,
            string clinicName)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "Physician",
                ["@id"] = $"{doctorUrl.TrimEnd('/')}/#physician",
                ["name"] = name,
                ["url"] = doctorUrl,
                ["image"] = imageUrl,
                ["jobTitle"] = position,
                ["description"] = StripHtml(description),
                ["worksFor"] = new Dictionary<string, object?>
                {
                    ["@type"] = "MedicalOrganization",
                    ["@id"] = $"{siteUrl.TrimEnd('/')}/#medicalorganization",
                    ["name"] = clinicName,
                    ["url"] = siteUrl
                }
            };
        }

        public static object BreadcrumbList(List<(string Name, string Url)> items)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "BreadcrumbList",
                ["itemListElement"] = items.Select((item, index) => new Dictionary<string, object?>
                {
                    ["@type"] = "ListItem",
                    ["position"] = index + 1,
                    ["name"] = item.Name,
                    ["item"] = item.Url
                }).ToList()
            };
        }

        public static object FAQPage(List<(string Question, string Answer)> faqs)
        {
            return new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "FAQPage",
                ["mainEntity"] = faqs.Select(faq => new Dictionary<string, object?>
                {
                    ["@type"] = "Question",
                    ["name"] = faq.Question,
                    ["acceptedAnswer"] = new Dictionary<string, object?>
                    {
                        ["@type"] = "Answer",
                        ["text"] = StripHtml(faq.Answer)
                    }
                }).ToList()
            };
        }

        public static string AbsoluteImageUrl(string siteUrl, string? imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return $"{siteUrl.TrimEnd('/')}{SchemaDefaults.DefaultImagePath}";

            if (imageName.StartsWith("http://") || imageName.StartsWith("https://"))
                return imageName;

            return $"{siteUrl.TrimEnd('/')}/img/{imageName.TrimStart('/')}";
        }

        private static string StripHtml(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            var text = Regex.Replace(input, "<.*?>", string.Empty);

            text = text
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Replace("&nbsp;", " ")
                .Replace("&amp;", "&")
                .Replace("&quot;", "\"")
                .Replace("&#39;", "'")
                .Trim();

            return Regex.Replace(text, @"\s+", " ");
        }
    }
}