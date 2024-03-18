namespace MySchool.Core.Domain.Entities
{
    public class Teacher : Auditables
    {
        public string UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public string? ClassId { get; set; } 
        public Class Class { get; set; } 
        public string StaffNumber { get; set; } = default!;
    }
}
