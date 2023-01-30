using System.Linq.Expressions;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Domain.Interfaces
{
    public interface IExpenditureRepository
    {
        Task<Expenditure> GetByIdAsync(int id, int userId);
        Task<IEnumerable<Expenditure>> GetAllAsync(int userId);
        Task AddAsync(Expenditure expenditure, int userId);
        Task UpdateAsync(Expenditure expenditure, int userId);
        Task DeleteAsync(Expenditure expenditure, int userId);
    }
}