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
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Level> Find(int id)
        {
            return await _context.Levels.FindAsync(id);
        }

        public async Task<IEnumerable<Level>> GetAll()
        {
            return await _context.Levels.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetAll(Expression<Func<Level, bool>> predicate)
        {
            return await _context.Levels
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetAll(int pageIndex, int pageSize, Expression<Func<Level, bool>> predicate)
        {
            return await _context.Levels
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Level>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Levels
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Levels.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Level, bool>> predicate)
        {
            return await _context.Levels.Where(predicate).CountAsync();
        }

        public async Task<Level> SingleOrDefault(Expression<Func<Level, bool>> predicate)
        {
            return await _context.Levels.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    
    }
}