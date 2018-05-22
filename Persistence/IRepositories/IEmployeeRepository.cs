using backEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace backEnd.Persistence.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<Employee>> GetAll(Expression<Func<Employee, bool>> predicate);
        Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize);
        Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize, Expression<Func<Employee, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Employee, bool>> predicate);
        Task<Employee> Find(int id);
        Task<Employee> SingleOrDefault(Expression<Func<Employee, bool>> predicate);
        Task<IEnumerable<Employee>> GetEmployeeForRegistration();

        Task GetEmployeeIds();

        int[] EmployeeIds { get; set; }

    }
}
