using System.ComponentModel.DataAnnotations;

namespace ProEstetik.Web.Entities
{
    public enum Language
    {
        [Display(Name = "Türkçe")]
        TR = 0,

        [Display(Name = "English")]
        EN = 1
    }
}
