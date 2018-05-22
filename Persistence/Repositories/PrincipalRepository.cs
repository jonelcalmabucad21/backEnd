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
    public class PrincipalRepository : Repository<Principal>, IPrincipalRepository
    {

        public PrincipalRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Principal> Find(int id)
        {
            return await _context.Principals.FindAsync(id);
        }

        public async Task<IEnumerable<Principal>> GetAll()
        {
            return await _context.Principals
                .Include(p => p.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                        .ThenInclude(p => p.Position)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeeStations)
                        .ThenInclude(p => p.Station)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Principal>> GetAll(Expression<Func<Principal, bool>> predicate)
        {
            return await _context.Principals
                .Include(p => p.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                        .ThenInclude(p => p.Position)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeeStations)
                        .ThenInclude(p => p.Station)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Principal>> GetAll(int pageIndex, int pageSize, Expression<Func<Principal, bool>> predicate)
        {
            return await _context.Principals
                .Include(p => p.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                        .ThenInclude(p => p.Position)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeeStations)
                        .ThenInclude(p => p.Station)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Principal>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Principals
                .Include(p => p.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                        .ThenInclude(p => p.Position)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeeStations)
                        .ThenInclude(p => p.Station)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Principals.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Principal, bool>> predicate)
        {
            return await _context.Principals.Where(predicate).CountAsync();
        }

        public async Task<Principal> SingleOrDefault(Expression<Func<Principal, bool>> predicate)
        {
            return await _context.Principals
                .Include(p => p.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                        .ThenInclude(p => p.Position)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeeStations)
                        .ThenInclude(p => p.Station)
                .SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }        
}