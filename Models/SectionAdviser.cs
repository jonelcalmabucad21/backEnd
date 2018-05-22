using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class SectionAdviser
    {
        public int Id { get; set; }
        public int LevelSectionId { get; set; }
        public int AdviserId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigations
        public LevelSection LevelSection { get; set; }
        public Adviser Adviser { get; set; }
        public ICollection<SectionStudent> SectionStudents { get; set; } = new Collection<SectionStudent>();
    }
}