using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.Resources
{
    public class StudentSaveResource
    {
        public int Id { get; set; }
        public string LrnNumber { get; set; }
        public int PersonId { get; set; }
        public int GenderId { get; set; }
        public string Contact { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; } 
        public PersonResource Person { get; set; } 
        public GenderResource Gender { get; set; }

        public ICollection<StudentAddressResource> StudentAddress { get; set; } = new Collection<StudentAddressResource>();



    }

}