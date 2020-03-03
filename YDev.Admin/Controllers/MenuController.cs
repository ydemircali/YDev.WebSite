using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YDev.Common.Models;
using YDev.Common.Helper;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        public IActionResult Index()
        {
            ViewData["Nav"] = "menu";
            ViewData["Menus"] = _menuService.GetMenus();
            MenuGroup menuGroup = _menuService.GetMenuGroup(1);

            ViewData["MenuObject"] = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);
            
            return View();
        }

        [HttpPost]
        [Route("MenuKaydet")]
        public async Task<JsonResult> Kaydet([FromBody] List<MenuObject> menuObjects)
        {
            AjaxResult result = new AjaxResult();

            if (menuObjects == null)
            {
                result.IsSuccess = false;
                result.Message = "Menü kaydedilemedi !";
            }
            else
            {
                MenuGroup menuGroup = new MenuGroup
                {
                    Id = 1,
                    DesignMenu = JsonConvert.SerializeObject(menuObjects)
                };

                await _menuService.UpdateMenuGroup(menuGroup);

                result.IsSuccess = true;
                result.Message = "Menü kaydedildi";
            }
            return Json(result);
        }
    }
}