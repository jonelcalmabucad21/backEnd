using System;

namespace backEnd.Models
{
    public class EmployeeStation
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int StationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public Employee Employee { get; set; }
        public Station Station { get; set; }
    }
}