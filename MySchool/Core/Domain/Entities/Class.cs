namespace MySchool.Core.Domain.Entities
{
    public class Class : Auditables
    {
        public string Name { get; set; } = default!;
        public Teacher Teacher { get; set; }
        public ICollection<StudentClass> StudentClasses { get; set; } = new HashSet<StudentClass>();
    }
}
