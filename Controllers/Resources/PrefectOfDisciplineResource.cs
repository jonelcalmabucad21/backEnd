using System;

namespace backEnd.Controllers.Resources
{
    public class PrefectOfDisciplineResource
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LevelId { get; set; }
        public int SchoolYear { get; set; }
        public DateTime EntryDate { get; set; }
    }
}