namespace backEnd.Controllers.DataTransferObjects
{
    public class UserAccessDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccessId { get; set; }
        public AccessDTO Access { get; set; }
    }
}