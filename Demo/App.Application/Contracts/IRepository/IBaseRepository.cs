using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Contracts.IRepository
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> expression , string? include);
        Task<IEnumerable<T>> GetByOrderAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int? topN);


        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int Id);
        
    }
}
