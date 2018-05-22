using System;

namespace backEnd.Models
{
    public class Principal
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public int SchoolYear { get; set; }
        public int StationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public Employee Employee { get; set; }
        public Station Station { get; set; }
    }
}