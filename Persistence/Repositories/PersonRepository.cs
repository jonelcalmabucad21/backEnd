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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<Person> Find(int id)
        {
            return await _context.Persons
                .FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetAll(Expression<Func<Person, bool>> predicate)
        {
            return await _context.Persons
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Person>> GetAll(int pageIndex, int pageSize, Expression<Func<Person, bool>> predicate)
        {
            return await _context.Persons
                .Where(predicate)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<int> GetCount()
        {
            return _context.Persons.CountAsync();
        }

        public Task<int> GetCount(Expression<Func<Person, bool>> predicate)
        {
            return _context.Persons.CountAsync(predicate);
        }

        public Task<Person> SingleOrDefault(Expression<Func<Person, bool>> predicate)
        {
            return _context.Persons.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}