namespace MySchool.Core.Domain.Entities
{
    public class UserRole : Auditables
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string RoleId { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }
}
