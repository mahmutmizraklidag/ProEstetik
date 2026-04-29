namespace ProEstetik.Web.Services
{
    public static class SchemaDefaults
    {
        public const string ClinicNameTr = "Pro Estetik";
        public const string ClinicNameEn = "Pro Estetik";

        public const string Phone = "+90 000 000 00 00";
        public const string Email = "info@proestetik.com";

        public const string AddressTr = " Kazımdirik mah., 375. Sk. No:16/A";
        public const string AddressEn = " Kazımdirik mah., 375. Sk. No:16/A";

        public const string City = "İzmir";
        public const string District = "Bornova";
        public const string PostalCode = "35100";
        public const string CountryCode = "TR";

        public const string LogoPath = "/img/logo-new.png";
        public const string DefaultImagePath = "/img/logo-new.png";

        public const string InstagramUrl = "https://www.instagram.com/proestetik";
        public const string FacebookUrl = "https://www.facebook.com/proestetik";

        public static List<string> SameAs => new()
        {
            InstagramUrl,
            FacebookUrl
        };
    }
}