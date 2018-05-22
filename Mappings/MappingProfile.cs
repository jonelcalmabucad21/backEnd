using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using backEnd.Controllers.DataTransferObjects;
using backEnd.Controllers.Resources;
using backEnd.Models;

namespace backEnd.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                // *************************Domain to DTO*******************************

                // **** Employee Module ****
                CreateMap<Person, PersonDTO>();
                CreateMap<Station, StationDTO>();
                CreateMap<EmployeeStation, EmployeeStationDTO>(); 
                CreateMap<Position, PositionDTO>();
                CreateMap<EmployeePosition, EmployeePositionDTO>();
                CreateMap<Employee, EmployeeDTO>()
                    .ForMember(employee => employee.Position,
                        opt => opt.MapFrom(src => src.EmployeePositions.LastOrDefault().Position))
                    .ForMember(employee => employee.Station,
                        opt => opt.MapFrom(src => src.EmployeeStations.LastOrDefault().Station));
            
                // **** User Module ****
                CreateMap<Role, RoleDTO>();
                CreateMap<Access, AccessDTO>();
                CreateMap<RoleAccess, RoleAccessDTO>(); 
                CreateMap<UserRole, UserRoleDTO>();
                CreateMap<User, UserDTO>(); 
                CreateMap<UserAccess, UserAccessDTO>(); 

                // **** Student Module ****
                CreateMap<Gender, GenderDTO>();
                CreateMap<Street, StreetDTO>();
                CreateMap<Barangay, BarangayDTO>();
                CreateMap<Municipality, MunicipalityDTO>();
                CreateMap<Province, ProvinceDTO>();
                CreateMap<Student, StudentDTO>();
                CreateMap<StudentAddress, StudentAddressDTO>();
                CreateMap<Guardian, GuardianDTO>();
                CreateMap<Relation, RelationDTO>(); 
                CreateMap<Section, SectionDTO>();
                    
                // **** Level Section Module ****
                CreateMap<Level, LevelDTO>();
                CreateMap<LevelSection, LevelSectionDTO>();
                CreateMap<SectionAdviser, SectionAdviserDTO>();
                CreateMap<Adviser, AdviserDTO>();

                // **** SectionAdviser Modeule ****
                CreateMap<LevelSection, LevelSection01DTO>();
                CreateMap<SectionAdviser, SectionAdviser01DTO>();
                CreateMap<SectionStudent, SectionStudentDTO>();
                
                
                // *************************DTO to Domain*******************************
                // **** Employee Module ****
                CreateMap<PersonDTO, Person>();
                CreateMap<StationDTO, Station>();
                CreateMap<EmployeeStationDTO, EmployeeStation>();
                CreateMap<PositionDTO, Position>();
                CreateMap<EmployeePositionDTO, EmployeePosition>();
                CreateMap<EmployeeDTO, Employee>();

                // **** User Module ****
                CreateMap<RoleDTO, Role>();
                CreateMap<AccessDTO, Access>();
                CreateMap<RoleAccessDTO, RoleAccess>();
                CreateMap<UserRoleDTO, UserRole>();
                CreateMap<UserDTO, User>(); 
                CreateMap<UserAccessDTO, UserAccess>(); 

                // **** Student Module ****
                CreateMap<GenderDTO, Gender>();
                CreateMap<StreetDTO, Street>();
                CreateMap<BarangayDTO, Barangay>();
                CreateMap<MunicipalityDTO, Municipality>();
                CreateMap<ProvinceDTO, Province>();
                CreateMap<StudentDTO, Student>();
                CreateMap<StudentAddressDTO, StudentAddress>();
                CreateMap<GuardianDTO, Guardian>();       
                CreateMap<RelationDTO, Relation>();
                CreateMap<SectionDTO, Section>();


                // **** LevelSection Module ****
                CreateMap<Level, LevelDTO>();
                CreateMap<LevelSectionDTO, LevelSection>();
                CreateMap<SectionAdviserDTO, SectionAdviser>();
                CreateMap<AdviserDTO, Adviser>();

                // **** SectionAdviser Modeule ****
                CreateMap<LevelSection01DTO, LevelSection>();
                CreateMap<SectionAdviser01DTO, SectionAdviser>();
                CreateMap<SectionStudentDTO, SectionStudent>();
                
        }
    }
}