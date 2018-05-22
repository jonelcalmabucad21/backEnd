namespace backEnd.Models
{
    public class UserAccess
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccessId { get; set; }
        public User User { get; set; }
        public Access Access { get; set; }
    }
}