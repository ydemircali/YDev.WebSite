using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YDev.Common.Enum;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;
using YDev.Web.Models;

namespace YDev.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IContentService _contentService;
        private readonly IHomeService _homeService;
        private readonly IGalleryService _galleryService;

        public HomeController(ISliderService sliderService, IContentService contentService,
            IHomeService homeService, IGalleryService galleryService)
        {
            _sliderService = sliderService;
            _contentService = contentService;
            _homeService = homeService;
            _galleryService = galleryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Sliders"] = await _sliderService.GetItems();

            ViewData["Cozumler"] = await _contentService.GetContentsByCategory(Categories.Cozumlerimiz, 4);
            ViewData["Bloglar"] = await _contentService.GetContentsByCategory(Categories.Blog, 8);

            HomeSetting homeSetting = await _homeService.GetItemById(1);
            if (homeSetting != null && homeSetting.HomeGalleryId != 0)
            {
                ViewData["Galeri"] = await _galleryService.GetMediasGalleryByGalleryId(homeSetting.HomeGalleryId);
            }


            return View();
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
