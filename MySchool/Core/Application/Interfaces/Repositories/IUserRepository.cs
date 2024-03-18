using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User entity);
        User Update(User entity);
        User Get(string email);
        User Get(Expression<Func<User, bool>> exp);
        ICollection<User> GetAll();
        bool Exist(string email);
    }
}
