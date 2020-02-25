using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class SosyalMedyaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Nav"] = "sosyalmedya";

            return View();
        }
    }
}