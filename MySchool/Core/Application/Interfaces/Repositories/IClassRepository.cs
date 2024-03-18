using MySchool.Core.Domain.Entities;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IClassRepository
    {
        Class Create(Class entity);
        Class Update(Class entity);
        Class Get(string name);
        ICollection<Class> GetAll();
        bool Exist(string name);
    }
}
