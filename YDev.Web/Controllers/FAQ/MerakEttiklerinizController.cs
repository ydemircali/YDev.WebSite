using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Enum;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Controllers.FAQ
{
    public class MerakEttiklerinizController : Controller
    {
        private readonly IContentService _contentService;

        public MerakEttiklerinizController(IContentService contentService)
        {
            _contentService = contentService;
        }
        public async Task<IActionResult> Index()
        {
            List<Content> contents = await _contentService.GetContentsByCategory(Categories.MerakEttikleriniz);

            return View(contents);
        }
    }
}