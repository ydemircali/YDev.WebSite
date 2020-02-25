using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Nav"] = "slider";

            return View();
        }
    }
}