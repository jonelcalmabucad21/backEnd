using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class LevelSection01DTO
    {

        public int Id { get; set; }
        public int SchoolYear { get; set; }
        public int LevelId { get; set; }
        public int SectionId { get; set; }
        public int StationId { get; set; }
        public DateTime EntryDate { get; set; }

        // navigation 
        public LevelDTO Level { get; set; }
        public SectionDTO Section { get; set; }
        public StationDTO Station { get; set; }

    }
}