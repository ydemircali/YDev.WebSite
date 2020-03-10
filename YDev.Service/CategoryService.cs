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
    public interface ICategoryService : IBaseService<Category>
    {
        public MenuGroup GetMenuGroup(long id);

        public Task<IEnumerable<MenuGroup>> GetMenuGroups();

        public Task UpdateMenuGroup(MenuGroup menuGroup);
        public Task CreateMenuGroup(MenuGroup menuGroup);
    }

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repo;
        private IRepository<MenuGroup> _menuGroupRepo;

        public CategoryService(IRepository<Category> repository, IRepository<MenuGroup> menuGroupRepo)
        {
            _repo = repository;
            _menuGroupRepo = menuGroupRepo;
        }

        public async Task Create(Category dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Category>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Category dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }

        public MenuGroup GetMenuGroup(long id)
        {
            return _menuGroupRepo.FindByCondition(f => f.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<MenuGroup>> GetMenuGroups()
        {
            return await _menuGroupRepo.FindAll().ToListAsync();
        }

        public async Task UpdateMenuGroup(MenuGroup menuGroup)
        {
            _menuGroupRepo.Update(menuGroup);
            await _menuGroupRepo.SaveChangesAsync();
        }

        public async Task CreateMenuGroup(MenuGroup menuGroup)
        {
            _menuGroupRepo.Create(menuGroup);
            await _menuGroupRepo.SaveChangesAsync();
        }
    }
}
