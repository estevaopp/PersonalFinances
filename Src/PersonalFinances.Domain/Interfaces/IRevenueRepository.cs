using System.Linq.Expressions;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IRevenueRepository
    {
        Task<Revenue> GetByIdAsync(int id, int userId);
        Task<IEnumerable<Revenue>> GetAllAsync(int userId);
        Task AddAsync(Revenue revenue, int userId);
        Task UpdateAsync(Revenue revenue, int userId);
        Task DeleteAsync(Revenue revenue, int userId);
    }
}