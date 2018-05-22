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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<User> Find(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                    .ThenInclude(es => es.Employee.EmployeeStations)
                    .ThenInclude(s => s.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Role)
                .Include(p => p.UserAccesses)
                    .ThenInclude(p => p.Access)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                    .ThenInclude(es => es.Employee.EmployeeStations)
                    .ThenInclude(s => s.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Role)
                .Include(p => p.UserAccesses)
                    .ThenInclude(p => p.Access)
                .OrderByDescending(p => p.Id)
                .Where(predicate).OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Users
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                    .ThenInclude(es => es.Employee.EmployeeStations)
                    .ThenInclude(s => s.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Role)
                .Include(p => p.UserAccesses)
                    .ThenInclude(p => p.Access)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();;
        }

        public async Task<IEnumerable<User>> GetAll(int pageIndex, int pageSize, Expression<Func<User, bool>> predicate)
        {
            return await _context.Users
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                    .ThenInclude(es => es.Employee.EmployeeStations)
                    .ThenInclude(s => s.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Role)
                .Include(p => p.UserAccesses)
                    .ThenInclude(p => p.Access)
                .OrderByDescending(p => p.Id)
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();;
        }

        public async Task<int> GetCount()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.Where(predicate).CountAsync();
        }

        public async Task<User> SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users
                .Include(p => p.Employee)
                    .ThenInclude(p => p.Person)
                    .ThenInclude(es => es.Employee.EmployeeStations)
                    .ThenInclude(s => s.Station)
                .Include(p => p.Employee)
                    .ThenInclude(p => p.EmployeePositions)
                    .ThenInclude(p => p.Position)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Role)
                .Include(p => p.UserAccesses)
                    .ThenInclude(p => p.Access)
                .SingleOrDefaultAsync(predicate);
        }
        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}