using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YDev.Admin.Models;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly FilesHelper _filesHelper;

        public SliderController(FilesHelper filesHelper,ISliderService sliderService)
        {
            _sliderService = sliderService;
            _filesHelper = filesHelper;
        }

        [Route("sliderlar")]
        public async Task<IActionResult> Index()
        {
            ViewData["Nav"] = "slider";

            List<Slider> sliders = await _sliderService.GetItems();
            
            return View(sliders);
        }

        [Route("sliderEkle")]
        public async Task<IActionResult> SliderEkle(int Id = 0)
        {
            ViewData["Nav"] = "slider";

            JsonFiles ListOfFiles = _filesHelper.GetFileList();
            
            ViewData["Files"] = ListOfFiles.files.ToList();

            Slider slider = new Slider();
            if (Id != 0)
            {
                slider = await _sliderService.GetItemById(Id);
            }

            return View(slider);
        }

        [HttpPost]
        [Route("sliderKaydet")]
        public async Task<JsonResult> SliderKaydet([FromBody] Slider slider)
        {
            AjaxResult result = new AjaxResult();

            if (slider == null)
            {
                result.IsSuccess = false;
                result.Message = "Slider kaydedilemedi !";
            }
            else
            {
                slider.Content = slider.Content.Replace("</p><p>", "<br />").Replace("<p>", "").Replace("</p>", "").Replace("<br>","<br />");
                if (slider.Id == 0)
                {
                    await _sliderService.Create(slider);
                }
                else
                {
                    await _sliderService.Update(slider);
                }
                
                result.IsSuccess = true;
                result.Message = "Slider kaydedildi";
            }

            return Json(result);
        }

        [HttpPost]
        [Route("sliderSil")]
        public async Task<JsonResult> SliderSil(int Id)
        {
            AjaxResult result = new AjaxResult();

            if (Id == 0)
            {
                result.IsSuccess = false;
                result.Message = "Slider Silinemedi !";
            }
            else
            {

                await _sliderService.Delete(Id);
                result.IsSuccess = true;
                result.Message = "Slider silindi";

            }

            return Json(result);
        }

    }
}