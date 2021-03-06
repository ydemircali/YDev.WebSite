﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YDev.Admin.Models.Login;
using YDev.Common.Models;
using YDev.Common.Helper;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && HttpContext.Session.GetInt32("UserId") != 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Index([FromBody] LoginUser loginModel, string returnUrl)
        {
            AjaxResult result = new AjaxResult();

            if (string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
            {
                result.IsSuccess = false;
                result.Message = "Email veya şifre boş olmamalıdır.";
            }
            else
            {
                if (await LoginCheckAsync(loginModel.Email, loginModel.Password))
                {
                    result.IsSuccess = true;
                    result.Message = "Giriş başarılı";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Email veya şifre hatalı.";
                }
            }

            return Json(result);
        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.Clear();
            
            return RedirectToAction("Index","Login");
        }

        private async Task<bool> LoginCheckAsync(string email, string password)
        {
            User userInfo =  await _userService.FindUser(email, password);

            if (userInfo != null && userInfo.Id != 0)
            {
                var claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name,
                              userInfo.Email,
                              userInfo.Role.RoleName) 
                };

                var userIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddHours(1)
                    });

                HttpContext.Session.SetString("UserName",userInfo.Name + " "+ userInfo.SurName);
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(userInfo.Id));
                HttpContext.Session.SetString("ImagePath", string.IsNullOrEmpty(userInfo.ImagePath) 
                    ? "../assets/layouts/layout4/img/avatar.png" 
                    : userInfo.ImagePath);

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}