using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface IHomeService : IBaseService<HomeSetting>
    {

    }
    public class HomeService : IHomeService
    {
        private readonly IRepository<HomeSetting> _repo;

        public HomeService(IRepository<HomeSetting> repository)
        {
            _repo = repository;
        }

        public async Task Create(HomeSetting dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<HomeSetting> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<HomeSetting>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(HomeSetting dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }
    }
}
