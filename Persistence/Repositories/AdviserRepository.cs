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
    public class AdviserRepository : Repository<Adviser>, IAdviserRepository
    {
        public AdviserRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Adviser> Find(int id)
        {
            return await _context.Advisers.FindAsync(id);
        }

        public async Task<IEnumerable<Adviser>> GetAll()
        {
            return await _context.Advisers
                .Include(p => p.Employee)
                .ThenInclude(p => p.Person)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Adviser>> GetAll(Expression<Func<Adviser, bool>> predicate)
        {
            return await _context.Advisers
                .Include(p => p.Employee)
                .ThenInclude(p => p.Person)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Adviser>> GetAll(int pageIndex, int pageSize, Expression<Func<Adviser, bool>> predicate)
        {
            return await _context.Advisers
                .Include(p => p.Employee)
                .ThenInclude(p => p.Person)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Adviser>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Advisers
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Advisers.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Adviser, bool>> predicate)
        {
            return await _context.Advisers
                .Include(p => p.Employee)
                .ThenInclude(p => p.Person)
                .Where(predicate).CountAsync();
        }

        public async Task<Adviser> SingleOrDefault(Expression<Func<Adviser, bool>> predicate)
        {
            return await _context.Advisers
                .Include(p => p.Employee)
                .ThenInclude(p => p.Person)               
                .SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }   
    }
}