using backEnd.Models;
using backEnd.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore; 
using backEnd.Controllers;

namespace backEnd.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public int[] EmployeeIds { get; set; }
        
        public  EmployeeRepository(QuonDbContext context)
            :base(context)
        {
                 
        }

        public async Task GetEmployeeIds()
        {
            EmployeeIds = await _context.EmployeeStations.Where(p => p.StationId == StationId.Id && p.EndDate == null).Select(u => u.EmployeeId).ToArrayAsync();
        }
        public async Task<Employee> Find(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
             await GetEmployeeIds(); 

            return await _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .OrderByDescending(p => p.Id)
                .Where(p => EmployeeIds.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize, Expression<Func<Employee, bool>> predicate)
        {
            await GetEmployeeIds();

            return await _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .Where(p => EmployeeIds.Contains(p.Id))
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize)
        {
            await GetEmployeeIds();

            return await _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .Where(p => EmployeeIds.Contains(p.Id))
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<Employee>> GetAll(Expression<Func<Employee, bool>> predicate)
        {
            await GetEmployeeIds();

            return await _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .Where(p => EmployeeIds.Contains(p.Id))
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Employee, bool>> predicate)
        {
            return await _context.Employees.CountAsync(predicate);
        }

        public async Task<Employee> SingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return await _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeForRegistration()
        {
            return await  _context.Employees
                .Include(p => p.EmployeeStations)
                    .ThenInclude(p => p.Station)
                .Include(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.EmployeeDesignations)
                .Include(p => p.Advisers)
                .Include(p => p.GuidanceCouncilors)
                .Include(p => p.PrefectOfDisciplines)
                .Include(p => p.Principals)
                .Include(p => p.Person)
                .Where(p => EmployeeIds.Contains(p.Id))
                .Where(p => p.User == null)
                .ToListAsync();
        }
        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}
