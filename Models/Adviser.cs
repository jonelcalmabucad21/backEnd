using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class 
    Adviser
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public Employee Employee { get; set; }
        public ICollection<SectionAdviser> SectionAdvisers { get; set; } = new Collection<SectionAdviser>();
    }
}