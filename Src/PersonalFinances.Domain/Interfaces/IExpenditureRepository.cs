using System.Linq.Expressions;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IExpenditureRepository
    {
        Task<Expenditure> GetByIdAndUserIdAsync(int id, int UserId);
        Task<IEnumerable<Expenditure>> GetByUserIdAsync(int UserId);
        Task AddAsync(Expenditure expenditure);
        Task UpdateAsync(Expenditure expenditure);
        Task DeleteAsync(Expenditure expenditure);
    }
}