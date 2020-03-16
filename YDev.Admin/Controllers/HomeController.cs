using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YDev.Admin.Models;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly IHomeService _homeService;

        public HomeController(IGalleryService galleryService, IHomeService homeService)
        {
            _galleryService = galleryService;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Nav"] = "home";

            ViewData["Galleries"] = await _galleryService.GetItems();

            HomeSetting model = await _homeService.GetItemById(1);
            if (model == null)
            {
                model = new HomeSetting();
            }

            return View(model);
        }


        [HttpPost]
        [Route("ayarlariKaydet")]
        public async Task<JsonResult> AyrlariKaydet([FromBody] HomeSetting homeSetting)
        {
            AjaxResult result = new AjaxResult();

            if (homeSetting.HomeGalleryId != 0)
            {
                if (homeSetting.Id == 0)
                {
                    await _homeService.Create(homeSetting);
                }
                else
                {
                    await _homeService.Update(homeSetting);
                }

                result.IsSuccess = true;
                result.Message = "Ayarlar kaydedildi.";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Galeri zorunludur.(Galeri yoksa oluşturmanız gerekiyor.)";

            }
            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
