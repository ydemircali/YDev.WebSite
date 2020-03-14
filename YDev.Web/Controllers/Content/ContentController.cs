using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YDev.Service;
using YDev.Common.Enum;
using YDev.Common.Models;

namespace YDev.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [Route("blog")]
        public async Task<IActionResult> Blog()
        {
            List<Content> bloglar = await _contentService.GetContentsByCategory(Categories.Blog);

            return View(bloglar);
        }

        [Route("blog/{blogTitle}")]
        public async Task<IActionResult> BlogDetail(string blogTitle)
        {
            var splits = blogTitle.Split("-");
            Content blog = new Content();
            if (int.TryParse(splits.LastOrDefault(), out int blogId))
            {
                if (blogId == 0)
                {
                    return Redirect("/blog");
                }
                blog = await _contentService.GetItemById(blogId);
                if (blog == null)
                {
                    return Redirect("/blog");
                }
            }
            else
            {
                return Redirect("/blog");
            }

            ViewData["Bloglar"] = await _contentService.GetContentsByCategory(Categories.Blog, 5);

            return View(blog);
        }

        [Route("cozumler")]
        [Route("cozumlerimiz")]
        public async Task<IActionResult> Cozumler()
        {
            List<Content> cozumler = await _contentService.GetContentsByCategory(Categories.Cozumlerimiz);

            return View(cozumler);
        }


        [Route("cozumlerimiz/{cozumTitle}")]
        public async Task<IActionResult> CozumlerDetail(string cozumTitle)
        {
            var splits = cozumTitle.Split("-");

            Content cozum = new Content();

            if (int.TryParse(splits.LastOrDefault(), out int cozumId))
            {
                if (cozumId == 0)
                {
                    return Redirect("/cozumlerimiz");
                }
                cozum = await _contentService.GetItemById(cozumId);
                if (cozum == null)
                {
                    return Redirect("/cozumlerimiz");
                }
            }
            else
            {
                return Redirect("/cozumlerimiz");
            }


            return View(cozum);
        }

        [Route("hakkimizda")]
        [Route("about")]
        public async Task<IActionResult> Hakkimizda()
        {
            List<Content> content = await _contentService.GetContentsByCategory(Categories.Hakkimizda);

            return View(content);
        }

        [Route("merakEttikleriniz")]
        [Route("merakEdilenler")]
        public async Task<IActionResult> MerakEttikleriniz()
        {
            List<Content> contents = await _contentService.GetContentsByCategory(Categories.MerakEttikleriniz);

            return View(contents);
        }


        [Route("sayfa/{sayfaTitle}")]
        public async Task<IActionResult> Sayfa(string sayfaTitle)
        {
            var splits = sayfaTitle.Split("-");

            Content sayfa = new Content();

            if (int.TryParse(splits.LastOrDefault(), out int sayfaId))
            {
                if (sayfaId == 0)
                {
                    return Redirect("/");
                }
                sayfa = await _contentService.GetItemById(sayfaId);
                if (sayfa == null)
                {
                    return Redirect("/");
                }
            }
            else
            {
                return Redirect("/");
            }


            return View(sayfaId);
        }


    }
}