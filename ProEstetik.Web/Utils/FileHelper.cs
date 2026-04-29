namespace ProEstetik.Web.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/wwwroot/image/")
        {
            string fileName = ""; //yüklenecek dosya adı için değişken oluşturduk.
            fileName = formFile.FileName; //oluşturduğumuz değişkene yüklenecek dosya adını aktardık
            string directory = Directory.GetCurrentDirectory() + filePath + fileName; //dosyanın yükleneceği dizin.(GetCurrentDirectory metodu uygulamanın çalıştığı fiziksel yolu getirir)
            using var stream = new FileStream(directory, FileMode.Create); //dosya yükleme için gerekli bir dosya akış nesnesi oluşturup sınıfa yükleme yapacağımız dizini (directory) ve yükleme tipimizi(yeni dosya oluşturma) belirtik
            await formFile.CopyToAsync(stream); //yukarıdaki ayarlarla dosyamızı asenkron bir şekilde sunucuya yükledik.
            return fileName; //bu metodun kullanacağı yere yüklenen dosya adını geri gönderdik.
        }
    }
}
