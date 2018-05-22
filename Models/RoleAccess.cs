namespace backEnd.Models
{
    public class RoleAccess
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessId { get; set; }
        public Role Role { get; set; }
        public Access Access { get; set; }
    }
}