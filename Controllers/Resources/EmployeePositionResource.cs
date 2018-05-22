using System;

namespace backEnd.Controllers.Resources
{
    public class EmployeePositionResource
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}