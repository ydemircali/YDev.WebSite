using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<List<T>> GetItems();
        Task<T> GetItemById(long id);
        Task Create(T dto);
        Task Update(T dto);
        Task Delete(long id);
    }
}
