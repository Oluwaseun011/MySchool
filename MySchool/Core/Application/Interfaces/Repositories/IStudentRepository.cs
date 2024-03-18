using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student Create(Student entity);
        Student Update(Student entity);
        Student Get(string admisionNumber);
        ICollection<Student> GetSelected(Expression<Func<Student, bool>> exp);
        ICollection<Student> GetAll();
        bool Exist(string admissionNumber);
    }
}
