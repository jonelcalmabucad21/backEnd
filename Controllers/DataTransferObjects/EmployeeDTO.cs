using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace backEnd.Controllers.DataTransferObjects
{
    public class EmployeeDTO
    {

        public int Id { get; set; } 
        public string EmployeeNumber { get; set; }  
        public int PersonId { get; set; }   
        public DateTime EntryDate { get; set; }

        public PersonDTO Person { get; set; }

        public ICollection<EmployeeStationDTO> EmployeeStations { get; set; } = new Collection<EmployeeStationDTO>();
        public ICollection<EmployeePositionDTO> EmployeePositions { get; set; } = new Collection<EmployeePositionDTO>();

       public StationDTO Station { get; set; }
       public PositionDTO Position { get; set; }
    }
}