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
    public class EmployeeDesignationRepository : Repository<EmployeeDesignation>, IEmployeeDesignationRepository
    {
        public EmployeeDesignationRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<EmployeeDesignation> Find(int id)
        {
            return await _context.EmployeeDesignations.FindAsync(id);
        }
        public async Task<IEnumerable<EmployeeDesignation>> GetAll()
        {
            return await _context.EmployeeDesignations.ToListAsync();
        }
        public async Task<IEnumerable<EmployeeDesignation>> GetAll(Expression<Func<EmployeeDesignation, bool>> predicate)
        {
            return await _context.EmployeeDesignations
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<IEnumerable<EmployeeDesignation>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeeDesignation, bool>> predicate)
        {
            return await _context.EmployeeDesignations
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.EmployeeDesignations
                .CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<EmployeeDesignation, bool>> predicate)
        {
            return await _context.EmployeeDesignations
                .CountAsync(predicate);
        }

        public async Task<EmployeeDesignation> SingleOrDefault(Expression<Func<EmployeeDesignation, bool>> predicate)
        {
            return await _context.EmployeeDesignations
                .SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}