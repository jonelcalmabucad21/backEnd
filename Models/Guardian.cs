namespace backEnd.Models
{
    public class Guardian
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int StudentId { get; set; }
        public int RelationId { get; set; }
        public string Contact { get; set; }
        public Person Person { get; set; }
        public Student Student { get; set; }
        public Relation Relation { get; set; }
    }
}