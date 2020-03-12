using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;


        public HeaderComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["Categories"] = await _categoryService.GetItems();
            MenuGroup menuGroup = _categoryService.GetMenuGroup(1);

            List<MenuObject> menuObjects = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);

            return View(menuObjects);
        }
    }
}
