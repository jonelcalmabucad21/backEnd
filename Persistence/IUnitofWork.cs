using backEnd.Persistence.IRepositories;
using System.Threading.Tasks;

namespace backEnd.Persistence
{
    public interface IUnitofWork
    {

        IPersonRepository PersonRepository { get; }
        
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeStationRepository EmployeeStationRepository { get; }
        IEmployeePositionRepository EmployeePositionRepository { get; }
        IEmployeeDesignationRepository EmployeeDesignationRepository { get; }
        IPositionRepository PositionRepository { get; }
        IStationRepository StationRepository {get; }
        IPrincipalRepository PrincipalRepository { get; }
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRoleAccessRepository RoleAccessRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISectionRepository SectionRepository { get; }
        ILevelSectionRepository LevelSectionRepository { get; }
        ISectionAdviserRepository SectionAdviserRepository { get; }
        ILevelRepository LevelRepository { get; }
        IAdviserRepository AdviserRepository { get; }
        Task Commit();
        
    }
}
