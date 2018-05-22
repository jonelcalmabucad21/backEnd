using System;

namespace backEnd.Controllers.Resources
{
    public class PrincipalResource
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public int SchoolYear { get; set; }
        public int StationId { get; set; }
        public int SchoolId { get; set; }
        public DateTime EntryDate { get; set; }

        // Person
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SuffixName { get; set; }

        // Employee
        public string EmployeeNumber { get; set; }

        //Station
        public string Station { get; set; }

        // Position
        public string Position { get; set; }

        // Deployed
        public string Deployed { get; set; }



    }
}