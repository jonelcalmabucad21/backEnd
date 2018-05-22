using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Station
    {
        public int Id { get; set; }

        public int StationNumber { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public ICollection<EmployeeStation> EmployeeStations { get; set; } = new Collection<EmployeeStation>();
        public ICollection<Principal> Principals { get; set; } = new Collection<Principal>();
        public ICollection<LevelSection> LevelSections { get; set; } = new Collection<LevelSection>();
    }
}