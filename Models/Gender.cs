using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace backEnd.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new Collection<Student>();
    }
}