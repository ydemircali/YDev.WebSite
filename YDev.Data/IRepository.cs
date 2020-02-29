using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(long id);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
