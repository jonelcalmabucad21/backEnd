using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetAll(int pageIndex, int pageSize);
        Task<IEnumerable<User>> GetAll(int pageIndex, int pageSize, Expression<Func<User, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<User, bool>> predicate);
        Task<User> Find(int id);
        Task<User> SingleOrDefault(Expression<Func<User, bool>> predicate);         
    }
}