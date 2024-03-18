using MySchool.Core.Domain.Entities;
using MySchool.Core.Domain.Enums;

namespace MySchool.Core.Application.Dtos
{
    public class GuardianDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public ICollection<StudentDto> Students { get; set; } = new HashSet<StudentDto>();
    }

    public class GuardianRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
    }

    public class UpdateGuardianRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
    }
}
