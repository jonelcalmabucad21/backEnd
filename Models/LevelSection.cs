using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class LevelSection
    {
        public int Id { get; set; }
        public int SchoolYear { get; set; }
        public int LevelId { get; set; }
        public int SectionId { get; set; }
        public int StationId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation 
        public Level Level { get; set; }
        public Section Section { get; set; }
        public Station Station { get; set; }
        
        public SectionAdviser SectionAdviser { get; set; }
    }
}