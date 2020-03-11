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
    public interface IContactService : IBaseService<Contact>
    {
    }

    public class ContactService : IContactService
    {
        private IRepository<Contact> _repo;

        public ContactService(IRepository<Contact> repository)
        {
            _repo = repository;
        }

        public async Task Create(Contact dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Contact>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Contact dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }
       
    }
}
