using MySchool.Core.Application.Dtos;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface IClassService
    {
        BaseResponse<ClassDto> Create(ClassRequest request);
        BaseResponse<ClassDto> Update(string name, UpdateClassRequest request);
        BaseResponse<ClassDto> Get(string name);
        BaseResponse<ICollection<ClassDto>> GetAll();
    }
}
