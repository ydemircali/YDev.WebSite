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
    public class FooterComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly ISocialService _socialService;

        public FooterComponent(ICategoryService categoryService, 
            IContactService contactService, ISocialService socialService)
        {
            _categoryService = categoryService;
            _contactService = contactService;
            _socialService = socialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetItems();
            ViewData["Contact"] = await _contactService.GetContactByContactType(ContactTypes.Merkez);
            ViewData["Socials"] = await _socialService.GetItems();

            MenuGroup menuGroup = _categoryService.GetMenuGroup(2);
            ViewData["MenuObjects"] = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);

            return View(categories);
        }
    }
}
