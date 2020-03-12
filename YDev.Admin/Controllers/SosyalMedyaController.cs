using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class SosyalMedyaController : Controller
    {
        private readonly ISocialService _socialService;

        public SosyalMedyaController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Nav"] = "sosyalmedya";

            List<Social> socials = await _socialService.GetItems();

            return View(socials);
        }

        [HttpPost]
        [Route("socialSave")]
        public async Task<JsonResult> SocialSave([FromBody] List<Social> socials)
        {
            AjaxResult result = new AjaxResult();

            if (socials != null && socials.Count > 0)
            {
                foreach (var social in socials)
                {
                    if (social.Id == 0)
                    {
                        await _socialService.Create(social);
                    }
                    else
                    {
                        await _socialService.Update(social);
                    }
                }

                result.IsSuccess = true;
                result.Message = "Sosyal Medya bilgileri kaydedildi.";

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Bilgiler kontrol ediniz.";

            }



            return Json(result);
        }
    }
}