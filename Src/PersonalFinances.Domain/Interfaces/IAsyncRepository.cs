using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        // Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> filter = null, 
                                         Expression<Func<T, object>> orderBy = null, 
                                         Expression<Func<T, object>> include = null);
        Task<IEnumerable<T>> ExecProcedureAsync(string procedure, List<string> parameters);
    }
}