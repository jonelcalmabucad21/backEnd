using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int SchoolId { get; set; }
        public string Station { get; set; }
        public RoleResource Role { get; set; }
        public ICollection<AccessResource> Claims { get; set; } = new Collection<AccessResource>();

        
    }
}