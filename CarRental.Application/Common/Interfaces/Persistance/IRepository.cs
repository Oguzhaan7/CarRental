using CarRental.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Interfaces.Persistance
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> AsQueryable();

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id, bool noTracking);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAllPagedAsync(Expression<Func<T, bool>> expression, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}
