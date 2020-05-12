using System.Threading.Tasks;
using YDev.Admin.Models;
using YDev.Admin.Models.FileUpload;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YDev.Common.Helper;
using YDev.Common.Models;
using YDev.Service;
using System.Linq;
using System.Collections.Generic;
using YDev.Admin.Constant;

namespace YDev.Admin.Controllers
{
    public class MediaYonetimController : Controller
    {
        private readonly FilesHelper _filesHelper;
        private readonly IMediator _mediator;
        private readonly IMediaService _mediaService;
        private readonly IGalleryService _galleryService;

        public MediaYonetimController(FilesHelper filesHelper, IMediator mediator, 
            IMediaService mediaService, IGalleryService galleryService)
        {
            _filesHelper = filesHelper;
            _mediator = mediator;
            _mediaService = mediaService;
            _galleryService = galleryService;
        }

        #region Resim video işlemleri

        [Route("resimvideo")]
        public async Task<IActionResult> ResimVideo()
        {
            ViewData["Nav"] = "medya/resimvideo";

            return View();
        }

        [HttpPost]
        [Route("FileUpload")]
        public async Task<JsonResult> FileUpload(FileUploadUpload.Command command)
        {
            AjaxResult aResult = new AjaxResult();

            command.HttpContext = HttpContext;

            if (command.Files.Count > 0)
            {
                var result = await _mediator.Send(command);

                if (result.FileResults.Count == 0)
                {
                    aResult.IsSuccess = false;
                    aResult.Message = "Yükleme hatası";
                }
                else
                {
                    ViewDataUploadFilesResult filesResult = result.FileResults.FirstOrDefault();

                    Media media = new Media
                    {
                        Content = command.Content,
                        Name = filesResult.name,
                        Size = filesResult.Size,
                        Type = filesResult.type,
                        Url = StaticDatas.HOST_NAME + filesResult.url,
                        ThumbnailUrl = StaticDatas.HOST_NAME + filesResult.thumbnailUrl,
                        WidthHeight = filesResult.widthHeight
                    };

                    await _mediaService.Create(media);

                    aResult.IsSuccess = true;
                    aResult.Message = "Yükleme başarılı";
                   
                }
            }
            else
            {
                Media media = new Media
                {
                    Content = command.Content,
                    Url = command.Url
                };

                await _mediaService.Create(media);

                aResult.IsSuccess = true;
                aResult.Message = "Yükleme başarılı";

            }
            return Json(aResult);
        }

        [HttpPost]
        [Route("deleteFiles")]
        public JsonResult DeleteFiles(string filesRequest)
        {
            string[] files = filesRequest.Split(",");
            foreach (var file in files)
            {
                _filesHelper.DeleteFile(file);
            }

            return Json("OK");
        }

        #endregion

        #region Galeri işlemleri

        [Route("galeriler")]
        public async Task<IActionResult> Galeriler()
        {
            ViewData["Nav"] = "medya/galeriler";

            List<Gallery> galleries = await _galleryService.GetItems();
            
            return View(galleries);
        }
        
        [HttpPost]
        [Route("galeriKaydet")]
        public async Task<JsonResult> GaleriKaydet([FromBody] Gallery gallery)
        {
            AjaxResult result = new AjaxResult();

            if (gallery == null || string.IsNullOrEmpty(gallery.Title))
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                if (gallery.Id == 0)
                {
                    await _galleryService.Create(gallery);

                    result.IsSuccess = true;
                    result.Message = "Galeri kaydedildi";
                }
                else
                {
                    await _galleryService.Update(gallery);
                    result.IsSuccess = true;
                    result.Message = "Galeri güncellendi";
                }

            }

            return Json(result);
        }

        [HttpPost]
        [Route("galeriSil")]
        public async Task<JsonResult> GaleriSil(long galeriId)
        {
            AjaxResult result = new AjaxResult();

            if (galeriId == 0)
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                await _galleryService.Delete(galeriId);

                result.IsSuccess = true;
                result.Message = "Galeri silindi";

            }

            return Json(result);
        }

        #endregion

        #region Galeri medya işlemleri

        [Route("galeriDetay")]
        public async Task<IActionResult> GaleriDetay(long galeriId)
        {
            ViewData["Nav"] = "medya/galeriler";

            Gallery gallery = await _galleryService.GetItemById(galeriId);

            ViewData["FilesGallery"] = await _galleryService.GetMediasGalleryByGalleryId(galeriId);

            return View(gallery);
        }

        [HttpPost]
        [Route("galeriMedyaKaydet")]
        public async Task<JsonResult> GaleriMedyaKaydet([FromBody] MediaGallery mediaGallery)
        {
            AjaxResult result = new AjaxResult();

            if (mediaGallery == null || string.IsNullOrEmpty(mediaGallery.MediaUrl))
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                await _galleryService.CreateMediaGallery(mediaGallery);

                result.IsSuccess = true;
                result.Message = "Medya kaydedildi";
               
            }

            return Json(result);
        }

        [HttpPost]
        [Route("galeriMedyaSil")]
        public async Task<JsonResult> GaleriMedyaSil(long galeriMedyaId)
        {
            AjaxResult result = new AjaxResult();

            if (galeriMedyaId == 0)
            {
                result.IsSuccess = false;
                result.Message = "Eksik alanları doldurun !";
            }
            else
            {
                await _galleryService.DeleteMediaGallery(galeriMedyaId);

                result.IsSuccess = true;
                result.Message = "Medya silindi";

            }

            return Json(result);
        }

        #endregion

    }
}
