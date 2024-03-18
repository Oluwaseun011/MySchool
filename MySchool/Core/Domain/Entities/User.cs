using MySchool.Core.Domain.Enums;
using System.Reflection;

namespace MySchool.Core.Domain.Entities
{
    public class User : Auditables
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? ImageUrl { get; set; } 
        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; } 
        public Guardian? Guardian { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
