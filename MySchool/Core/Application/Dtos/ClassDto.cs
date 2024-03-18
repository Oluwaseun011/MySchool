using MySchool.Core.Domain.Entities;

namespace MySchool.Core.Application.Dtos
{
    public class ClassDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string TeacherFullName { get; set; } = default!;
        public ICollection<StudentDto> Students { get; set; } = new HashSet<StudentDto>();
    }

    public class ClassRequest
    {
        public string Name { get; set; } = default!;
    }
    
    public class UpdateClassRequest
    {
        public string Name { get; set; } = default!;
    }
}
