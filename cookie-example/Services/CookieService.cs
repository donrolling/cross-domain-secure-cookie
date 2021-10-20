using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;

namespace cookie_example.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataProtector _protector;

        public CookieService(IHttpContextAccessor httpContextAccessor, IDataProtector protector)
        {
            _httpContextAccessor = httpContextAccessor;
            _protector = protector;
        }

        public void SetCookie<T>(string name, T data)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{ nameof(name) } parameter was null or empty.");
            }
            if (data == null)
            {
                throw new ArgumentNullException($"{ nameof(data) } parameter was null or empty.");
            }
            var jsonString = JsonSerializer.Serialize(data);
            var protectedJsonString = _protector.Protect(jsonString);
            var options = new CookieOptions
            {
                // HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.Now.AddMinutes(30)
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(name, protectedJsonString, options);
        }

        public T GetCookie<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{ nameof(name) } parameter was null or empty.");
            }
            var protectedCookieValue = _httpContextAccessor.HttpContext.Request.Cookies[name];
            if (protectedCookieValue == null)
            {
                return default(T);
            }
            var cookieValue = _protector.Unprotect(protectedCookieValue);
            var data = JsonSerializer.Deserialize<T>(cookieValue);
            return data;
        }
    }
}