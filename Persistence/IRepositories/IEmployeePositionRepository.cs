using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IEmployeePositionRepository : IRepository<EmployeePosition>
    {

        Task<IEnumerable<EmployeePosition>> GetAll();
        Task<IEnumerable<EmployeePosition>> GetAll(Expression<Func<EmployeePosition, bool>> predicate);
        Task<IEnumerable<EmployeePosition>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeePosition, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<EmployeePosition, bool>> predicate);
        Task<EmployeePosition> Find(int id);
        Task<EmployeePosition> SingleOrDefault(Expression<Func<EmployeePosition, bool>> predicate);        
    }
}