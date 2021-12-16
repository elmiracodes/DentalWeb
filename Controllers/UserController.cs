using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace DentalWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(UserLogin userInfo, string returnUrl = null)
        {

            //kontrollera användarnamn
            bool userOk = CheckUser(userInfo);
            if (userOk == true)
            {

                //Allt  stämmer, logga in användaren
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userInfo.UserName));

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                // SKicka användaren vidare till returUr1 om den finn anndars till startsidan
                if (returnUrl != null)
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Home", "Index");
            }

            ViewBag.ErrorMessage = "Lösenordet eller användarnamnet är felaktigt.";
            //Stanna på sidan användarnen är på
            return View();
        }

        private bool CheckUser(UserLogin userInfo)
        {
            //Kontrollera mot databas. t ex här bara hårdkodat

            if(userInfo.UserName == "usr" && userInfo.Password == "pwd")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
