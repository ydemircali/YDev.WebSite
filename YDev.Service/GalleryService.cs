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
    public interface IGalleryService : IBaseService<Gallery>
    {
        public Task<List<MediaGallery>> GetMediasGalleryByGalleryId(long galleryId);
        public Task CreateMediaGallery(MediaGallery mediaGallery);
        public Task UpdateMediaGallery(MediaGallery mediaGallery);
        public Task DeleteMediaGallery(long id);
        public Task<List<MediaGallery>> GetItemsMediaGallery();
    }

    public class GalleryService : IGalleryService
    {
        private IRepository<Gallery> _repo;
        private IRepository<MediaGallery> _repoMediaGallery;

        public GalleryService(IRepository<Gallery> repository, IRepository<MediaGallery> repoMediaGallery)
        {
            _repo = repository;
            _repoMediaGallery = repoMediaGallery;
        }

        public async Task Create(Gallery dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _repo.Delete(id);
            await _repo.SaveChangesAsync();
        }

        public async Task<Gallery> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Gallery>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Gallery dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<MediaGallery>> GetMediasGalleryByGalleryId(long galleryId)
        {
            return await _repoMediaGallery.FindByCondition(f => f.GalleryId == galleryId).ToListAsync();
        }

        public async Task CreateMediaGallery(MediaGallery dto)
        {
            _repoMediaGallery.Create(dto);
            await _repoMediaGallery.SaveChangesAsync();

        }
        public async Task UpdateMediaGallery(MediaGallery dto)
        {
            _repoMediaGallery.Update(dto);
            await _repoMediaGallery.SaveChangesAsync();
        }

        public async Task DeleteMediaGallery(long id)
        {
            await _repoMediaGallery.Delete(id);
            await _repoMediaGallery.SaveChangesAsync();
        }

        public async Task<List<MediaGallery>> GetItemsMediaGallery()
        {
            return await _repoMediaGallery.FindAll().ToListAsync();
        }

    }
}
