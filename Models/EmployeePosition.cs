using System;

namespace backEnd.Models
{
    public class EmployeePosition
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }

        public Employee Employee { get; set; }
        public Position Position { get; set; }
    }
}