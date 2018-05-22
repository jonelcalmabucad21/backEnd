using System;

namespace backEnd.Controllers.Resources
{
    public class PositionResource
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}