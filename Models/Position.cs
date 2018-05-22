using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<EmployeePosition> EmployeePositions { get; set; } = new Collection<EmployeePosition>();
    }
}