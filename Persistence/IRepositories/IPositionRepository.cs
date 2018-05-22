using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<IEnumerable<Position>> GetAll();
        Task<IEnumerable<Position>> GetAll(Expression<Func<Position, bool>> predicate);
        Task<IEnumerable<Position>> GetAll(int pageIndex, int pageSize, Expression<Func<Position, bool>> predicate);
        Task<IEnumerable<Position>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Position, bool>> predicate);
        Task<Position> Find(int id);
        Task<Position> SingleOrDefault(Expression<Func<Position, bool>> predicate);        
    }
}