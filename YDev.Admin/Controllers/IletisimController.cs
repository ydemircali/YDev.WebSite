using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IContactService _contactService;

        public IletisimController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Nav"] = "iletisim";

            List<Contact> contacts = await _contactService.GetItems();

            return View(contacts);
        }

        [HttpPost]
        [Route("adresKaydet")]
        public async Task<JsonResult> AdresKaydet([FromBody] Contact contact)
        {
            AjaxResult result = new AjaxResult();

            if (contact == null || string.IsNullOrEmpty(contact.Name))
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                if (contact.Id == 0)
                {
                    await _contactService.Create(contact);

                    result.IsSuccess = true;
                    result.Message = "İletişim bilgisi kaydedildi";
                }
                else
                {
                    await _contactService.Update(contact);
                    result.IsSuccess = true;
                    result.Message = "iletişim bilgisi güncellendi";
                }

            }

            return Json(result);
        }
    }
}