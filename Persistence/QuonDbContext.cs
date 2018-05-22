using backEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace backEnd.Persistence
{
    public class QuonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
        public DbSet<EmployeeStation> EmployeeStations { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<LevelSection> LevelSections { get; set; }
        public DbSet<SectionAdviser> SectionAdvisers { get; set; }
        public DbSet<SectionStudent> SectionStudents { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<PrefectOfDiscipline> PrefectOfDisciplines { get; set; }
        public DbSet<Adviser> Advisers { get; set; }
        public DbSet<GuidanceCouncilor> GuidanceCouncilors { get; set; }

        public DbSet<StudentCase> StudentCases { get; set; }
        public DbSet<InvolveStudent> InvolveStudents { get; set; }
        public DbSet<StudentOffense> StudentOffenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<Access> Access { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserAccess> UserAccess { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<StudentAddress> StudentAdresses { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Relation> Relations { get; set; }
    
        public QuonDbContext(DbContextOptions<QuonDbContext> options)
            : base(options)
        {
            
        }    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
                // Indexes
                // Required
                // Unique
                // Timestamp
                // RelationShip

                //Person
                builder.Entity<Person>(entity => {
                    // Indexes 

                    // Required
                    entity.Property(p => p.FirstName)
                        .IsRequired();
                    entity.Property(p => p.MiddleName)
                        .IsRequired();
                    entity.Property(p => p.LastName)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => new { p.FirstName, p.MiddleName, p.LastName, p.SuffixName })
                        .IsUnique();
                    // TimeStamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    // RelationShips
                });

                //Employee
                builder.Entity<Employee>(entity =>
                {
                    // Indexes
                    entity.HasIndex(p => p.EmployeeNumber)
                        .IsUnique();
                    // RelationShip
                    entity.HasOne(p => p.Person)
                        .WithOne(p => p.Employee)
                        .HasForeignKey<Employee>(p => p.PersonId)
                        .OnDelete(DeleteBehavior.Restrict);
                    // Timestamp
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                });

                // Station
                builder.Entity<Station>(entity =>
                {   
                    // Required
                    entity.Property(p => p.Name)
                        .IsRequired();
                    entity.Property(p => p.StationNumber)
                        .IsRequired();
                    // Unique
                    entity.HasIndex(p => p.StationNumber)
                        .IsUnique();
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                    entity.HasIndex(p => p.SchoolId)
                        .IsUnique();
                        
                        
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                });

                // District
                builder.Entity<District>(entity => {                    
                    entity.HasIndex(p => p.Name)
                        .IsUnique();

                    entity.Property(p => p.Name)
                        .IsRequired();
                });

                // EmployeeStation
                builder.Entity<EmployeeStation>(entity => {
                    
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex(p => new { p.EmployeeId, p.StationId })
                        .IsUnique();
                    
                    // RelationShip
                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.EmployeeStations)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Station)
                        .WithMany(p => p.EmployeeStations)
                        .HasForeignKey(p => p.StationId)
                        .OnDelete(DeleteBehavior.Restrict);
                    
                });

                // Position
                builder.Entity<Position>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.Property(p => p.Name)
                        .IsRequired();

                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });

                // EmployeePosition
                builder.Entity<EmployeePosition>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex( p => new { p.EmployeeId, p.PositionId })
                        .IsUnique();

                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.EmployeePositions)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(p => p.Position)
                        .WithMany(p => p.EmployeePositions)
                        .HasForeignKey(p => p.PositionId)
                        .OnDelete(DeleteBehavior.Restrict);                
                });

                // Designation
                builder.Entity<Designation>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.Property(p => p.Name)
                        .IsRequired();

                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });

                // EmployeeDesignation
                builder.Entity<EmployeeDesignation>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.EmployeeDesignations)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(p => p.Designation)
                        .WithMany(p => p.EmployeeDesignations)
                        .HasForeignKey(p => p.DesignationId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // Level
                builder.Entity<Level>(entity => {
                    entity.Property(p => p.EntryDate)
                         .HasDefaultValueSql("GetUtcDate()");
                    
                    entity.Property(p => p.Name)
                        .IsRequired();

                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });

                // Section
                builder.Entity<Section>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                    entity.Property(p => p.Name)
                        .IsRequired();

                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                });

                // student
                builder.Entity<Student>(entity => {
                    entity.Property(p => p.LrnNumber)
                        .IsRequired();

                    entity.HasIndex(p => p.LrnNumber)
                        .IsUnique();

                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasOne(p => p.Person)
                        .WithOne(p => p.Student)
                        .HasForeignKey<Student>(p => p.PersonId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(p => p.Gender)
                        .WithMany(p => p.Students)
                        .HasForeignKey(p => p.GenderId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // LevelSection
                builder.Entity<LevelSection>(entity => {
                    entity.HasIndex(p => new { p.SectionId, p.SchoolYear, p.StationId, p.LevelId })
                        .IsUnique();

                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    
                    entity.HasOne(p => p.Level)
                        .WithMany(p => p.LevelSections)
                        .HasForeignKey(p => p.LevelId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Section)
                        .WithMany(p => p.LevelSections)
                        .HasForeignKey(p => p.SectionId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Station)
                        .WithMany(p => p.LevelSections)
                        .HasForeignKey(p => p.StationId)
                        .OnDelete(DeleteBehavior.Restrict);

                });

                // SectionAdviser
                builder.Entity<SectionAdviser>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasOne(p => p.Adviser)
                        .WithMany(p => p.SectionAdvisers)
                        .HasForeignKey(p => p.AdviserId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.LevelSection)
                        .WithOne(p => p.SectionAdviser)
                        .HasForeignKey<SectionAdviser>(p => p.LevelSectionId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // SectionStudent
                builder.Entity<SectionStudent>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex(p => new { p.StudentId, p.SchoolYear })
                        .IsUnique();

                    entity.HasOne(p => p.Student)
                        .WithMany(p => p.SectionStudents)
                        .HasForeignKey(p => p.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.SectionAdviser)
                        .WithMany(p => p.SectionStudents)
                        .HasForeignKey(p => p.SectionAdviserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // principal
                builder.Entity<Principal>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    
                    entity.HasIndex(p => new { p.EmployeeId, p.SchoolYear, p.StationId  })
                        .IsUnique();

                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.Principals)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Station)
                        .WithMany(p => p.Principals)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // prefectofDiscipline
                builder.Entity<PrefectOfDiscipline>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex(p => new { p.LevelId, p.EmployeeId, p.SchoolYear })
                        .IsUnique();
                    
                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.PrefectOfDisciplines)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Level)
                        .WithMany(p => p.PrefectOfDisciplines)
                        .HasForeignKey(p => p.LevelId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // Adviser
                builder.Entity<Adviser>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex(p => p.EmployeeId)
                        .IsUnique();

                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.Advisers)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // Guidance Councilor
                builder.Entity<GuidanceCouncilor>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasOne(p => p.Employee)
                        .WithMany(p => p.GuidanceCouncilors)
                        .HasForeignKey(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

                // OffenseType
                builder.Entity<OffenseType>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                    entity.Property(p => p.Name)
                        .IsRequired();

                });

                // Offernse
                builder.Entity<Offense>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                    entity.Property(p => p.Name)
                        .IsRequired();

                    entity.HasOne(p => p.OffenseType)
                        .WithMany(p => p.Offenses)
                        .HasForeignKey(p => p.OffenseTypeId)
                        .OnDelete(DeleteBehavior.Restrict);

                });

                // StudentCase
                builder.Entity<StudentCase>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.Property(p => p.Incident)
                        .IsRequired();
                    entity.HasIndex(p => p.Incident)
                        .IsUnique();
                    
                });

                // InvolveStudent
                builder.Entity<InvolveStudent>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");

                    entity.HasIndex(p => new { p.SectionStudentId, p.StudentCaseId })
                        .IsUnique();

                    entity.HasOne(p => p.StudentCase)
                        .WithMany(p => p.InvolveStudents)
                        .HasForeignKey(p => p.StudentCaseId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.SectionStudent)
                        .WithMany(p => p.InvolveStudents)
                        .HasForeignKey(p => p.SectionStudentId)
                        .OnDelete(DeleteBehavior.Restrict);

                });

                // StudentOffense
                builder.Entity<StudentOffense>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
                    entity.HasIndex(p => new { p.InvolveStudentId, p.OffenseId })
                        .IsUnique();

                    entity.HasOne(p => p.Offense)
                        .WithMany(p => p.StudentOffenses)
                        .HasForeignKey(p => p.OffenseId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.InvolveStudent)
                        .WithMany(p => p.StudentOffenses)
                        .HasForeignKey(p => p.InvolveStudentId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                // User
                builder.Entity<User>(entity => {
                    entity.Property(p => p.EntryDate)
                        .HasDefaultValueSql("GetUtcDate()");
     
                    entity.Property(p => p.Password)
                        .IsRequired();

                    entity.Property(p => p.Password).HasMaxLength(10);

                    entity.HasOne(p => p.Employee)
                        .WithOne(p => p.User)
                        .HasForeignKey<User>(p => p.EmployeeId)
                        .OnDelete(DeleteBehavior.Restrict); 
                });
                // Role
                builder.Entity<Role>(entity => {
                    entity.Property(p => p.Name)
                        .IsRequired();
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                // Access
                builder.Entity<Access>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                    entity.Property(p => p.Name)
                        .IsRequired();
                });
                // UserRoles
                builder.Entity<UserRole>(entity => {
                    entity.HasIndex(p => new  { p.UserId })
                        .IsUnique();
                    entity.HasOne(p => p.Role)
                        .WithMany(p => p.UserRoles)
                        .HasForeignKey(p => p.RoleId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.User)
                        .WithOne(p => p.UserRole)
                        .HasForeignKey<UserRole>(p => p.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                // RoleAccess
                builder.Entity<RoleAccess>(entity => {
                    entity.HasIndex(p => new { p.RoleId, p.AccessId})
                    .IsUnique();

                    entity.HasOne(p => p.Role)
                        .WithMany(p => p.RoleAccesses)
                        .HasForeignKey(p => p.RoleId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(p => p.Access)
                        .WithMany(p => p.RoleAccesses)
                        .HasForeignKey(p => p.AccessId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                // UserAccess
                builder.Entity<UserAccess>(entity => {
                    entity.HasIndex(p => new { p.UserId, p.AccessId })
                        .IsUnique();
                    entity.HasOne(p => p.Access)
                        .WithMany(p => p.UserAccesses)
                        .HasForeignKey(p => p.AccessId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.User)
                        .WithMany(p => p.UserAccesses)
                        .HasForeignKey(p => p.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                // streets
                builder.Entity<Street>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                // barangays
                builder.Entity<Barangay>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                // municipalities
                builder.Entity<Municipality>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                //province
                builder.Entity<Province>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                // StudentAddresses
                builder.Entity<StudentAddress>(entity => {
                    entity.HasIndex(p => new { p.StudentId, p.ProvinceId, p.BarangayId, p.MunicipalityId })
                        .IsUnique();

                    entity.HasOne(p => p.Street)
                        .WithMany(p => p.StudentAddresses)
                        .HasForeignKey(p => p.StreetId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Barangay)
                        .WithMany(p => p.StudentAddresses)
                        .HasForeignKey(p => p.BarangayId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Municipality)
                        .WithMany(p => p.StudentAddresses)
                        .HasForeignKey(p => p.MunicipalityId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Province)
                        .WithMany(p => p.StudentAddresses)
                        .HasForeignKey(p => p.ProvinceId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Student)
                        .WithMany(p => p.StudentAddresses)
                        .HasForeignKey(p => p.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
                // Relation
                builder.Entity<Relation>(entity => {
                    entity.HasIndex(p => p.Name)
                        .IsUnique();
                });
                // Guardian
                builder.Entity<Guardian>(entity => {
                    entity.HasIndex(p => new { p.StudentId, p.PersonId })
                        .IsUnique();

                    entity.HasOne(p => p.Student)
                        .WithMany(p => p.Guardians)
                        .HasForeignKey(p => p.StudentId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Person)
                        .WithOne(p => p.Guardian)
                        .HasForeignKey<Guardian>(p => p.PersonId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity.HasOne(p => p.Relation)
                        .WithMany(p => p.Guardians)
                        .HasForeignKey(p => p.RelationId)
                        .OnDelete(DeleteBehavior.Restrict);
                });
            
        }
    }

}