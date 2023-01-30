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
    public class RevenueRepository : IRevenueRepository
    {
        private ApplicationDbContext _context;

        public RevenueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Revenue revenue)
        {
            _context.Revenues.Add(revenue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Revenue revenue)
        {
            _context.Revenues.Remove(revenue);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Revenue>> GetAllAsync(int userId)
        {
            return await _context.Revenues.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Revenue> GetByIdAsync(int id, int userId)
        {
            return await _context.Revenues.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task UpdateAsync(Revenue revenue)
        {
            _context.Revenues.Update(revenue);
            await _context.SaveChangesAsync();
        }
    }
}