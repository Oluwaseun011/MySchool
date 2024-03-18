namespace MySchool.Core.Domain.Entities
{
    public class Guardian : Auditables
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
