using MySchool.Core.Domain.Entities;
using MySchool.Core.Domain.Enums;

namespace MySchool.Core.Application.Dtos
{
    public class StudentDto
    {
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string GuardianId { get; set; } = default!;
        public string GuardianName { get; set; } = default!;
        public string AdmissionNumber { get; set; } = default!;
        public ICollection<ClassDto> Classes { get; set; } = new HashSet<ClassDto>();
    }

    public class StudentRequest
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

    public class UpdateStudentRequest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
    }
}
