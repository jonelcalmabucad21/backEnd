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
    public class EmployeePositionRepository : Repository<EmployeePosition>, IEmployeePositionRepository
    {
        public EmployeePositionRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<EmployeePosition> Find(int id)
        {
            return await _context.EmployeePositions.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeePosition>> GetAll()
        {
            return await _context.EmployeePositions.ToListAsync();
        }

        public async Task<IEnumerable<EmployeePosition>> GetAll(Expression<Func<EmployeePosition, bool>> predicate)
        {
            return await _context.EmployeePositions
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<IEnumerable<EmployeePosition>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeePosition, bool>> predicate)
        {
            return await _context.EmployeePositions
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.EmployeePositions.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<EmployeePosition, bool>> predicate)
        {
            return await _context.EmployeePositions.CountAsync(predicate);
        }

        public async Task<EmployeePosition> SingleOrDefault(Expression<Func<EmployeePosition, bool>> predicate)
        {
            return await _context.EmployeePositions.SingleOrDefaultAsync(predicate);
        }
        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}