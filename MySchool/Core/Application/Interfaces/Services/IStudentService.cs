using MySchool.Core.Application.Dtos;
using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Services
{
    public interface IStudentService
    {
        BaseResponse<StudentDto> Create(StudentRequest request);
        BaseResponse<StudentDto> Update(string id, UpdateStudentRequest entity);
        BaseResponse<StudentDto> Get(string admisionNumber);
        BaseResponse<ICollection<StudentDto>> GetSelected(Expression<Func<Student, bool>> exp);
        BaseResponse<ICollection<StudentDto>> GetAll();
        bool Exist(string admissionNumber);
    }
}
