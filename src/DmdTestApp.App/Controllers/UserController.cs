using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DmdTestApp.App.Controllers
{

    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet("login/{username}")]
        public async Task<IActionResult> Login(string username)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username)
            };

            foreach (var item in HttpContext.Request.Query)
            {
                claims.Add(new Claim(item.Key, item.Value.ToString()));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal);

            return LocalRedirect("/");
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return LocalRedirect("/");
        }
    }
}
