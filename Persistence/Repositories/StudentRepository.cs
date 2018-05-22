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
    
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(QuonDbContext context)
            :base(context)
        {

        }
        
        public async Task<Student> Find(int id)
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .FirstAsync(student => student.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .OrderByDescending(p => p.Id).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAll(Expression<Func<Student, bool>> predicate)
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAll(int pageIndex, int pageSize, Expression<Func<Student, bool>> predicate)
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .Where(predicate)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAll(int pageIndex, int pageSize)
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .OrderByDescending(p => p.Id)
                .Skip(pageSize * (pageIndex -1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCount()
        {
            return await _context.Students.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Student, bool>> predicate)
        {
            return await _context.Students.Where(predicate).CountAsync();
        }

        public async Task<Student> SingleOrDefault(Expression<Func<Student, bool>> predicate)
        {
            return await _context.Students
                .Include(p => p.Person)
                .Include(sa1 => sa1.StudentAddresses)
                    .ThenInclude(b => b.Barangay)
                    .ThenInclude(sa2 => sa2.StudentAddresses)
                    .ThenInclude(m => m.Municipality)
                    .ThenInclude(sa3 => sa3.StudentAddresses)
                    .ThenInclude(p => p.Province)
                    .ThenInclude(sa4 => sa4.StudentAddresses)
                    .ThenInclude(s => s.Street)
                .Include(g => g.Gender)
                .Include(g => g.Guardians)
                    .ThenInclude(p => p.Person)
                .Include(g => g.Guardians)
                    .ThenInclude(x => x.Relation)
                .SingleOrDefaultAsync(predicate);
        }

        public QuonDbContext _context
        {
            get { return dbContext as QuonDbContext; }
        }
    }
}