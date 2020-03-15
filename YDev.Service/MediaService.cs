using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface IMediaService : IBaseService<Media>
    {

    }
    public class MediaService : IMediaService
    {
        private IRepository<Media> _repo;

        public MediaService(IRepository<Media> repository)
        {
            _repo = repository;
        }
        public async Task Create(Media dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _repo.Delete(id);
            await _repo.SaveChangesAsync();
        }

        public async Task<Media> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Media>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Media dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }
    }
}
