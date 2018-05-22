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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {

        public RoleRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Role> Find(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetAll(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetAll(int pageIndex, int pageSize, Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Roles
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Roles.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles.Where(predicate).CountAsync();
        }

        public async Task<Role> SingleOrDefault(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    
    }

}