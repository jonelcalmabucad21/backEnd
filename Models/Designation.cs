using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Designation
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }


        public ICollection<EmployeeDesignation> EmployeeDesignations { get; set; } = new Collection<EmployeeDesignation>();
    }
}