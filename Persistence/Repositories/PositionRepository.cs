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
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Position> Find(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _context.Positions.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetAll(Expression<Func<Position, bool>> predicate)
        {
            return await _context.Positions
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetAll(int pageIndex, int pageSize, Expression<Func<Position, bool>> predicate)
        {
            return await _context.Positions
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Positions
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Positions.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Position, bool>> predicate)
        {
            return await _context.Positions.Where(predicate).CountAsync();
        }

        public async Task<Position> SingleOrDefault(Expression<Func<Position, bool>> predicate)
        {
            return await _context.Positions.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}