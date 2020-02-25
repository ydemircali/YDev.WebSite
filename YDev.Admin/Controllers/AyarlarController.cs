using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class AyarlarController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Nav"] = "ayarlar";

            return View();
        }
    }
}