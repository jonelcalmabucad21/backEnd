using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;

namespace backEnd.Persistence.IRepositories
{
    public interface ILevelSectionRepository : IRepository<LevelSection>
    {
        Task<IEnumerable<LevelSection>> GetAll();
        Task<IEnumerable<LevelSection>> GetAll(Expression<Func<LevelSection, bool>> predicate);
        Task<IEnumerable<LevelSection>> GetAll(int pageIndex, int pageSize, Expression<Func<LevelSection, bool>> predicate);
        Task<IEnumerable<LevelSection>> GetAll(int pageIndex, int pageSize);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<LevelSection, bool>> predicate);
        Task<LevelSection> Find(int id);
        Task<LevelSection> SingleOrDefault(Expression<Func<LevelSection, bool>> predicate);            
    }
}