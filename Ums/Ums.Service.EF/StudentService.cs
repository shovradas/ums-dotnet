using System;
using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Ums.Service.EF
{
    public class StudentService : ServiceBase<Student>, IStudentService
    {
        private readonly UmsDbContext _context;

        public StudentService(UmsDbContext context) : base(context)
        {
            _context = context;
        }

        public Student GetByFormattedId(String formattedId)
        {
            return _context.Set<Student>().SingleOrDefault(x => x.FormattedId == formattedId);
        }
        public IEnumerable<Student> GetAllByDepartment(int departmentId)
        {
            return _context.Set<Student>().Where(x=>x.DepartmentId == departmentId).ToList();
        }

        public override bool Update(Student student)
        {
            try
            {
                student.Password = "*****";
                _context.Entry(student).State = EntityState.Modified;
                _context.Entry(student).Property(x => x.Password).IsModified = false;
                _context.Entry(student).Property(x => x.Cgpa).IsModified = false;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
