using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StudContext _context;
        public UserRepository(StudContext context)
        {
            _context = context;
        }
        public User Create(User entity)
        {
            _context.Set<User>().Add(entity);
            return entity;
        }

        public bool Exist(string email)
        {
            return _context.Users.Any(a => a.Email == email);
        }

        public User Get(string email)
        {
            var user = _context.Set<User>().Include(a => a.UserRoles)
                .ThenInclude(a => a.Role).FirstOrDefault(a => a.Email == email);
            return user;
        }

        public User Get(Expression<Func<User, bool>> exp)
        {
            var user = _context.Set<User>().Include(a => a.UserRoles)
                .ThenInclude(a => a.Role).FirstOrDefault(exp);
            return user;
        }

        public ICollection<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }

        public User Update(User entity)
        {
            var user = _context.Set<User>().Update(entity);
            return entity;
        }
    }
}
