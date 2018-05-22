using System;

namespace backEnd.Controllers.Resources
{
    public class EmployeeStationResource
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int StationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}