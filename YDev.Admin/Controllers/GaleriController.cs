using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class GaleriController : Controller
    {
        [Route("ResimGaleri")]
        public IActionResult ResimGaleri()
        {
            ViewData["Nav"] = "galeriler/resim";

            return View();
        }

        [Route("VideoGaleri")]
        public IActionResult VideoGaleri()
        {
            ViewData["Nav"] = "galeriler/video";

            return View();
        }

    }
}