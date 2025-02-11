using App.Application.Contracts.IRepository;
using App.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public class BaseReporitory<T>(AppDBContext context) : IBaseRepository<T> where T : class
    {
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;

        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var entity= await context.Set<T>().FindAsync(Id);
            if (entity == null) return false;
            context.Set<T>().Remove(entity);
            return true;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> expression, string? include)
        {
            IQueryable<T> query = context.Set<T>();
            if (include != null) { query= query.Include(include); }
            return await query.Where(expression).ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
      
            return await context.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetByOrderAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int? topN)
        {
            IQueryable<T> query = context.Set<T>();
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (topN.HasValue) { query=query.Take(topN.Value); }
            return await query.ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);

        }
    }
}
