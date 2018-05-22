using System;

namespace backEnd.Models
{
    public class GuidanceCouncilor
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }

        // navigations
        public Employee Employee { get; set; }
    }
}