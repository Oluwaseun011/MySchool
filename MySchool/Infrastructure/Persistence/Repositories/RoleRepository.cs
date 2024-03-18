using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StudContext _context;
        public RoleRepository(StudContext context)
        {
            _context = context;
        }
        public Role Create(Role entity)
        {
            _context.Set<Role>().Add(entity);
            return entity;
        }

        public bool Exist(string name)
        {
            return _context.Roles.Any(a => a.Name == name);
        }

        public Role Get(string name)
        {
            var role = _context.Set<Role>()
                .Include(a => a.UserRoles)
                .ThenInclude(a => a.User)
                .FirstOrDefault(a => a.Name == name);
            return role;
        }

        public Role Get(Expression<Func<Role, bool>> exp)
        {
            var role = _context.Set<Role>()
                .Include(a => a.UserRoles)
                .ThenInclude(a => a.User)
                .FirstOrDefault(exp);
            return role;
        }

        public ICollection<Role> GetAll()
        {
            return _context.Set<Role>()
                .Include(a => a.UserRoles)
                .ThenInclude(a => a.User)
                .ToList();
        }

        public Role Update(Role entity)
        {
            var role = _context.Set<Role>().Update(entity);
            return entity;
        }
    }
}
