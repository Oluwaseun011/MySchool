namespace MySchool.Core.Domain.Entities
{
    public class StudentClass : Auditables
    {
        public string StudentId { get; set; } = default!;
        public Student Student { get; set; } = default!;
        public string ClassId { get; set; } = default!;
        public Class Class { get; set; } = default!;
    }
}
