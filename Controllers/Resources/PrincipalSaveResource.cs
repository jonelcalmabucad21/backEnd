using System;

namespace backEnd.Controllers.Resources
{
    public class PrincipalSaveResource
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public int SchoolYear { get; set; }
        public int StationId { get; set; }
        public DateTime EntryDate { get; set; }       

        public EmployeeResource Employee { get; set; }
        public StationResource Station { get; set; }
    }
}