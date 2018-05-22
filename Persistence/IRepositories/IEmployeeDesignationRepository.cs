using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IEmployeeDesignationRepository : IRepository<EmployeeDesignation>
    {

        Task<IEnumerable<EmployeeDesignation>> GetAll();
        Task<IEnumerable<EmployeeDesignation>> GetAll(Expression<Func<EmployeeDesignation, bool>> predicate);
        Task<IEnumerable<EmployeeDesignation>> GetAll(int pageIndex, int pageSize, Expression<Func<EmployeeDesignation, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<EmployeeDesignation, bool>> predicate);
        Task<EmployeeDesignation> Find(int id);
        Task<EmployeeDesignation> SingleOrDefault(Expression<Func<EmployeeDesignation, bool>> predicate);        
            
    }
}