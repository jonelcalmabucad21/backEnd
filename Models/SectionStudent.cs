using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class SectionStudent
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }  
        public int SectionAdviserId { get; set; }
        public int SchoolYear { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public Student Student { get; set; }
        public SectionAdviser SectionAdviser { get; set; }

        public ICollection<InvolveStudent> InvolveStudents { get; set; } = new Collection<InvolveStudent>();
    }
}