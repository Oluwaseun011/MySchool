using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Teacher Create(Teacher entity);
        Teacher Update(Teacher entity);
        Teacher Get(string staffNumber);
        Teacher Get(Expression<Func<Teacher, bool>> exp);
        ICollection<Teacher> GetAll();
        bool Exist(string staffNumber);
    }
}
