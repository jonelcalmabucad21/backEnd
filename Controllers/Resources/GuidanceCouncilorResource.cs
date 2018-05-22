using System;

namespace backEnd.Controllers.Resources
{
    public class GuidanceCouncilorResource
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}