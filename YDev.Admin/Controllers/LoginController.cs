using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDev.Admin.Models;
using YDev.Admin.Models.Login;
using YDev.Common.Models;
using YDev.Service.UserService;

namespace YDev.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : AdminController
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
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
                    loginModel = new LoginUser();
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

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            UserInformation = new User();

            return RedirectToAction("Login");
        }

        private async Task<bool> LoginCheckAsync(string email, string password)
        {
            UserInformation =  await _userService.FindUser(email, password);

            if (UserInformation != null && UserInformation.Id != 0)
            {
                var claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, UserInformation.Email, UserInformation.Role.RoleName) 
                };

                var userIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                    , principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddSeconds(30)
                    });

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}