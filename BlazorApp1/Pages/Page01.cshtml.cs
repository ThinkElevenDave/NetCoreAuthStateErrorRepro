using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BlazorApp1.Pages
{
    public class Page01Model : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
			var authProperties = new AuthenticationProperties
			{
				IsPersistent = false
			};

			var claims = new List<Claim>() {
				new Claim(ClaimTypes.Role, "SuperUser"),
				new Claim(ClaimTypes.NameIdentifier, "12345") };

			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier, ClaimTypes.Role);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

			return LocalRedirect(Url.Content("~/Page02"));

		}
    }
}
