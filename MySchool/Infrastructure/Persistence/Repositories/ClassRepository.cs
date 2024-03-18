using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudContext _context;
        public ClassRepository(StudContext context) 
        {  
            _context = context; 
        }
        public Class Create(Class entity)
        {
            _context.Set<Class>().Add(entity);
            return entity;

        }

        public bool Exist(string name)
        {
            return _context.Classes.Any(a => a.Name == name);
        }

        public Class Get(string name)
        {
            var clas = _context.Set<Class>().Include(a  => a.StudentClasses).ThenInclude(a => a.Student).Include(a => a.Teacher).ThenInclude(a => a.User).FirstOrDefault(a => a.Name == name);
            return clas;
        }

        public ICollection<Class> GetAll()
        {
            return _context.Set<Class>().ToList();
        }

        public Class Update(Class entity)
        {
            var clas = _context.Set<Class>().Update(entity);
            return entity;
        }
    }
}
