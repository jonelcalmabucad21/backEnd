using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface ILevelRepository : IRepository<Level>
    {

        Task<IEnumerable<Level>> GetAll();
        Task<IEnumerable<Level>> GetAll(Expression<Func<Level, bool>> predicate);
        Task<IEnumerable<Level>> GetAll(int pageIndex, int pageSize, Expression<Func<Level, bool>> predicate);
        Task<IEnumerable<Level>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Level, bool>> predicate);
        Task<Level> Find(int id);
        Task<Level> SingleOrDefault(Expression<Func<Level, bool>> predicate); 
    }
}