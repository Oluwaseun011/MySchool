namespace MySchool.Core.Domain.Entities
{
    public class Role : Auditables
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
