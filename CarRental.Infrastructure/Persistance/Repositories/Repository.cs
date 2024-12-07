using CarRental.Application.Common.Interfaces.Persistance;
using CarRental.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly CarRentalDbContext _context;

        public Repository(CarRentalDbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AsQueryable() => _context.Set<T>().AsQueryable();

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().Where(x=>x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> GetByIdAsync(Guid id, bool noTracking)
        {
            if (noTracking)
            {
                return await _context.Set<T>().Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }
            else { 
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            query = query.Where(expression);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = orderBy(query);

            return await query.Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            query = orderBy(query);

            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllPagedAsync(Expression<Func<T, bool>> expression, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.Where(expression).OrderByDescending(x=>x.CreatedDateTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
