using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YDev.Common.Enum;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Controllers
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
            Contact contact = await _contactService.GetContactByContactType(ContactTypes.Merkez);

            return View(contact); 
        }
    }
}
