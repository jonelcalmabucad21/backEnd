using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Relation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guardian> Guardians { get; set; } = new Collection<Guardian>();
    }
}