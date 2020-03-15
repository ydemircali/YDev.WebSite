using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Models;
using YDev.Service;

namespace YDev.Web.Controllers.Galeri
{
    public class GaleriController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GaleriController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Gallery> galleries = await _galleryService.GetItems();

            ViewData["MediaGaleri"] = await _galleryService.GetItemsMediaGallery();

            return View(galleries);
        }
    }
}