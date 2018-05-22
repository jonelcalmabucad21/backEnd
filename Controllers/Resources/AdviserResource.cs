using System;

namespace backEnd.Controllers.Resources
{
    public class AdviserResource
    {

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}