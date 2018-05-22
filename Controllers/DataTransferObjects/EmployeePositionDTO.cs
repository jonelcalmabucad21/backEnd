using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class EmployeePositionDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public PositionDTO Position { get; set; }
    }
}