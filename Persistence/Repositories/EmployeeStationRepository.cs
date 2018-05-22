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
    public class EmployeeStationRepository : Repository<EmployeeStation>, IEmployeeStationRepository
    {
        public EmployeeStationRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<EmployeeStation> Find(int id)
        {
            return await _context.EmployeeStations.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeeStation>> GetAll()
        {
            return await _context.EmployeeStations.ToListAsync();
        }

        public async Task<IEnumerable<EmployeeStation>> GetAll(Expression<Func<EmployeeStation, bool>> predicate)
        {
            return await _context.EmployeeStations
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<IEnumerable<EmployeeStation>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeeStation, bool>> predicate)
        {
            return await _context.EmployeeStations
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.EmployeeStations.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<EmployeeStation, bool>> predicate)
        {
            return await _context.EmployeeStations.CountAsync(predicate);
        }

        public async Task<EmployeeStation> SingleOrDefault(Expression<Func<EmployeeStation, bool>> predicate)
        {
            return await _context.EmployeeStations.SingleOrDefaultAsync(predicate);
        }
        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}