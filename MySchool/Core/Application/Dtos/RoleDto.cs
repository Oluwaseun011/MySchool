using MySchool.Core.Domain.Entities;

namespace MySchool.Core.Application.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<UserDto> Users { get; set; } = new HashSet<UserDto>();
    }

    public class RoleRequest
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }

    public class UpdateRoleRequest
    {
        public string? Description { get; set; }
    }
}
