using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Domain.Entities;
using MySchool.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace MySchool.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudContext _context;
        public StudentRepository(StudContext context)
        {
            _context = context;
        }
        public Student Create(Student entity)
        {
            _context.Set<Student>().Add(entity);
            return entity;
        }

        public bool Exist(string admissionNumber)
        {
            return _context.Students.Any(a => a.AdmissionNumber == admissionNumber);
        }

        public Student Get(string admisionNumber)
        {
            var student = _context.Set<Student>().Include(a => a.StudentClasses).
                ThenInclude(a => a.Class).FirstOrDefault(a => a.AdmissionNumber == admisionNumber);
            return student;
        }

        public ICollection<Student> GetAll()
        {
            return _context.Set<Student>().ToList();
        }

        public ICollection<Student> GetSelected(Expression<Func<Student, bool>> exp)
        {
            var selectedStudent = _context.Set<Student>().Where(exp).ToList();
            return selectedStudent;
        }

        public Student Update(Student entity)
        {
            var stud = _context.Set<Student>().Update(entity);
            return entity;
        }
    }
}
