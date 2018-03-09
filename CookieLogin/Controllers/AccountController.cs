using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using CookieLogin.Models;

namespace CookieLogin.Controllers
{


    public class AccountController : Controller
    {


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.UserName == "123" && model.PassWord == "123")
            {
                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name,model.UserName),
                };

                var claimsIdentity = new ClaimsIdentity(
                 claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //验证登陆通过，解绑[Authorize] 授权,授权通过
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        //IsPersistent = true,
                        //ExpiresUtc = DateTime.UtcNow.AddSeconds(60)
                    }
                    );
                return Redirect("/home/index");  //重定向到home主页
            }
            else
            {
                ModelState.AddModelError(string.Empty, "非法登陆.");
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            // 退出验证登陆，绑定[Authorize] 授权,授权不能通过
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");  //重定向到登陆页面
        }
    }
}