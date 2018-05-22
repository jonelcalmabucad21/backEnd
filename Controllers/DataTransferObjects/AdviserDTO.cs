using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class AdviserDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public EmployeeDTO Employee { get; set; }
        
    }
}