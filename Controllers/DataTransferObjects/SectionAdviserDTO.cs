using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Controllers.DataTransferObjects
{
    public class SectionAdviserDTO
    {
 
        public int Id { get; set; }
        public int LevelSectionId { get; set; }
        public int AdviserId { get; set; }
        public DateTime EntryDate { get; set; }

        public AdviserDTO Adviser { get; set; }
        public ICollection<SectionStudentDTO> SectionStudents { get; set; } = new Collection<SectionStudentDTO>();
    }
}