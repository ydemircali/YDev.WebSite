using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;
using YDev.Data;

namespace YDev.Service
{
    public interface IContentService : IBaseService<Content>
    {

    }
    public class ContentService : IContentService
    {
        private readonly IRepository<Content> _contentData;
        public ContentService(IRepository<Content> contentData)
        {
            _contentData = contentData;
        }

        public async Task Create(Content dto)
        {
             _contentData.Create(dto);
            await _contentData.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Content> GetItemById(long id)
        {
            return await _contentData.GetById(id);
        }

        public async Task<List<Content>> GetItems()
        {
            return await _contentData.FindAll().Include(content => content.Menu).ToListAsync();
        }

        public async Task Update(Content dto)
        {
            _contentData.Update(dto);
            await _contentData.SaveChangesAsync(); 
        }
    }
}
