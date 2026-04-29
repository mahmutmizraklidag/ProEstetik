using System.ComponentModel.DataAnnotations;

namespace ProEstetik.Web.Entities
{
    public class SiteSetting
    {
        public int Id { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "WhatsApp")]
        public string? WhatsApp { get; set; }
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Youtube { get; set; }
        [Display(Name = "Meta-Keywords")]
        public string? Keywords { get; set; }
        [Display(Name = "Meta-Description")]
        public string? MetaDescription { get; set; }
        [Display(Name = "Meta-Title")]
        public string? MetaTitle { get; set; }
        [Display(Name = "Dil")]
        [Required(ErrorMessage = "Lütfen bir dil seçiniz.")]
        public Language Language { get; set; }
    }
}
