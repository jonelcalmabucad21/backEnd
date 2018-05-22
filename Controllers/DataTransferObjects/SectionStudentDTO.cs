using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class SectionStudentDTO
    {

        public int Id { get; set; } 
        public int StudentId { get; set; }  
        public int SectionAdviserId { get; set; }
        public int SchoolYear { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation
        public StudentDTO Student { get; set; }

       // public ICollection<InvolveStudent> InvolveStudents { get; set; } = new Collection<InvolveStudent>();        
    }
}