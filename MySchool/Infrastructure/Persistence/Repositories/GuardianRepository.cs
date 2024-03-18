using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class GuardianRepository : IGuardianRepository
    {
        private readonly StudContext _context;
        public GuardianRepository(StudContext context)
        {
            _context = context;
        }
        public Guardian Create(Guardian entity)
        {
            _context.Set<Guardian>().Add(entity);
            return entity;
        }

        public Guardian Get(Expression<Func<Guardian, bool>> exp)
        {
            var guardian = _context.Set<Guardian>()
                .Include(a => a.Students)
                .Include(a => a.User)
                .FirstOrDefault(exp);
            return guardian;
        }

        public ICollection<Guardian> GetAll()
        {
            return _context.Set<Guardian>()
                .Include(a => a.Students)
                .Include(a => a.User)
                .ToList();
        }

        public Guardian Update(Guardian entity)
        {
            var guardian = _context.Set<Guardian>().Update(entity);
            return entity;
        }
    }
}
