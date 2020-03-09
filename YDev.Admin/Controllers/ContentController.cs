﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Models;
using YDev.Common.Helper;
using YDev.Service;
using YDev.Admin.Models;

namespace YDev.Admin.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IMenuService _menuService;
        private readonly FilesHelper _filesHelper;
        public ContentController(FilesHelper filesHelper,IContentService contentService, IMenuService menuService)
        {
            _contentService = contentService;
            _menuService = menuService;
            _filesHelper = filesHelper;
        }

        [Route("kategoriler")]
        public IActionResult Kategoriler()
        {
            ViewData["Nav"] = "content/kategoriler";

            return View();
        }

        [Route("icerikler")]
        public async Task<IActionResult> IceriklerAsync()
        {
            ViewData["Nav"] = "content/icerikler";
            List<Content> contents = await _contentService.GetItems();

            return View(contents);
        }

        [Route("icerikEkle")]
        public async Task<IActionResult> IcerikEkleAsync(int contentId=0)
        {
            ViewData["Nav"] = "content/icerikler";
            ViewData["Menus"] = _menuService.GetMenus();

            JsonFiles ListOfFiles = _filesHelper.GetFileList();

            ViewData["Files"] = ListOfFiles.files.ToList();

            Content content = new Content();
            if (contentId != 0)
            {
                content = await _contentService.GetItemById(contentId);
            }

            return View(content);
        }

        [HttpPost]
        [Route("icerikKaydet")]
        public async Task<JsonResult> IcerikKaydet([FromBody] Content content)
        {
            AjaxResult result = new AjaxResult();

            if (content == null || string.IsNullOrEmpty(content.Title) 
                || content.MenuId == 0 || string.IsNullOrEmpty(content.Spot))
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                if (content.Id == 0)
                {
                    await _contentService.Create(content);

                    result.IsSuccess = true;
                    result.Message = "İçerik kaydedildi";
                }
                else
                {
                    await _contentService.Update(content);
                    result.IsSuccess = true;
                    result.Message = "İçerik güncellendi";
                }
               
            }

            return Json(result);
        }
        [HttpPost]
        [Route("icerikSil")]
        public async Task<JsonResult> IcerikSil(int contentId)
        {
            AjaxResult result = new AjaxResult();

            if (contentId == 0)
            {
                result.IsSuccess = false;
                result.Message = "İçerik Silinemedi !";
            }
            else
            {
              
                await _contentService.Delete(contentId);
                result.IsSuccess = true;
                result.Message = "İçerik silindi";
                
            }

            return Json(result);
        }

    }
}