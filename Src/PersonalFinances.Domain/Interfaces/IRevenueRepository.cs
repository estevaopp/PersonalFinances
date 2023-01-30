using System.Linq.Expressions;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRevenueRepository
    {
        Task<Revenue> GetByIdAndUserIdAsync(int id, int userId);
        Task<IEnumerable<Revenue>> GetByUserIdAsync(int userId);
        Task AddAsync(Revenue revenue);
        Task UpdateAsync(Revenue revenue);
        Task DeleteAsync(Revenue revenue);
    }
}