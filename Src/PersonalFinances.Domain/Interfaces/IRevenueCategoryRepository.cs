using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRevenueCategoryRepository
    {
        Task<RevenueCategory> GetByIdAndUserIdAsync(int id, int userId);
        Task<RevenueCategory> GetByIdAndUserIdAsNoTrackingAsync(int id, int userId);
        Task<IEnumerable<RevenueCategory>> GetByUserIdAsNoTrackingAsync(int userId);
        Task AddAsync(RevenueCategory revenueCategory);
        Task UpdateAsync(RevenueCategory revenueCategory);
        Task DeleteAsync(RevenueCategory revenueCategory);
    }
}