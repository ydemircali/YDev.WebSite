using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class BanaOzelController : Controller
    {
        [Route("profil")]
        public IActionResult Profil()
        {
            ViewData["Nav"] = "banaozel/profil";

            return View();
        }

        [Route("takvim")]
        public IActionResult Takvim()
        {
            ViewData["Nav"] = "banaozel/takvim";

            return View();
        }
    }
}