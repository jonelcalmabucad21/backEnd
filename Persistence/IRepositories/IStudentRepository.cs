using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetAll(Expression<Func<Student, bool>> predicate);
        Task<IEnumerable<Student>> GetAll(int pageIndex, int pageSize, Expression<Func<Student, bool>> predicate);
        Task<IEnumerable<Student>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Student, bool>> predicate);
        Task<Student> Find(int id);
        Task<Student> SingleOrDefault(Expression<Func<Student, bool>> predicate);                

    }
}