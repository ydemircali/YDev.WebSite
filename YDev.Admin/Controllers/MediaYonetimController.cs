using System.Threading.Tasks;
using YDev.Admin.Models;
using YDev.Admin.Models.FileUpload;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YDev.Admin.Controllers
{
    public class MediaYonetimController : Controller
    {
        private readonly FilesHelper _filesHelper;
        private readonly IMediator _mediator;

        public MediaYonetimController(FilesHelper filesHelper, IMediator mediator)
        {
            _filesHelper = filesHelper;
            _mediator = mediator;
        }

        [Route("resimvideo")]
        public ActionResult ResimVideo()
        {
            ViewData["Nav"] = "medya/resimvideo";

            JsonFiles ListOfFiles = _filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };

            return View(model);
        }

        [HttpPost]
        [Route("FileUpload")]
        public async Task<JsonResult> FileUpload(FileUploadUpload.Command command)
        {
            command.HttpContext = HttpContext;

            var result = await _mediator.Send(command);

            // I think we can move this into the mediatr class.
            var jsonFiles = new JsonFiles(result.FileResults);

            var resultEnd = Json(jsonFiles);

            return result.FileResults.Count == 0
                ? Json("Error")
                : Json(jsonFiles);
        }

        [Route("galeriler")]
        public ActionResult Galeriler()
        {
            ViewData["Nav"] = "medya/galeriler";

            JsonFiles ListOfFiles = _filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };

            return View(model);
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
    }
}
