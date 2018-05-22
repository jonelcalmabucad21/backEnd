using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IPrincipalRepository : IRepository<Principal>
    {
        Task<IEnumerable<Principal>> GetAll();
        Task<IEnumerable<Principal>> GetAll(Expression<Func<Principal, bool>> predicate);
        Task<IEnumerable<Principal>> GetAll(int pageIndex, int pageSize, Expression<Func<Principal, bool>> predicate);
        Task<IEnumerable<Principal>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Principal, bool>> predicate);
        Task<Principal> Find(int id);
        Task<Principal> SingleOrDefault(Expression<Func<Principal, bool>> predicate);          
    }
}