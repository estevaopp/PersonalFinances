using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Context;

namespace PersonalFinances.Infra.Data.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : EntityBase
    {
        private ApplicationDbContext _context;

        public AsyncRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ExecProcedureAsync(string procedure, List<string> parameters = null)
        {
            if (parameters == null)
                return await _context.Set<T>().FromSqlInterpolated($"call {procedure}").ToListAsync();
            
            var queryString = $"call {procedure} ({string.Join(", ",parameters)})";

            var query = _context.Set<T>().FromSqlRaw(queryString);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filter = null, 
                                                      Expression<Func<T, object>> orderBy = null, 
                                                      Expression<Func<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
                query.Where(filter);
            
            if (include != null)
                query.Include(include);
            
            if (orderBy != null)
                query.OrderBy(orderBy);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsNoTrackingAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            // return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}