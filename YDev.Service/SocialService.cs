using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface ISocialService : IBaseService<Social>
    {

    }
    public class SocialService : ISocialService
    {
        private readonly IRepository<Social> _repo;

        public SocialService(IRepository<Social> repository)
        {
            _repo = repository;
        }

        public async Task Create(Social dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Social> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Social>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Social dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }
    }
}
