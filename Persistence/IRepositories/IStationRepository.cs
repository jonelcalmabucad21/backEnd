using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IStationRepository : IRepository<Station>
    {
        Task<IEnumerable<Station>> GetAll();
        Task<IEnumerable<Station>> GetAll(Expression<Func<Station, bool>> predicate);
        Task<IEnumerable<Station>> GetAll(int pageIndex, int pageSize, Expression<Func<Station, bool>> predicate);
        Task<IEnumerable<Station>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Station, bool>> predicate);
        Task<Station> Find(int id);
        Task<Station> SingleOrDefault(Expression<Func<Station, bool>> predicate);                
    }
}