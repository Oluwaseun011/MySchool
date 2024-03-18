using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Role Create(Role entity);
        Role Update(Role entity);
        Role Get(string name);
        ICollection<Role> GetAll();
        Role Get(Expression<Func<Role, bool>> exp);
        bool Exist(string name);
    }
}
