using backEnd.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backEnd.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext context)
        {
            dbContext = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() =>  dbContext.Set<TEntity>().Remove(entity));
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => dbContext.Set<TEntity>().RemoveRange(entities));
        }
    }
}
