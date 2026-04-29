using System.ComponentModel.DataAnnotations;

namespace ProEstetik.Web.Entities
{
    public class Service
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Lütfen bir başlık giriniz.")]
        public string Title { get; set; }
        [Display(Name = "Anasayfa Başlık")]
        [Required(ErrorMessage = "Lütfen bir başlık giriniz.")]
        public string HomeTitle { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Lütfen bir açıklama giriniz.")]
        public string Description { get; set; }
        [Display(Name = " Kısa Açıklama")]
        [Required(ErrorMessage = "Lütfen bir açıklama giriniz.")]
        public string ShortDescription { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Anasayfa Resmi")]
        public string? Image2 { get; set; }
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
