using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.DataTransferObjects
{
    public class StudentDTO
    {

        public int Id { get; set; }
        public string LrnNumber { get; set; }
        public int PersonId { get; set; }
        public int GenderId { get; set; }
        public string Contact { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; } 
        public PersonDTO Person { get; set; } 
        public GenderDTO Gender { get; set; }
        public GuardianDTO Guardian { get; set; }

        public ICollection<StudentAddressDTO> StudentAddresses { get; set; } = new Collection<StudentAddressDTO>();

    }
}