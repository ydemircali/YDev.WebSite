using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface ICategoryService : IBaseService<Category>
    { 

    }

    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repo;

        public CategoryService(IRepository<Category> repository)
        {
            _repo = repository;
        }

        public Task Create(Category dto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetItemById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public Task Update(Category dto)
        {
            throw new NotImplementedException();
        }
    }
}
