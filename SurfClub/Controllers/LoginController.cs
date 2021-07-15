using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurfClub.Models.ViewModels;
using SurfClub.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SurfClub.Controllers
{
    public class LoginController : Controller
    {
        private readonly SurfClubDbContext dbContext;
        public LoginController(SurfClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                // проверить, есть ли пользователь в базе
                var user= dbContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname && c.Password==model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль!");
                }
                else
                {
                    //авторизовать на сайте, что-то сделать
                    var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
            };

                    var authProp = new AuthenticationProperties();
                    // если стоит галка - запоминамем пользователя
                    if (model.RemoveName)
                    {
                        authProp.IsPersistent = true;
                        authProp.ExpiresUtc = DateTime.UtcNow.AddHours(2);
                    }

                    // создаем объект ClaimsIdentity
                    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    // установка аутентификационных куки
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(id), authProp);

                    HttpContext.Session.SetString("NickName", user.Nickname);
                    HttpContext.Session.SetString("Photo", user.Photo.ToString());
                    HttpContext.Session.SetInt32("UserId", user.Id);

                    return RedirectToAction("Index", "Feed");
                }
            }

            return View("Index", model);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Feed");
        }

    }
}
