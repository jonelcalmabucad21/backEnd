using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation property
        public Employee Employee { get; set; }
        public Student Student { get; set; }
        public Guardian Guardian { get; set; } 

    }
}