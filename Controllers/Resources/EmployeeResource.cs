using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.Resources
{
    public class EmployeeResource
    {
        public int Id { get; set; } 
        public int EmployeeNumber { get; set; }  
        public int PersonId { get; set; }   
        public DateTime EntryDate { get; set; }

        public PersonResource Person { get; set; }
        public PositionResource Position { get; set; } = new PositionResource();
        public StationResource Station { get; set; } = new StationResource();
        public ICollection<StationResource> EmployeeStations { get; set; } = new Collection<StationResource>();
        public ICollection<PositionResource> EmployeePositions { get; set; } = new Collection<PositionResource>();
        
    }
}