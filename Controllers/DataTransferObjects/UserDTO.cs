using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }        
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }
        // nav
        public EmployeeDTO Employee { get; set; }
        
        public UserRoleDTO UserRole { get; set; }
        public ICollection<UserAccessDTO> UserAccesses { get; set; } = new Collection<UserAccessDTO>();
    }
}