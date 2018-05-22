namespace backEnd.Controllers.DataTransferObjects
{
    public class GuardianDTO
    {

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int StudentId { get; set; }
        public int RelationId { get; set; }
        public PersonDTO Person { get; set; }
        public RelationDTO Relation { get; set; }
    }
}