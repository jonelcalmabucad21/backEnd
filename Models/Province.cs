using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StudentAddress> StudentAddresses { get; set; } = new Collection<StudentAddress>();
    }
}