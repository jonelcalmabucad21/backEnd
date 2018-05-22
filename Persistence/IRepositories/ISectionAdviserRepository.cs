using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface ISectionAdviserRepository : IRepository<SectionAdviser>
    {

        Task<IEnumerable<SectionAdviser>> GetAll();
        Task<IEnumerable<SectionAdviser>> GetAll(Expression<Func<SectionAdviser, bool>> predicate);
        Task<IEnumerable<SectionAdviser>> GetAll(int pageIndex, int pageSize, Expression<Func<SectionAdviser, bool>> predicate);
        Task<IEnumerable<SectionAdviser>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<SectionAdviser, bool>> predicate);
        Task<SectionAdviser> Find(int id);
        Task<SectionAdviser> SingleOrDefault(Expression<Func<SectionAdviser, bool>> predicate);           
    }
}