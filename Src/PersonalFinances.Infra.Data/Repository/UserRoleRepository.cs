using Microsoft.EntityFrameworkCore;
using PersonalFinances.Domain.Entities;
using PersonalFinances.Domain.Interfaces;
using PersonalFinances.Infra.Data.Context;

namespace PersonalFinances.Infra.Data.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private ApplicationDbContext _context;

        
        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserRole userRole)
        {
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRole>> GetAllAsNoTrackingAsync()
        {
            return await _context.UserRoles.AsNoTracking().ToListAsync();
        }

        public async Task<UserRole> GetByIdAsNoTrackingAsync(int id)
        {
            return await _context.UserRoles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
        }
    }
}