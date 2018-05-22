using System;

namespace backEnd.Controllers.Resources
{
    public class StationResource
    {

        public int Id { get; set; }
        public int StationNumber { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
    }
}