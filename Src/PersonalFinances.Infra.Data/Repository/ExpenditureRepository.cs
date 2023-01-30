using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Context;

namespace PersonalFinances.Infra.Data.Repository
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private ApplicationDbContext _context;

        public ExpenditureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expenditure expenditure)
        {
            _context.Expenditures.Add(expenditure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expenditure expenditure)
        {
            _context.Expenditures.Remove(expenditure);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expenditure>> GetByUserIdAsync(int userId)
        {
            return await _context.Expenditures.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Expenditure> GetByIdAndUserIdAsync(int id, int userId)
        {
            return await _context.Expenditures.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task UpdateAsync(Expenditure expenditure)
        {
            _context.Expenditures.Update(expenditure);
            await _context.SaveChangesAsync();
        }
    }
}