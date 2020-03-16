using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YDev.Common.Enum;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Components
{
    public class HeaderComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IHomeService _homeService;
        private readonly IContactService _contactService;

        public HeaderComponent(ICategoryService categoryService, 
            IHomeService homeService, IContactService contactService)
        {
            _categoryService = categoryService;
            _homeService = homeService;
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["Categories"] = await _categoryService.GetItems();
            MenuGroup menuGroup = _categoryService.GetMenuGroup(1);

            List<MenuObject> menuObjects = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);

            ViewData["HomeSetting"] = await _homeService.GetItemById(1);
            ViewData["Contact"] = await _contactService.GetContactByContactType(ContactTypes.Merkez);

            return View(menuObjects);
        }
    }
}
