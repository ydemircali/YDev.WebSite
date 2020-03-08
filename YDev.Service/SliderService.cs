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
    public interface ISliderService : IBaseService<Slider>
    {
    }
    public class SliderService : ISliderService
    {
        private IRepository<Slider> _repo;

        public SliderService(IRepository<Slider> repository)
        {
            _repo = repository;
        }
        public async Task Create(Slider dto)
        {
            _repo.Create(dto);
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            await _repo.Delete(id);
            await _repo.SaveChangesAsync();
        }

        public async Task<Slider> GetItemById(long id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Slider>> GetItems()
        {
            return await _repo.FindAll().ToListAsync();
        }

        public async Task Update(Slider dto)
        {
            _repo.Update(dto);
            await _repo.SaveChangesAsync();
        }
    }
}
