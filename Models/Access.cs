using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Access
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoleAccess> RoleAccesses { get; set; } = new Collection<RoleAccess>();
        public ICollection<UserAccess> UserAccesses { get; set; } = new Collection<UserAccess>();
    }
}