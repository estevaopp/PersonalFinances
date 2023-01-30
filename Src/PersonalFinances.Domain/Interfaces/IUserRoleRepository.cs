using System.Linq.Expressions;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<UserRole> GetByIdAsync(int id);
        Task<UserRole> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsNoTrackingAsync();
        Task AddAsync(UserRole userRole);
        Task UpdateAsync(UserRole userRole);
        Task DeleteAsync(UserRole userRole);
    }
}