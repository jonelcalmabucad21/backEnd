using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IRoleAccessRepository : IRepository<RoleAccess>
    {

        Task<IEnumerable<RoleAccess>> GetAll();
        Task<IEnumerable<RoleAccess>> GetAll(Expression<Func<RoleAccess, bool>> predicate);
        Task<IEnumerable<RoleAccess>> GetAll(int pageIndex, int pageSize, Expression<Func<RoleAccess, bool>> predicate);
        Task<IEnumerable<RoleAccess>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<RoleAccess, bool>> predicate);
        Task<RoleAccess> Find(int id);
        Task<RoleAccess> SingleOrDefault(Expression<Func<RoleAccess, bool>> predicate);
    
         
    }
}