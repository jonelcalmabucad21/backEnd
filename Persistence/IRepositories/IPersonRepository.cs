using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace backEnd.Persistence.IRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Person>> GetAll(Expression<Func<Person, bool>> predicate);
        Task<IEnumerable<Person>> GetAll(int pageIndex, int pageSize, Expression<Func<Person, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Person, bool>> predicate);
        Task<Person> Find(int id);
        Task<Person> SingleOrDefault(Expression<Func<Person, bool>> predicate);
    }
}
