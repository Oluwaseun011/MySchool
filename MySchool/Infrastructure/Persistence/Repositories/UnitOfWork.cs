using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Infrastructure.Persistence.Context;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudContext _context;
        public UnitOfWork(StudContext context)
        {
            _context = context;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
