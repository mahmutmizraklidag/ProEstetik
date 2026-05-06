using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProEstetik.Web.Data;
using ProEstetik.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Admin/Login";
    x.AccessDeniedPath = "/AccessDenied";
    x.LogoutPath = "/Admin/Logout";
    x.Cookie.Name = "Admin";
    x.Cookie.MaxAge = TimeSpan.FromDays(1);
    x.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use((context, next) =>
{
    var dbcontext = context.RequestServices.GetRequiredService<DatabaseContext>();
    DataRequestModel.ClearData();

    var lang = context.Request.Path.StartsWithSegments("/en") ? "En" : "Tr";

    DataRequestModel.SiteSetting = dbcontext.SiteSettings.FirstOrDefault(x => x.Language.ToString() == lang);
    DataRequestModel.Services = dbcontext.Services.Where(x => x.Language.ToString() == lang).ToList();
    DataRequestModel.Blogs = dbcontext.Blogs.Where(x => x.Language.ToString() == lang)
                .OrderByDescending(x => x.CreatedAt).Take(10).ToList();
    DataRequestModel.Sliders = dbcontext.Sliders.Where(x => x.Language.ToString() == lang).ToList();
    DataRequestModel.Teams = dbcontext.Teams.Where(x => x.Language.ToString() == lang).ToList();

    return next.Invoke(context);
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/Home/NotFound");
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=EnHome}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapFallbackToController("NotFound", "Home");
app.Run();
