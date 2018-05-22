using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.Resources
{
    public class UserSaveResource
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public UserRoleResource UserRole { get; set; }
        
    }
}