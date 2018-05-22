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
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Section> Find(int id)
        {
            return await _context.Sections.FindAsync(id);
        }

        public async Task<IEnumerable<Section>> GetAll()
        {
            return await _context.Sections.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetAll(Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetAll(int pageIndex, int pageSize, Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Sections
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Sections.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections.Where(predicate).CountAsync();
        }

        public async Task<Section> SingleOrDefault(Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}