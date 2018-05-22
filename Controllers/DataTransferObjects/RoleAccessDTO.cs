namespace backEnd.Controllers.DataTransferObjects
{
    public class RoleAccessDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessId { get; set; }
        public RoleDTO Role { get; set; }
        public AccessDTO Access { get; set; }     
    }
}