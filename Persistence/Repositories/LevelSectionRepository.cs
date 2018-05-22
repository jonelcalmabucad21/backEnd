using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backEnd.Models;
using backEnd.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Persistence.Repositories
{
    public class LevelSectionRepository : Repository<LevelSection>, ILevelSectionRepository
    {
         public LevelSectionRepository(QuonDbContext context)
            :base(context)
        {

        }
        public async Task<LevelSection> Find(int id)
        {
            return await _context.LevelSections.FindAsync(id);
        }

        public async Task<IEnumerable<LevelSection>> GetAll()
        {
            return await _context.LevelSections
                .Include(p => p.Level)
                .Include(p => p.Section)
                .Include(p => p.Station)
                .Include(p => p.SectionAdviser)
                    .ThenInclude(a => a.Adviser)
                    .ThenInclude(e => e.Employee)
                    .ThenInclude(p => p.Person)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<LevelSection>> GetAll(Expression<Func<LevelSection, bool>> predicate)
        {
            return await _context.LevelSections
                .Include(p => p.Level)
                .Include(p => p.Section)
                .Include(p => p.Station)
                .Include(p => p.SectionAdviser)
                    .ThenInclude(a => a.Adviser)
                    .ThenInclude(e => e.Employee)
                    .ThenInclude(p => p.Person)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<LevelSection>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.LevelSections
                .Include(p => p.Level)
                .Include(p => p.Section)
                .Include(p => p.Station)
                .Include(p => p.SectionAdviser)
                    .ThenInclude(a => a.Adviser)
                    .ThenInclude(e => e.Employee)
                    .ThenInclude(p => p.Person)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<LevelSection>> GetAll(int pageIndex, int pageSize, Expression<Func<LevelSection, bool>> predicate)
        {
            return await _context.LevelSections
                .Include(p => p.Level)
                .Include(p => p.Section)
                .Include(p => p.Station)
                .Include(p => p.SectionAdviser)
                    .ThenInclude(a => a.Adviser)
                    .ThenInclude(e => e.Employee)
                    .ThenInclude(p => p.Person)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.LevelSections.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<LevelSection, bool>> predicate)
        {
            return await _context.LevelSections.CountAsync(predicate);
        }

        public async Task<LevelSection> SingleOrDefault(Expression<Func<LevelSection, bool>> predicate)
        {
            return await _context.LevelSections
                .Include(p => p.Level)
                .Include(p => p.Section)
                .Include(p => p.Station)
                .Include(p => p.SectionAdviser)
                    .ThenInclude(a => a.Adviser)
                    .ThenInclude(e => e.Employee)
                    .ThenInclude(p => p.Person)
                .SingleOrDefaultAsync(predicate);
        }
        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }       
    }
}