using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YDev.Common.Models;

namespace YDev.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AppDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return entities.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return entities.Where(expression).AsNoTracking();
        }

        public Task<T> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
