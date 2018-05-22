using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string EmployeeNumber { get; set; }  
        public int PersonId { get; set; }   
        public DateTime EntryDate { get; set; }

        public Person Person { get; set; }
        public User User { get; set; }
        public ICollection<EmployeeStation> EmployeeStations { get; set; } = new Collection<EmployeeStation>();
        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new Collection<EmployeePosition>();
        public ICollection<EmployeeDesignation> EmployeeDesignations { get; set; } = new Collection<EmployeeDesignation>();
        public ICollection<Adviser> Advisers { get; set; } = new Collection<Adviser>();
        public ICollection<Principal> Principals { get; set; } = new Collection<Principal>();
        public ICollection<PrefectOfDiscipline> PrefectOfDisciplines { get; set; } = new Collection<PrefectOfDiscipline>();
        public ICollection<GuidanceCouncilor> GuidanceCouncilors { get; set; } = new Collection<GuidanceCouncilor>();

    }
}