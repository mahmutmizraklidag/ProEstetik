namespace ProEstetik.Web.Services
{
    public static class HreflangGenerator
    {
        public static string GenerateBasic(string siteUrl, string currentPath)
        {
            siteUrl = siteUrl.TrimEnd('/');

            if (string.IsNullOrWhiteSpace(currentPath))
                currentPath = "/";

            currentPath = currentPath.TrimEnd('/');

            if (string.IsNullOrWhiteSpace(currentPath))
                currentPath = "/";

            var isEnglish = currentPath.Equals("/en", StringComparison.OrdinalIgnoreCase)
                            || currentPath.StartsWith("/en/", StringComparison.OrdinalIgnoreCase);

            var isGerman = currentPath.Equals("/de", StringComparison.OrdinalIgnoreCase)
                           || currentPath.StartsWith("/de/", StringComparison.OrdinalIgnoreCase);

            var isTurkish = !isEnglish && !isGerman;

            var trUrl = isTurkish
                ? $"{siteUrl}{NormalizePath(currentPath)}"
                : $"{siteUrl}/";

            var enUrl = isEnglish
                ? $"{siteUrl}{NormalizePath(currentPath)}"
                : $"{siteUrl}/en";

            var deUrl = isGerman
                ? $"{siteUrl}{NormalizePath(currentPath)}"
                : $"{siteUrl}/de";

            var defaultUrl = $"{siteUrl}/";

            return $"""
            <link rel="alternate" hreflang="tr" href="{trUrl}" />
            <link rel="alternate" hreflang="en" href="{enUrl}" />
            <link rel="alternate" hreflang="de" href="{deUrl}" />
            <link rel="alternate" hreflang="x-default" href="{defaultUrl}" />
            """;
        }

        private static string NormalizePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || path == "/")
                return "/";

            if (!path.StartsWith("/"))
                path = "/" + path;

            return path;
        }
    }
}