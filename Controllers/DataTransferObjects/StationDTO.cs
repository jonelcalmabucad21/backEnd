using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class StationDTO
    {
       public int Id { get; set; }

        public int StationNumber { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
    }
}