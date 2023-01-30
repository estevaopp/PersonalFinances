using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IExpenditureCategoryRepository
    {
        Task<ExpenditureCategory> GetByIdAsync(int id, int userId);
        Task<ExpenditureCategory> GetByIdAsNoTrackingAsync(int id, int userId);
        Task<IEnumerable<ExpenditureCategory>> GetAllAsNoTrackingAsync(int userId);
        Task AddAsync(ExpenditureCategory expenditureCategory, int userId);
        Task UpdateAsync(ExpenditureCategory expenditureCategory, int userId);
        Task DeleteAsync(ExpenditureCategory expenditureCategory, int userId);
    }
}