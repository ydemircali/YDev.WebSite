using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YDev.Common.Enum;
using YDev.Service;

namespace YDev.Web.Components
{
    public class FooterComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;

        public FooterComponent(ICategoryService categoryService, IContactService contactService)
        {
            _categoryService = categoryService;
            _contactService = contactService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetItems();
            ViewData["Contact"] = await _contactService.GetContactByContactType(ContactTypes.Merkez);

            return View(categories);
        }
    }
}
