using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YDev.Common.Enum;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly IContentService _contentService;

        public HakkimizdaController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public async Task<IActionResult> Index() 
        {
            List<Content> content = await _contentService.GetContentsByCategory(Categories.Hakkimizda);

            return View(content); 
        }
    }
}
