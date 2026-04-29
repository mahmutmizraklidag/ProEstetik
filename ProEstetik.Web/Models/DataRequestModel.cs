using ProEstetik.Web.Entities;

namespace ProEstetik.Web.Models
{
    public static class DataRequestModel
    {
        public static SiteSetting SiteSetting { get; set; } = new SiteSetting();
        public static List<Service> Services { get; set; } = new List<Service>();
        public static List<Blog> Blogs { get; set; } = new List<Blog>();
        public static List<Slider> Sliders { get; set; } = new List<Slider>();
        public static List<Team> Teams { get; set; } = new List<Team>();
        public static void ClearData()
        {
            SiteSetting = null;
            Services = new List<Service>();
            Blogs = new List<Blog>();
            Sliders = new List<Slider>();
            Teams = new List<Team>();
        }
    }
}
