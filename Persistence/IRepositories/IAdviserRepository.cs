using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IAdviserRepository : IRepository<Adviser>
    {
        Task<IEnumerable<Adviser>> GetAll();
        Task<IEnumerable<Adviser>> GetAll(Expression<Func<Adviser, bool>> predicate);
        Task<IEnumerable<Adviser>> GetAll(int pageIndex, int pageSize, Expression<Func<Adviser, bool>> predicate);
        Task<IEnumerable<Adviser>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Adviser, bool>> predicate);
        Task<Adviser> Find(int id);
        Task<Adviser> SingleOrDefault(Expression<Func<Adviser, bool>> predicate);
         
    }
}