using System;

namespace backEnd.Models
{
    public class StudentOffense
    {
        public int Id { get; set; } 
        public int InvolveStudentId { get; set; }
        public int OffenseId { get; set; }
        public String Remarks { get; set; }
        public DateTime Date { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public InvolveStudent InvolveStudent { get; set; }
        public Offense Offense { get; set; }
        
    }
}