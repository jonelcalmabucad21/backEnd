using System;

namespace backEnd.Models
{
    public class PrefectOfDiscipline
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LevelId { get; set; }
        public int SchoolYear { get; set; }
        public DateTime EntryDate { get; set; }

        // navigations
        public Employee Employee { get; set; }
        public Level Level { get; set; }
    }
}