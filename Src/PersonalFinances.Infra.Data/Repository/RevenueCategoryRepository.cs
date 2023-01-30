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
    public class RevenueCategoryRepository : IRevenueCategoryRepository
    {
        private ApplicationDbContext _context;

        
        public RevenueCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(RevenueCategory revenueCategory)
        {
            _context.RevenueCategories.Add(revenueCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RevenueCategory revenueCategory)
        {
            _context.RevenueCategories.Remove(revenueCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RevenueCategory>> GetAllAsNoTrackingAsync(int userId)
        {
            return await _context.RevenueCategories.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<RevenueCategory> GetByIdAsNoTrackingAsync(int id, int userId)
        {
            return await _context.RevenueCategories.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task<RevenueCategory> GetByIdAsync(int id, int userId)
        {
            return await _context.RevenueCategories.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task UpdateAsync(RevenueCategory revenueCategory)
        {
            _context.RevenueCategories.Update(revenueCategory);
            await _context.SaveChangesAsync();
        }
    }
}