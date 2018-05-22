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
    public class StationRepository : Repository<Station>, IStationRepository
    {
        public StationRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Station> Find(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task<IEnumerable<Station>> GetAll()
        {
            return await _context.Stations.OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Station>> GetAll(Expression<Func<Station, bool>> predicate)
        {
            return await _context.Stations
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Station>> GetAll(int pageIndex, int pageSize, Expression<Func<Station, bool>> predicate)
        {
            return await _context.Stations
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Station>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Stations
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Stations.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Station, bool>> predicate)
        {
            return await _context.Stations.Where(predicate).CountAsync();
        }

        public async Task<Station> SingleOrDefault(Expression<Func<Station, bool>> predicate)
        {
            return await _context.Stations.SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}