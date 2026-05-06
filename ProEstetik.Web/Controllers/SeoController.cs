using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace ProEstetik.Web.Controllers
{
    [ApiController]
    public class SeoController : ControllerBase
    {
        private const string BaseUrl = "https://www.proestetik.com.tr";
        private const string BrandName = "İzmir Pro Estetik Diş Kliniği";
        private const string BrandNameEn = "Izmir Pro Aesthetic Dental Clinic";
        private const string PhoneTr = "+90 232 463 4747";
        private const string PhoneInternational = "+90 530 996 1599";
        private const string Email = "info@proestetik.com.tr";
        private const string Address = "Kazım Dirik Mah. 375 Sk. No: 16/A Bornova İzmir / Türkiye";
        private const string LastModified = "2026-05-06";

        [HttpGet("robots.txt")]
        public IActionResult RobotsTxt()
        {
            var content = $"""
User-agent: *
Allow: /

# Yönetim ve sistem sayfaları arama motorlarına kapalı olsun.
Disallow: /admin
Disallow: /Admin
Disallow: /Account/Login
Disallow: /Account/Register
Disallow: /Identity

Sitemap: {BaseUrl}/sitemap.xml
""";

            return Text(content);
        }

        [HttpGet("llms.txt")]
        public IActionResult LlmsTxt()
        {
            var content = $"""
# {BrandName}

> {BrandName}, İzmir Bornova'da hizmet veren ağız ve diş sağlığı kliniğidir. Klinik; estetik diş hekimliği, implant, zirkonyum kaplama, Hollywood Smile, ortodonti, bonding, gummy smile, diş köprüsü, diş kuronu ve kaplama hizmetleri sunar.

## Ana Bilgiler

- Marka: {BrandName}
- İngilizce marka adı: {BrandNameEn}
- Web sitesi: {BaseUrl}
- Telefon: {PhoneTr}
- Uluslararası hasta hattı: {PhoneInternational}
- E-posta: {Email}
- Adres: {Address}
- Kuruluş: 2011
- Kurucu: Doç. Dr. M. Selim Bilgin

## Önemli Sayfalar

- Ana Sayfa: {BaseUrl}/
- Hakkımızda: {BaseUrl}/hakkimizda
- Ekip: {BaseUrl}/ekip
- Hizmetler: {BaseUrl}/hizmetler
- Blog: {BaseUrl}/blog
- İletişim: {BaseUrl}/iletisim

## Ana Hizmetler

- Diş İmplantı: {BaseUrl}/hizmetler/dis-implanti
- Hollywood Smile: {BaseUrl}/hizmetler/hollywood-smile
- Zirkonyum Kaplama: {BaseUrl}/hizmetler/zirkonyum-kaplama
- Ortodonti: {BaseUrl}/hizmetler/ortodonti
- Gummy Smile: {BaseUrl}/hizmetler/gummy-smile
- Diş Köprüsü: {BaseUrl}/hizmetler/dis-koprusu
- Bonding: {BaseUrl}/hizmetler/bonding
- Diş Kuronu: {BaseUrl}/hizmetler/dis-kuronu
- Kaplama: {BaseUrl}/hizmetler/kaplama

## İngilizce Sayfalar

- Home: {BaseUrl}/en
- About Us: {BaseUrl}/en/about-us
- Team: {BaseUrl}/en/team
- Services: {BaseUrl}/en/services
- Blog: {BaseUrl}/en/blog
- Contact: {BaseUrl}/en/contact
- Dental Implants: {BaseUrl}/en/services/dental-implants
- Hollywood Smile: {BaseUrl}/en/services/hollywood-smile
- Zirconium Veneers: {BaseUrl}/en/services/zirconium-veneers
- Orthodontics: {BaseUrl}/en/services/Orthodontics
- Gummy Smile: {BaseUrl}/en/services/gummy-smile
- Dental Bridge: {BaseUrl}/en/services/dental-bridge
- Bonding: {BaseUrl}/en/services/bonding
- Dental Crowns: {BaseUrl}/en/services/dental-crowns

## Yapay Zeka İçin Sade İçerikler

- Pro Estetik Özeti: {BaseUrl}/ai/pro-estetik.md
- Hizmetler Özeti: {BaseUrl}/ai/hizmetler.md
- İletişim Özeti: {BaseUrl}/ai/iletisim.md
- English Summary: {BaseUrl}/ai/en/pro-aesthetic.md

## Site Haritası

- Sitemap: {BaseUrl}/sitemap.xml
- Full LLM Context: {BaseUrl}/llms-full.txt
""";

            return Text(content);
        }

        [HttpGet("llms-full.txt")]
        public IActionResult LlmsFullTxt()
        {
            var content = $"""
# {BrandName} - Full AI Context

## Klinik Tanımı

{BrandName}, İzmir Bornova'da konumlanan, yerel ve uluslararası hastalara ağız ve diş sağlığı hizmetleri sunan bir diş kliniğidir. Klinik, estetik diş hekimliği, implantoloji, zirkonyum kaplama, Hollywood Smile, ortodonti, gummy smile tedavileri, bonding, diş köprüsü, diş kuronu ve kaplama alanlarında hizmet verir.

## Marka Bilgileri

- Resmi ad: {BrandName}
- İngilizce ad: {BrandNameEn}
- Kuruluş yılı: 2011
- Kurucu: Doç. Dr. M. Selim Bilgin
- Konum: Bornova, İzmir, Türkiye
- Telefon: {PhoneTr}
- Uluslararası telefon: {PhoneInternational}
- E-posta: {Email}
- Adres: {Address}

## Klinik Yaklaşımı

Pro Estetik; modern, hijyenik ve teknolojik ekipmanlarla donatılmış bir klinik ortamında, hastanın ağız yapısına ve estetik beklentilerine göre kişiselleştirilmiş tedavi planları oluşturur. Uluslararası hastalar için iletişim ve yönlendirme süreçleri de desteklenir.

## Ekip

- Doç. Dr. M. Selim Bilgin
- Dr. Pınar Nohut
- Dr. Ramazan Akgün
- Prof. Dr. Törün Özer

## Hizmetler

### Diş İmplantı

Eksik dişlerin fonksiyonel ve estetik olarak tamamlanması için implant tedavileri uygulanır. Tek diş implantı, çoklu implant uygulamaları, All-on-4 ve All-on-6 gibi tedavi seçenekleri hastanın ağız yapısına göre planlanır.

URL: {BaseUrl}/hizmetler/dis-implanti

### Hollywood Smile

Dişlerin şekil, boyut, renk ve dizilim açısından daha estetik görünmesini hedefleyen gülüş tasarımı uygulamasıdır. Zirkonyum, lamine, diş beyazlatma, implant, ortodonti ve diş eti tedavileriyle birlikte planlanabilir.

URL: {BaseUrl}/hizmetler/hollywood-smile

### Zirkonyum Kaplama

Doğal görünüme yakın, metal içermeyen, ışık geçirgenliği ve dayanıklılığıyla öne çıkan estetik diş kaplama tedavisidir. Diş renginden, formundan veya eski restorasyonlarından memnun olmayan hastalar için tercih edilir.

URL: {BaseUrl}/hizmetler/zirkonyum-kaplama

### Ortodonti

Çapraşık dişler, boşluklar, kapanış problemleri ve diş dizilimi sorunları için diş teli veya şeffaf plak gibi ortodontik çözümler planlanır.

URL: {BaseUrl}/hizmetler/ortodonti

### Gummy Smile

Gülümseme sırasında diş etinin normalden fazla görünmesi durumunda uygulanan estetik tedavileri kapsar. Kuron boyu uzatma, gingivektomi, botulinum toksin enjeksiyonu, ortodonti veya cerrahi seçenekler değerlendirilebilir.

URL: {BaseUrl}/hizmetler/gummy-smile

### Diş Köprüsü

Eksik diş boşluğunu kapatmak ve çiğneme fonksiyonunu yeniden sağlamak için uygulanan sabit protetik tedavidir.

URL: {BaseUrl}/hizmetler/dis-koprusu

### Bonding

Dişler arasındaki boşluk, renk eşitsizliği, küçük kırıklar veya şekil bozuklukları için diş renginde kompozit materyalle yapılan estetik uygulamadır.

URL: {BaseUrl}/hizmetler/bonding

### Diş Kuronu

Kırık, çürük, kanal tedavili veya zayıflamış dişlerin dayanıklılığını ve görünümünü artırmak için dişin üzerine yerleştirilen kaplama tedavisidir.

URL: {BaseUrl}/hizmetler/dis-kuronu

### Kaplama

Inley-onley, porselen, kompozit ve lamine veneer gibi restoratif ve estetik kaplama uygulamalarını kapsar.

URL: {BaseUrl}/hizmetler/kaplama

## Sık Aranan Konular

- İzmir diş kliniği
- İzmir implant tedavisi
- İzmir zirkonyum kaplama
- İzmir Hollywood Smile
- İzmir gülüş tasarımı
- İzmir ortodonti
- İzmir bonding
- Bornova diş kliniği
- Estetik diş hekimliği İzmir
- Uluslararası hasta diş tedavisi İzmir

## İletişim

Pro Estetik Diş Kliniği ile iletişime geçmek için:

- Telefon: {PhoneTr}
- Uluslararası telefon: {PhoneInternational}
- E-posta: {Email}
- Adres: {Address}
- İletişim sayfası: {BaseUrl}/iletisim
- İngilizce iletişim: {BaseUrl}/en/contact

## Önemli URL'ler

- {BaseUrl}/
- {BaseUrl}/hakkimizda
- {BaseUrl}/ekip
- {BaseUrl}/hizmetler
- {BaseUrl}/blog
- {BaseUrl}/iletisim
- {BaseUrl}/sitemap.xml
- {BaseUrl}/robots.txt
- {BaseUrl}/llms.txt
""";

            return Text(content);
        }

        [HttpGet("ai/pro-estetik.md")]
        public IActionResult ProEstetikMarkdown()
        {
            var content = $"""
# {BrandName}

{BrandName}, İzmir Bornova'da hizmet veren ağız ve diş sağlığı kliniğidir. Klinik, 2011 yılında Doç. Dr. M. Selim Bilgin tarafından kurulmuştur.

## Hizmet Alanları

- Diş implantı
- Hollywood Smile
- Zirkonyum kaplama
- Ortodonti
- Gummy Smile
- Diş köprüsü
- Bonding
- Diş kuronu
- Kaplama

## Klinik Bilgileri

- Adres: {Address}
- Telefon: {PhoneTr}
- E-posta: {Email}
- Web: {BaseUrl}

## Neden Pro Estetik?

Pro Estetik; uzman diş hekimi kadrosu, modern klinik ortamı, hijyenik tedavi alanları ve kişiye özel tedavi planlarıyla estetik ve fonksiyonel diş tedavileri sunar.

## Önemli Linkler

- Ana Sayfa: {BaseUrl}/
- Hakkımızda: {BaseUrl}/hakkimizda
- Hizmetler: {BaseUrl}/hizmetler
- Blog: {BaseUrl}/blog
- İletişim: {BaseUrl}/iletisim
""";

            return Markdown(content);
        }

        [HttpGet("ai/hizmetler.md")]
        public IActionResult HizmetlerMarkdown()
        {
            var content = $"""
# Pro Estetik Hizmetleri

## Diş İmplantı

Eksik dişlerin yerine doğal diş kökünü taklit eden implant uygulamaları yapılır.

URL: {BaseUrl}/hizmetler/dis-implanti

## Hollywood Smile

Dişlerin renk, form, boyut ve dizilim açısından daha estetik hale getirilmesini hedefleyen gülüş tasarımı uygulamasıdır.

URL: {BaseUrl}/hizmetler/hollywood-smile

## Zirkonyum Kaplama

Metal içermeyen, doğal görünümlü ve dayanıklı estetik kaplama tedavisidir.

URL: {BaseUrl}/hizmetler/zirkonyum-kaplama

## Ortodonti

Diş dizilimi, çapraşıklık ve kapanış problemleri için ortodontik tedaviler uygulanır.

URL: {BaseUrl}/hizmetler/ortodonti

## Gummy Smile

Gülümserken diş etinin fazla görünmesi durumuna yönelik estetik tedaviler planlanır.

URL: {BaseUrl}/hizmetler/gummy-smile

## Diş Köprüsü

Eksik diş boşluklarının sabit protetik yöntemlerle tamamlanmasını sağlar.

URL: {BaseUrl}/hizmetler/dis-koprusu

## Bonding

Küçük şekil bozuklukları, renk eşitsizlikleri, çatlaklar ve diş arası boşluklar için kompozit materyalle yapılan estetik uygulamadır.

URL: {BaseUrl}/hizmetler/bonding

## Diş Kuronu

Hasarlı, kırık veya çürük dişlerin korunması ve estetik görünümünün artırılması için uygulanan kaplama tedavisidir.

URL: {BaseUrl}/hizmetler/dis-kuronu

## Kaplama

Inley-onley, porselen, kompozit ve lamine veneer gibi estetik ve restoratif kaplama seçeneklerini kapsar.

URL: {BaseUrl}/hizmetler/kaplama
""";

            return Markdown(content);
        }

        [HttpGet("ai/iletisim.md")]
        public IActionResult IletisimMarkdown()
        {
            var content = $"""
# Pro Estetik İletişim

## Klinik

{BrandName}

## Adres

{Address}

## Telefon

{PhoneTr}

## Uluslararası Hasta Hattı

{PhoneInternational}

## E-posta

{Email}

## Web Sitesi

{BaseUrl}

## İletişim Sayfası

{BaseUrl}/iletisim

## İngilizce İletişim Sayfası

{BaseUrl}/en/contact
""";

            return Markdown(content);
        }

        [HttpGet("ai/en/pro-aesthetic.md")]
        public IActionResult ProAestheticEnglishMarkdown()
        {
            var content = $"""
# {BrandNameEn}

{BrandNameEn} is a dental clinic located in Bornova, Izmir, Türkiye. The clinic provides dental aesthetics, implant dentistry, zirconium veneers, Hollywood Smile, orthodontics, bonding, gummy smile treatment, dental bridges and dental crowns.

## Main Services

- Dental Implants
- Hollywood Smile
- Zirconium Veneers
- Orthodontics
- Gummy Smile
- Dental Bridge
- Bonding
- Dental Crowns

## Contact

- Address: {Address}
- Phone: {PhoneInternational}
- Email: {Email}
- Website: {BaseUrl}
- Contact Page: {BaseUrl}/en/contact

## Important Pages

- Home: {BaseUrl}/en
- About Us: {BaseUrl}/en/about-us
- Team: {BaseUrl}/en/team
- Services: {BaseUrl}/en/services
- Blog: {BaseUrl}/en/blog
- Contact: {BaseUrl}/en/contact
""";

            return Markdown(content);
        }

        [HttpGet("sitemap.xml")]
        public IActionResult SitemapXml()
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XNamespace xhtml = "http://www.w3.org/1999/xhtml";

            var pages = GetSitemapPages();

            var document = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "xhtml", xhtml),
                    pages.Select(page =>
                    {
                        var url = new XElement(ns + "url",
                            new XElement(ns + "loc", page.Url),
                            new XElement(ns + "lastmod", page.LastModified),
                            new XElement(ns + "changefreq", page.ChangeFreq),
                            new XElement(ns + "priority", page.Priority)
                        );

                        foreach (var alternate in page.Alternates)
                        {
                            url.Add(new XElement(xhtml + "link",
                                new XAttribute("rel", "alternate"),
                                new XAttribute("hreflang", alternate.Key),
                                new XAttribute("href", alternate.Value)
                            ));
                        }

                        if (!string.IsNullOrWhiteSpace(page.DefaultAlternate))
                        {
                            url.Add(new XElement(xhtml + "link",
                                new XAttribute("rel", "alternate"),
                                new XAttribute("hreflang", "x-default"),
                                new XAttribute("href", page.DefaultAlternate)
                            ));
                        }

                        return url;
                    })
                )
            );

            return Content(document.ToString(), "application/xml; charset=utf-8", Encoding.UTF8);
        }

        private static List<SitemapPage> GetSitemapPages()
        {
            return new List<SitemapPage>
            {
                new($"{BaseUrl}/", "daily", "1.0", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/",
                    ["en"] = $"{BaseUrl}/en"
                }, $"{BaseUrl}/"),

                new($"{BaseUrl}/hakkimizda", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hakkimizda",
                    ["en"] = $"{BaseUrl}/en/about-us"
                }, $"{BaseUrl}/hakkimizda"),

                new($"{BaseUrl}/ekip", "monthly", "0.7", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/ekip",
                    ["en"] = $"{BaseUrl}/en/team"
                }, $"{BaseUrl}/ekip"),

                new($"{BaseUrl}/hizmetler", "weekly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler",
                    ["en"] = $"{BaseUrl}/en/services"
                }, $"{BaseUrl}/hizmetler"),

                new($"{BaseUrl}/blog", "daily", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/blog",
                    ["en"] = $"{BaseUrl}/en/blog"
                }, $"{BaseUrl}/blog"),

                new($"{BaseUrl}/iletisim", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/iletisim",
                    ["en"] = $"{BaseUrl}/en/contact"
                }, $"{BaseUrl}/iletisim"),

                new($"{BaseUrl}/hizmetler/dis-implanti", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-implanti",
                    ["en"] = $"{BaseUrl}/en/services/dental-implants"
                }, $"{BaseUrl}/hizmetler/dis-implanti"),

                new($"{BaseUrl}/hizmetler/hollywood-smile", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/hollywood-smile",
                    ["en"] = $"{BaseUrl}/en/services/hollywood-smile"
                }, $"{BaseUrl}/hizmetler/hollywood-smile"),

                new($"{BaseUrl}/hizmetler/zirkonyum-kaplama", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/zirkonyum-kaplama",
                    ["en"] = $"{BaseUrl}/en/services/zirconium-veneers"
                }, $"{BaseUrl}/hizmetler/zirkonyum-kaplama"),

                new($"{BaseUrl}/hizmetler/ortodonti", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/ortodonti",
                    ["en"] = $"{BaseUrl}/en/services/Orthodontics"
                }, $"{BaseUrl}/hizmetler/ortodonti"),

                new($"{BaseUrl}/hizmetler/gummy-smile", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/gummy-smile",
                    ["en"] = $"{BaseUrl}/en/services/gummy-smile"
                }, $"{BaseUrl}/hizmetler/gummy-smile"),

                new($"{BaseUrl}/hizmetler/dis-koprusu", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-koprusu",
                    ["en"] = $"{BaseUrl}/en/services/dental-bridge"
                }, $"{BaseUrl}/hizmetler/dis-koprusu"),

                new($"{BaseUrl}/hizmetler/bonding", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/bonding",
                    ["en"] = $"{BaseUrl}/en/services/bonding"
                }, $"{BaseUrl}/hizmetler/bonding"),

                new($"{BaseUrl}/hizmetler/dis-kuronu", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-kuronu",
                    ["en"] = $"{BaseUrl}/en/services/dental-crowns"
                }, $"{BaseUrl}/hizmetler/dis-kuronu"),

                new($"{BaseUrl}/hizmetler/kaplama", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/kaplama"
                }, $"{BaseUrl}/hizmetler/kaplama"),

                new($"{BaseUrl}/en", "daily", "1.0", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/",
                    ["en"] = $"{BaseUrl}/en"
                }, $"{BaseUrl}/"),

                new($"{BaseUrl}/en/about-us", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hakkimizda",
                    ["en"] = $"{BaseUrl}/en/about-us"
                }, $"{BaseUrl}/hakkimizda"),

                new($"{BaseUrl}/en/team", "monthly", "0.7", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/ekip",
                    ["en"] = $"{BaseUrl}/en/team"
                }, $"{BaseUrl}/ekip"),

                new($"{BaseUrl}/en/services", "weekly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler",
                    ["en"] = $"{BaseUrl}/en/services"
                }, $"{BaseUrl}/hizmetler"),

                new($"{BaseUrl}/en/contact", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/iletisim",
                    ["en"] = $"{BaseUrl}/en/contact"
                }, $"{BaseUrl}/iletisim"),

                new($"{BaseUrl}/en/services/dental-implants", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-implanti",
                    ["en"] = $"{BaseUrl}/en/services/dental-implants"
                }, $"{BaseUrl}/hizmetler/dis-implanti"),

                new($"{BaseUrl}/en/services/hollywood-smile", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/hollywood-smile",
                    ["en"] = $"{BaseUrl}/en/services/hollywood-smile"
                }, $"{BaseUrl}/hizmetler/hollywood-smile"),

                new($"{BaseUrl}/en/services/zirconium-veneers", "monthly", "0.9", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/zirkonyum-kaplama",
                    ["en"] = $"{BaseUrl}/en/services/zirconium-veneers"
                }, $"{BaseUrl}/hizmetler/zirkonyum-kaplama"),

                new($"{BaseUrl}/en/services/Orthodontics", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/ortodonti",
                    ["en"] = $"{BaseUrl}/en/services/Orthodontics"
                }, $"{BaseUrl}/hizmetler/ortodonti"),

                new($"{BaseUrl}/en/services/gummy-smile", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/gummy-smile",
                    ["en"] = $"{BaseUrl}/en/services/gummy-smile"
                }, $"{BaseUrl}/hizmetler/gummy-smile"),

                new($"{BaseUrl}/en/services/dental-bridge", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-koprusu",
                    ["en"] = $"{BaseUrl}/en/services/dental-bridge"
                }, $"{BaseUrl}/hizmetler/dis-koprusu"),

                new($"{BaseUrl}/en/services/bonding", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/bonding",
                    ["en"] = $"{BaseUrl}/en/services/bonding"
                }, $"{BaseUrl}/hizmetler/bonding"),

                new($"{BaseUrl}/en/services/dental-crowns", "monthly", "0.8", LastModified, new Dictionary<string, string>
                {
                    ["tr"] = $"{BaseUrl}/hizmetler/dis-kuronu",
                    ["en"] = $"{BaseUrl}/en/services/dental-crowns"
                }, $"{BaseUrl}/hizmetler/dis-kuronu"),

                new($"{BaseUrl}/llms.txt", "monthly", "0.5", LastModified),
                new($"{BaseUrl}/llms-full.txt", "monthly", "0.5", LastModified),
                new($"{BaseUrl}/ai/pro-estetik.md", "monthly", "0.5", LastModified),
                new($"{BaseUrl}/ai/hizmetler.md", "monthly", "0.5", LastModified),
                new($"{BaseUrl}/ai/iletisim.md", "monthly", "0.5", LastModified),
                new($"{BaseUrl}/ai/en/pro-aesthetic.md", "monthly", "0.5", LastModified)
            };
        }

        private IActionResult Text(string content)
        {
            return Content(content, "text/plain; charset=utf-8", Encoding.UTF8);
        }

        private IActionResult Markdown(string content)
        {
            return Content(content, "text/markdown; charset=utf-8", Encoding.UTF8);
        }

        private sealed class SitemapPage
        {
            public string Url { get; }
            public string ChangeFreq { get; }
            public string Priority { get; }
            public string LastModified { get; }
            public Dictionary<string, string> Alternates { get; }
            public string? DefaultAlternate { get; }

            public SitemapPage(
                string url,
                string changeFreq,
                string priority,
                string lastModified,
                Dictionary<string, string>? alternates = null,
                string? defaultAlternate = null)
            {
                Url = url;
                ChangeFreq = changeFreq;
                Priority = priority;
                LastModified = lastModified;
                Alternates = alternates ?? new Dictionary<string, string>();
                DefaultAlternate = defaultAlternate;
            }
        }
    }
}