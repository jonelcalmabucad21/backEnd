using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Offense
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int OffenseTypeId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigations
        public OffenseType OffenseType { get; set; }

        public ICollection<StudentOffense> StudentOffenses { get; set; } = new Collection<StudentOffense>();

    }
}