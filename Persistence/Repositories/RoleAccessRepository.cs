using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Persistence.Repositories
{
    public class RoleAccessRepository  : Repository<RoleAccess>, IRoleAccessRepository
    {

        public RoleAccessRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<RoleAccess> Find(int id)
        {
            return await _context.RoleAccess.FindAsync(id);
        }

        public async Task<IEnumerable<RoleAccess>> GetAll()
        {
            return await _context.RoleAccess.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<RoleAccess>> GetAll(Expression<Func<RoleAccess, bool>> predicate)
        {
            return await _context.RoleAccess
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<RoleAccess>> GetAll(int pageIndex, int pageSize, Expression<Func<RoleAccess, bool>> predicate)
        {
            return await _context.RoleAccess
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<RoleAccess>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.RoleAccess
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.RoleAccess.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<RoleAccess, bool>> predicate)
        {
            return await _context.RoleAccess.Where(predicate).CountAsync();
        }

        public async Task<RoleAccess> SingleOrDefault(Expression<Func<RoleAccess, bool>> predicate)
        {
            return await _context.RoleAccess.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    
        
    }
}