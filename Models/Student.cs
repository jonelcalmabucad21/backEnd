using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LrnNumber { get; set; }
        public int PersonId { get; set; }
        public int GenderId { get; set; }
        public string Contact { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EntryDate { get; set; } 
        public Person Person { get; set; } 
        public Gender Gender { get; set; }
        // navigation

        public ICollection<SectionStudent> SectionStudents { get; set; } = new Collection<SectionStudent>();
        public ICollection<StudentAddress> StudentAddresses { get; set; } = new Collection<StudentAddress>();
        public ICollection<Guardian> Guardians { get; set; } = new Collection<Guardian>();

    }
}