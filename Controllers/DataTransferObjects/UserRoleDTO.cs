namespace backEnd.Controllers.DataTransferObjects
{
    public class UserRoleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}