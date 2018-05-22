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
    public class SectionAdviserRepository : Repository<SectionAdviser>, ISectionAdviserRepository
    {
        public SectionAdviserRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<SectionAdviser> Find(int id)
        {
            return await _context.SectionAdvisers.FindAsync(id);
        }

        public async Task<IEnumerable<SectionAdviser>> GetAll()
        {
            return await _context.SectionAdvisers
                .Include(p => p.Adviser)
                    .ThenInclude(p => p.Employee)
                    .ThenInclude(p => p.Person)
                .Include(p => p.LevelSection)
                    .ThenInclude(p => p.Level)
                    .ThenInclude(p => p.LevelSections)
                    .ThenInclude(p => p.Section)
                .OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<SectionAdviser>> GetAll(Expression<Func<SectionAdviser, bool>> predicate)
        {
            return await _context.SectionAdvisers
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<SectionAdviser>> GetAll(int pageIndex, int pageSize, Expression<Func<SectionAdviser, bool>> predicate)
        {
            return await _context.SectionAdvisers
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<SectionAdviser>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.SectionAdvisers
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.SectionAdvisers.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<SectionAdviser, bool>> predicate)
        {
            return await _context.SectionAdvisers.Where(predicate).CountAsync();
        }

        public async Task<SectionAdviser> SingleOrDefault(Expression<Func<SectionAdviser, bool>> predicate)
        {
            return await _context.SectionAdvisers.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }     
    }
}