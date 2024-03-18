namespace MySchool.Core.Domain.Entities
{
    public class Student : Auditables
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string GuardianId { get; set; } = default!;
        public Guardian Guardian { get; set; } = default!;
        public string AdmissionNumber { get; set; } = default!;
        public ICollection<StudentClass> StudentClasses { get; set; } = new HashSet<StudentClass>();
    }
}
