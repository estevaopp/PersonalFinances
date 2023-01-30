using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IExpenditureCategoryRepository
    {
        Task<ExpenditureCategory> GetByIdAndUserIdAsync(int id, int userId);
        Task<ExpenditureCategory> GetByIdAndUserIdAsNoTrackingAsync(int id, int userId);
        Task<IEnumerable<ExpenditureCategory>> GetByUserIdAsNoTrackingAsync(int userId);
        Task AddAsync(ExpenditureCategory expenditureCategory);
        Task UpdateAsync(ExpenditureCategory expenditureCategory);
        Task DeleteAsync(ExpenditureCategory expenditureCategory);
    }
}