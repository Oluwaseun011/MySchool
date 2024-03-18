using MySchool.Core.Application.Dtos;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        BaseResponse<UserDto> Login(LoginRequest request);
        BaseResponse<UserDto> Get(string id);
        BaseResponse<ICollection<UserDto>> GetUsers();
    }
}
