using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace OfficeManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class CultureController : Controller
    {
        public IActionResult SetCulture(string culture, string redirectUri)
        {
            if (culture != null)
            {
                var requestCulture = new RequestCulture(culture);
                var cookieName = CookieRequestCultureProvider.DefaultCookieName;
                var cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
                HttpContext.Response.Cookies.Append(cookieName, cookieValue);
            }
            return LocalRedirect(redirectUri);
        }
    }
}
