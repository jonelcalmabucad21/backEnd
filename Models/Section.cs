using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Section
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }

        //navigation
        public ICollection<LevelSection> LevelSections { get; set; } = new Collection<LevelSection>();
    }
}