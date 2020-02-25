using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class StaticPagesController : Controller
    {
        [Route("hakkimizda")]
        public IActionResult Hakkimizda()
        {
            ViewData["Nav"] = "hakkimizda";

            return View();
        }
    }
}