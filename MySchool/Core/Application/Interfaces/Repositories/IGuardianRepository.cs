using MySchool.Core.Domain.Entities;
using System.Linq.Expressions;

namespace MySchool.Core.Application.Interfaces.Repositories
{
    public interface IGuardianRepository
    {
        Guardian Create(Guardian entity);
        Guardian Update(Guardian entity);
        Guardian Get(Expression<Func<Guardian, bool>> exp);
        ICollection<Guardian> GetAll();
    }
}
