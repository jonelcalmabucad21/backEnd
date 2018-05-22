using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class OffenseType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Offense> Offenses { get; set; } = new Collection<Offense>();
    }
}