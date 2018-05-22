using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IEmployeeStationRepository : IRepository<EmployeeStation>
    {

        Task<IEnumerable<EmployeeStation>> GetAll();
        Task<IEnumerable<EmployeeStation>> GetAll(Expression<Func<EmployeeStation, bool>> predicate);
        Task<IEnumerable<EmployeeStation>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeeStation, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<EmployeeStation, bool>> predicate);
        Task<EmployeeStation> Find(int id);
        Task<EmployeeStation> SingleOrDefault(Expression<Func<EmployeeStation, bool>> predicate);        
    }
}