using System;

namespace backEnd.Controllers.Resources
{
    public class PersonResource
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }
        public DateTime EntryDate { get; set; }
    }
}