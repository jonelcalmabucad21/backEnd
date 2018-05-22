using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class EmployeeStationDTO
    {

        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public int StationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public StationDTO Station { get; set; }
    }
}