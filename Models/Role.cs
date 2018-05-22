using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoleAccess> RoleAccesses { get; set; } = new Collection<RoleAccess>();
        public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();
        

    }
}