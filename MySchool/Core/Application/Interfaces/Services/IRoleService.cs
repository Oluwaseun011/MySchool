using MySchool.Core.Application.Dtos;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface IRoleService
    {
        BaseResponse<RoleDto> Create(RoleRequest request);
        BaseResponse<RoleDto> Update(string id, UpdateRoleRequest request);
        BaseResponse<RoleDto> Get(string name);
        BaseResponse<ICollection<RoleDto>> GetAll();
    }
}
