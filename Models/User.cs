using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class User
    {
        public int Id { get; set; }        
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Password { get; set; }
        public DateTime EntryDate { get; set; }
        // nav
        public Employee Employee { get; set; }
        
        public UserRole UserRole { get; set; }
        public ICollection<UserAccess> UserAccesses { get; set; } = new Collection<UserAccess>();
        
    }
}