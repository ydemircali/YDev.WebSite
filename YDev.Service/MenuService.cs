using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface IMenuService : IBaseService<Menu>
    {
        public MenuGroup GetMenuGroup(long id);

        public Task<IEnumerable<MenuGroup>> GetMenuGroups();

        public Task UpdateMenuGroup(MenuGroup menuGroup);
        public List<Menu> GetMenus(); 

    }
    public class MenuService : IMenuService
    {
        private IRepository<MenuGroup> _menuGroupRepo;
        private IRepository<Menu> _menuRepo;

        public MenuService(IRepository<MenuGroup> menuGroupRepo, IRepository<Menu> menuRepo)
        {
            _menuGroupRepo = menuGroupRepo;
            _menuRepo = menuRepo;
        }

        public  async Task Create(Menu dto)
        {
            _menuRepo.Create(dto);
            await _menuRepo.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            Menu menu = await _menuRepo.GetById(id);
            _menuRepo.Delete(menu);
            await _menuRepo.SaveChangesAsync();
        }

        public Task<Menu> GetItemById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Menu>> GetItems()
        {
            return await _menuRepo.FindAll().ToListAsync();
        }

        public List<Menu> GetMenus()
        {
            return _menuRepo.FindAll().ToList();
        }

        public MenuGroup GetMenuGroup(long id)
        {
            return _menuGroupRepo.FindByCondition(f => f.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<MenuGroup>> GetMenuGroups()
        {
            return await _menuGroupRepo.FindAll().ToListAsync();
        }


        public Task Update(Menu dto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMenuGroup(MenuGroup menuGroup)
        {
            _menuGroupRepo.Update(menuGroup);
            await _menuGroupRepo.SaveChangesAsync();
        }
    }
}
