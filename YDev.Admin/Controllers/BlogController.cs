using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class BlogController : Controller
    {
        [Route("kategoriler")]
        public IActionResult Kategoriler()
        {
            ViewData["Nav"] = "blog/kategoriler";

            return View();
        }

        [Route("icerikler")]
        public IActionResult Icerikler()
        {
            ViewData["Nav"] = "blog/icerikler";

            return View();
        }
    }
}