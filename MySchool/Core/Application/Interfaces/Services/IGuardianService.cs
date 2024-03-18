using MySchool.Core.Application.Dtos;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface IGuardianService
    {
        BaseResponse<GuardianDto> Create(GuardianRequest request);
        BaseResponse<GuardianDto> Update(string id, UpdateGuardianRequest request);
        BaseResponse<GuardianDto> Get(string id);
        BaseResponse<ICollection<GuardianDto>> GetAll();
    }
}
