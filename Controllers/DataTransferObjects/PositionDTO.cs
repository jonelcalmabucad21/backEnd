using System;

namespace backEnd.Controllers.DataTransferObjects
{
    public class PositionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
    }
}