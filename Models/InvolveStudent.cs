using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class InvolveStudent
    {
        public int Id { get; set; }
        public int StudentCaseId { get; set; }
        public int SectionStudentId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public StudentCase StudentCase { get; set; }
        public SectionStudent SectionStudent { get; set; }
        public ICollection<StudentOffense> StudentOffenses { get; set; } = new Collection<StudentOffense>();
    }
}