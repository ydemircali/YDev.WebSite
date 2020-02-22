using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Data.Repo
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected AppDBContext context;
        protected DbSet<T> entities;

        public AsyncRepository(AppDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<T> Get(long id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            entities.Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefaultAsync(predicate);
        }
        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => entities.CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => entities.CountAsync(predicate);
    }
}
