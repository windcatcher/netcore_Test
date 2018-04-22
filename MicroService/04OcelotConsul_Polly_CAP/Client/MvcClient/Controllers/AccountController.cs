using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcClient.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult SingIn(string returnUrl)
        {
            var usr = User as ClaimsPrincipal;

            var token = HttpContext.GetTokenAsync("access_token");
            if (token != null)
            {
                ViewData["access_token"] = token;
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}