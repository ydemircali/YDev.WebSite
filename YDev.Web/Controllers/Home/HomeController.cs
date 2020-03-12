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

        public HomeController(ISliderService sliderService, IContentService contentService)
        {
            _sliderService = sliderService;
            _contentService = contentService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Sliders"] = await _sliderService.GetItems();

            ViewData["Cozumler"] = await _contentService.GetContentsByCategory(Categories.Cozumlerimiz);


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
