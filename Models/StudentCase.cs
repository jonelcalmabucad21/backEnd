using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class StudentCase
    {
        public int Id { get; set; }
        public string Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public ICollection<InvolveStudent> InvolveStudents { get; set; } = new Collection<InvolveStudent>();

    }
}