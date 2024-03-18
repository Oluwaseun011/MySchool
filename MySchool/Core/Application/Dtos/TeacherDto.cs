using MySchool.Core.Domain.Entities;
using MySchool.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Core.Application.Dtos
{
    public class TeacherDto
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string ClassId { get; set; } = default!;
        public string ClassName { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
    }

    public class TeacherRequest
    {
        [Required]
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public IFormFile ImageUrl { get; set; } = default!;
    }
}
