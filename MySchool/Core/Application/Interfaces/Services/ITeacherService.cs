using MySchool.Core.Application.Dtos;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface ITeacherService
    {
        BaseResponse<TeacherDto> Create(GuardianRequest request);
        BaseResponse<TeacherDto> Update(string id, UpdateRoleRequest request);
        BaseResponse<TeacherDto> Get(string name);
        BaseResponse<ICollection<TeacherDto>> GetAll();
    }
}
