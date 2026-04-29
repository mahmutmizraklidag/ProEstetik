


using Microsoft.AspNetCore.Http;


    public class CookieHelper 
    {
        private HttpContext _context;
        public CookieHelper(IHttpContextAccessor httpContextAccessor)        
        {
            _context = httpContextAccessor.HttpContext;
        }
        public string GetCookie(string key)
        {
            if(_context.Request.Cookies.TryGetValue(key, out string cookieValue))
            {
                return cookieValue;
            }
            return string.Empty;
            
        }

        public Task SetCookieAsync(string key, string value)
        {
            var options = new CookieOptions
            {
                // Opsiyonel olarak ek özellikler ekleyebilirsiniz
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = false,
                Secure = true,      
                SameSite = SameSiteMode.None,
            };

            // Cookie'yi tarayıcıya ekleyin
            _context.Response.Cookies.Append(key, value, options);

            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key)
        {
            _context.Response.Cookies.Delete(key);
            return Task.CompletedTask;
        }
    }

