using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {

        Task<IEnumerable<Role>> GetAll();
        Task<IEnumerable<Role>> GetAll(Expression<Func<Role, bool>> predicate);
        Task<IEnumerable<Role>> GetAll(int pageIndex, int pageSize, Expression<Func<Role, bool>> predicate);
        Task<IEnumerable<Role>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Role, bool>> predicate);
        Task<Role> Find(int id);
        Task<Role> SingleOrDefault(Expression<Func<Role, bool>> predicate);         
    }
}