using backEnd.Persistence.IRepositories;
using backEnd.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace backEnd.Persistence
{
    public class UnitofWork : IUnitofWork
    {
        private readonly QuonDbContext _context;
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IPersonRepository PersonRepository { get; set; }
        public IEmployeeStationRepository EmployeeStationRepository { get; set; }
        public IEmployeePositionRepository EmployeePositionRepository { get; set; }
        public IEmployeeDesignationRepository EmployeeDesignationRepository { get; set; }
        public IPositionRepository PositionRepository { get; set; }
        public IStationRepository StationRepository { get; set; }
        public IPrincipalRepository PrincipalRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IRoleAccessRepository RoleAccessRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public ISectionRepository SectionRepository { get; set; }
        public ILevelSectionRepository LevelSectionRepository { get; set; }
        public ISectionAdviserRepository SectionAdviserRepository { get; set; }
        public ILevelRepository LevelRepository { get; set; }
        public IAdviserRepository AdviserRepository { get; set; }
        public UnitofWork(QuonDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
            PersonRepository = new PersonRepository(_context);          
            EmployeeStationRepository = new EmployeeStationRepository(_context);   
            EmployeePositionRepository = new EmployeePositionRepository(_context);         
            EmployeeDesignationRepository = new EmployeeDesignationRepository(_context);  
            PositionRepository = new PositionRepository(_context);
            StationRepository = new StationRepository(_context);
            PrincipalRepository = new PrincipalRepository(_context);
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            RoleAccessRepository = new RoleAccessRepository(_context);
            StudentRepository = new StudentRepository(_context);
            SectionRepository = new SectionRepository(_context);
            LevelSectionRepository = new LevelSectionRepository(_context);
            SectionAdviserRepository =  new SectionAdviserRepository(_context);
            LevelRepository = new LevelRepository(_context);
            AdviserRepository = new AdviserRepository(_context);
        }


        public async Task Commit()
        {
           await _context.SaveChangesAsync();

        }
    }
}
