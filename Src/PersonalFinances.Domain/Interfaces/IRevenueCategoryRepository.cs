using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRevenueCategoryRepository
    {
        Task<RevenueCategory> GetByIdAsync(int id, int userId);
        Task<RevenueCategory> GetByIdAsNoTrackingAsync(int id, int userId);
        Task<IEnumerable<RevenueCategory>> GetAllAsNoTrackingAsync(int userId);
        Task AddAsync(RevenueCategory revenueCategory);
        Task UpdateAsync(RevenueCategory revenueCategory);
        Task DeleteAsync(RevenueCategory revenueCategory);
    }
}