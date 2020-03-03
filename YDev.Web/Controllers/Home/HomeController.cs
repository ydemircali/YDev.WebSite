using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;
using YDev.Web.Models;

namespace YDev.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuService;
        public HomeController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            ViewData["Menus"] = _menuService.GetMenus();
            MenuGroup menuGroup = _menuService.GetMenuGroup(1);

            ViewData["MenuObject"] = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
