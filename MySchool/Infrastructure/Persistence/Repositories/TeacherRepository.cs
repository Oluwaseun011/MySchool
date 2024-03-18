using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly StudContext _context;
        public TeacherRepository(StudContext context)
        {
            _context = context;
        }
        public Teacher Create(Teacher entity)
        {
            _context.Set<Teacher>().Add(entity);
            return entity;
        }

        public bool Exist(string staffNumber)
        {
            return _context.Teachers.Any(a => a.StaffNumber == staffNumber);
        }

        public Teacher Get(string staffNumber)
        {
            var teacherGotten = _context.Set<Teacher>().Include(a => a.Class)
                .ThenInclude(a => a.StudentClasses).FirstOrDefault(a => a.StaffNumber == staffNumber);
            return teacherGotten;
        }

        public Teacher Get(Expression<Func<Teacher, bool>> exp)
        {
            var teacherGotten = _context.Set<Teacher>().Include(a => a.Class)
                .ThenInclude(a => a.StudentClasses).FirstOrDefault(exp);
            return teacherGotten;
        }

        public ICollection<Teacher> GetAll()
        {
            return _context.Set<Teacher>().ToList();
        }

        public Teacher Update(Teacher entity)
        {
            var teacher = _context.Set<Teacher>().Update(entity);
            return entity;
        }
    }
}
