using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YDev.Common.Models;
using YDev.Common.Helper;
using YDev.Service;

namespace YDev.Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoryService _categoryService;
        public MenuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["Nav"] = "menu";
            ViewData["Categories"] = await _categoryService.GetItems();
            MenuGroup menuGroup = _categoryService.GetMenuGroup(1);
            MenuGroup menuGroupAlt = _categoryService.GetMenuGroup(2);

            ViewData["MenuObject"] = new List<MenuObject>();
            if (menuGroup != null && menuGroup.DesignMenu!= null)
            {
                ViewData["MenuObject"] = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroup.DesignMenu);
            }

            ViewData["MenuObjectAlt"] = new List<MenuObject>();
            if (menuGroupAlt != null && menuGroupAlt.DesignMenu != null)
            {
                ViewData["MenuObjectAlt"] = JsonConvert.DeserializeObject<List<MenuObject>>(menuGroupAlt.DesignMenu);
            }

            return View();
        }

        [HttpPost]
        [Route("MenuKaydet")]
        public async Task<JsonResult> Kaydet([FromBody] List<MenuObject> menuObjects)
        {
            AjaxResult result = new AjaxResult();

            if (menuObjects == null)
            {
                result.IsSuccess = false;
                result.Message = "Menü kaydedilemedi !";
            }
            else
            {
                MenuGroup menuGroup = new MenuGroup
                {
                    Id = 1,
                    DesignMenu = JsonConvert.SerializeObject(menuObjects)
                };

                await _categoryService.UpdateMenuGroup(menuGroup);

                result.IsSuccess = true;
                result.Message = "Menü kaydedildi";
            }
            return Json(result);
        }

        [HttpPost]
        [Route("MenuSil")]
        public async Task<JsonResult> MenuSil([FromBody] List<MenuObject> menuObjects, string menuId)
        {
            AjaxResult result = new AjaxResult();

            if (menuObjects == null)
            {
                result.IsSuccess = false;
                result.Message = "Menü kaydedilemedi !";
            }
            else
            {
                foreach (var item in menuObjects)
                {
                    if (item.Id == Convert.ToInt32(menuId))
                    {
                        menuObjects.Remove(item);
                        break;
                    }
                    else
                    {
                        if (item.Children != null)
                        {
                            foreach (var subItem in item.Children)
                            {
                                if (subItem.Id == Convert.ToInt32(menuId))
                                {
                                    item.Children.Remove(subItem);
                                    break;
                                }
                                else
                                {
                                    if (subItem.Children != null)
                                    {
                                        foreach (var subItem2 in subItem.Children)
                                        {
                                            if (subItem2.Id == Convert.ToInt32(menuId))
                                            {
                                                subItem.Children.Remove(subItem2);
                                                break;
                                            }
                                        }
                                    }
                                   
                                }
                            }
                        }
                      
                    }
                }

                MenuGroup menuGroup = new MenuGroup
                {
                    Id = 1,
                    DesignMenu = JsonConvert.SerializeObject(menuObjects)
                };

                await _categoryService.UpdateMenuGroup(menuGroup);

                result.IsSuccess = true;
                result.Message = "Menü kaydedildi";
            }
            return Json(result);
        }

        [HttpPost]
        [Route("MenuKategoriEkle")]
        public async Task<JsonResult> MenuKategoriEkle([FromBody] List<MenuObject> menuObjects, string categoryId)
        {
            AjaxResult result = new AjaxResult();

            if (!string.IsNullOrEmpty(categoryId))
            {
                bool ekli = false;
                if (menuObjects.Count >0)
                {
                    foreach (var item in menuObjects)
                    {
                        if (item.Id == Convert.ToInt32(categoryId))
                        {
                            ekli = true;
                            break;
                        }
                        else
                        {
                            if (item.Children != null)
                            {
                                foreach (var subItem in item.Children)
                                {
                                    if (subItem.Id == Convert.ToInt32(categoryId))
                                    {
                                        ekli = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (subItem.Children != null)
                                        {
                                            foreach (var subItem2 in subItem.Children)
                                            {
                                                if (subItem2.Id == Convert.ToInt32(categoryId))
                                                {
                                                    ekli = true;
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }

                    if (ekli)
                    {
                        result.IsSuccess = false;
                        result.Message = "Kategori zaten eklenmiş";
                    }
                    else
                    {
                        menuObjects.Add(new MenuObject
                        {
                            Id = Convert.ToInt32(categoryId)
                        });

                        if (menuObjects.Count == 1)
                        {
                            MenuGroup menuGroup = new MenuGroup
                            {
                                GroupName = "Yeni",
                                DesignMenu = JsonConvert.SerializeObject(menuObjects)
                            };

                            await _categoryService.CreateMenuGroup(menuGroup);

                            result.IsSuccess = true;
                            result.Message = "Kategori eklendi";

                        }
                        else
                        {

                            MenuGroup menuGroup = new MenuGroup
                            {
                                Id = 1,
                                DesignMenu = JsonConvert.SerializeObject(menuObjects)
                            };

                            await _categoryService.UpdateMenuGroup(menuGroup);

                            result.IsSuccess = true;
                            result.Message = "Kategori eklendi";
                        }

                    }
                }
               
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Bir Kategori seçiniz !";
            }

            return Json(result);
        }


        [HttpPost]
        [Route("AltMenuKaydet")]
        public async Task<JsonResult> AltMenuKaydet([FromBody] List<MenuObject> menuObjects)
        {
            AjaxResult result = new AjaxResult();

            if (menuObjects == null)
            {
                result.IsSuccess = false;
                result.Message = "Menü kaydedilemedi !";
            }
            else
            {
                MenuGroup menuGroup = new MenuGroup
                {
                    Id = 2,
                    DesignMenu = JsonConvert.SerializeObject(menuObjects)
                };

                await _categoryService.UpdateMenuGroup(menuGroup);

                result.IsSuccess = true;
                result.Message = "Menü kaydedildi";
            }
            return Json(result);
        }

        [HttpPost]
        [Route("AltMenuSil")]
        public async Task<JsonResult> AltMenuSil([FromBody] List<MenuObject> menuObjects, string menuId)
        {
            AjaxResult result = new AjaxResult();

            if (menuObjects == null)
            {
                result.IsSuccess = false;
                result.Message = "Menü kaydedilemedi !";
            }
            else
            {
                foreach (var item in menuObjects)
                {
                    if (item.Id == Convert.ToInt32(menuId))
                    {
                        menuObjects.Remove(item);
                        break;
                    }
                    else
                    {
                        if (item.Children != null)
                        {
                            foreach (var subItem in item.Children)
                            {
                                if (subItem.Id == Convert.ToInt32(menuId))
                                {
                                    item.Children.Remove(subItem);
                                    break;
                                }
                                else
                                {
                                    if (subItem.Children != null)
                                    {
                                        foreach (var subItem2 in subItem.Children)
                                        {
                                            if (subItem2.Id == Convert.ToInt32(menuId))
                                            {
                                                subItem.Children.Remove(subItem2);
                                                break;
                                            }
                                        }
                                    }

                                }
                            }
                        }

                    }
                }

                MenuGroup menuGroup = new MenuGroup
                {
                    Id = 2,
                    DesignMenu = JsonConvert.SerializeObject(menuObjects)
                };

                await _categoryService.UpdateMenuGroup(menuGroup);

                result.IsSuccess = true;
                result.Message = "Menü kaydedildi";
            }
            return Json(result);
        }

        [HttpPost]
        [Route("AltMenuKategoriEkle")]
        public async Task<JsonResult> AltMenuKategoriEkle([FromBody] List<MenuObject> menuObjects, string categoryId)
        {
            AjaxResult result = new AjaxResult();

            if (!string.IsNullOrEmpty(categoryId))
            {
                bool ekli = false;
                if (menuObjects.Count > 0)
                {
                    foreach (var item in menuObjects)
                    {
                        if (item.Id == Convert.ToInt32(categoryId))
                        {
                            ekli = true;
                            break;
                        }
                        else
                        {
                            if (item.Children != null)
                            {
                                foreach (var subItem in item.Children)
                                {
                                    if (subItem.Id == Convert.ToInt32(categoryId))
                                    {
                                        ekli = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (subItem.Children != null)
                                        {
                                            foreach (var subItem2 in subItem.Children)
                                            {
                                                if (subItem2.Id == Convert.ToInt32(categoryId))
                                                {
                                                    ekli = true;
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }

                    if (ekli)
                    {
                        result.IsSuccess = false;
                        result.Message = "Kategori zaten eklenmiş";
                    }
                    else
                    {
                        menuObjects.Add(new MenuObject
                        {
                            Id = Convert.ToInt32(categoryId)
                        });

                        if (menuObjects.Count == 1)
                        {
                            MenuGroup menuGroup = new MenuGroup
                            {
                                GroupName = "Yeni",
                                DesignMenu = JsonConvert.SerializeObject(menuObjects)
                            };

                            await _categoryService.CreateMenuGroup(menuGroup);

                            result.IsSuccess = true;
                            result.Message = "Kategori eklendi";

                        }
                        else
                        {

                            MenuGroup menuGroup = new MenuGroup
                            {
                                Id = 2,
                                DesignMenu = JsonConvert.SerializeObject(menuObjects)
                            };

                            await _categoryService.UpdateMenuGroup(menuGroup);

                            result.IsSuccess = true;
                            result.Message = "Kategori eklendi";
                        }

                    }
                }

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Bir Kategori seçiniz !";
            }

            return Json(result);
        }
    }
}