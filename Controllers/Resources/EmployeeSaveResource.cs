using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.Resources
{
    public class EmployeeSaveResource
    {
        public int Id { get; set; } 
        public string EmployeeNumber { get; set; }  
        public int PersonId { get; set; }   
        public DateTime EntryDate { get; set; }

        public PersonResource Person { get; set; }

        public ICollection<EmployeeStationResource> EmployeeStations { get; set; } = new Collection<EmployeeStationResource>();
        public ICollection<EmployeePositionResource> EmployeePositions { get; set; } = new Collection<EmployeePositionResource>();
 
    }
}