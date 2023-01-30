using Microsoft.EntityFrameworkCore;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Context;

namespace PersonalFinances.Infra.Data.Repository
{
    public class ExpenditureCategoryRepository : IExpenditureCategoryRepository
    {
        private ApplicationDbContext _context;

        
        public ExpenditureCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(ExpenditureCategory expenditureCategory)
        {
            _context.ExpenditureCategories.Add(expenditureCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ExpenditureCategory expenditureCategory)
        {
            _context.ExpenditureCategories.Remove(expenditureCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenditureCategory>> GetByUserIdAsNoTrackingAsync(int userId)
        {
            return await _context.ExpenditureCategories.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<ExpenditureCategory> GetByIdAndUserIdAsNoTrackingAsync(int id, int userId)
        {
            return await _context.ExpenditureCategories.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task<ExpenditureCategory> GetByIdAndUserIdAsync(int id, int userId)
        {
            return await _context.ExpenditureCategories.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task UpdateAsync(ExpenditureCategory expenditureCategory)
        {
            _context.ExpenditureCategories.Update(expenditureCategory);
            await _context.SaveChangesAsync();
        }
    }
}