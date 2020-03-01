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
            if (User.Identity.IsAuthenticated && UserInformation.Id != 0)
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

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            UserInformation.Id = 0;    
            
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

                UserInformation.Id = userInfo.Id;
                UserInformation.Address = userInfo.Address;
                UserInformation.Email = userInfo.Email;
                UserInformation.ImagePath = userInfo.ImagePath;
                UserInformation.Name = userInfo.Name;
                UserInformation.SurName = userInfo.SurName;
                UserInformation.Role = userInfo.Role;
                UserInformation.Phone = userInfo.Phone;
                UserInformation.Status = userInfo.Status;
                UserInformation.Title = userInfo.Title;
                UserInformation.UserName = userInfo.UserName;

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}