using System.ComponentModel.DataAnnotations;

namespace ProEstetik.Web.Entities
{
    public class Team
    {
        public int Id { get; set; }
        [Display(Name = "İsim Soyisim")]
        [Required(ErrorMessage = "Lütfen bir isim giriniz.")]
        public string Name { get; set; }
        [Display(Name = "Pozisyon")]
        [Required(ErrorMessage = "Lütfen bir pozisyon giriniz.")]
        public string Position { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Lütfen bir açıklama giriniz.")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "Lütfen bir slug giriniz.")]
        public string Slug { get; set; }
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
