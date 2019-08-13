using System;
using System.Collections.Generic;
using System.Linq;
using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;
using System.Data.Entity;

namespace Ums.Service.EF
{
    public class RegistrationService : ServiceBase<Registration>, IRegistrationService
    {
        private readonly UmsDbContext _context;

        public RegistrationService(UmsDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual bool Delete(int id)
        {
            try
            {
                Registration registration = _context.Set<Registration>().Find(id);
                _context.Entry(registration).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteByCourseId(int courseId)
        {
            try
            {
                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.CourseId == courseId);
                foreach (Registration registration in registrations)
                {
                    _context.Entry(registration).State = EntityState.Deleted;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteBySectionId(int sectionId)
        {
            try
            {
                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.SectionId == sectionId);
                foreach (Registration registration in registrations)
                {
                    _context.Entry(registration).State = EntityState.Deleted;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteByStudentId(int studentId)
        {
            try
            {
                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.StudentId == studentId);
                foreach (Registration registration in registrations)
                {
                    _context.Entry(registration).State = EntityState.Deleted;
                }                
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual IEnumerable<Registration> GetByCourseId(int courseId)
        {
            return _context.Registrations.Where(x => x.StudentId == courseId).ToList();
        }

        public virtual IEnumerable<Registration> GetBySectionId(int sectionId)
        {
            return _context.Registrations.Where(x => x.SectionId == sectionId).ToList();
        }

        public virtual IEnumerable<Registration> GetByStudentId(int studentId)
        {
            return _context.Registrations.Where(x => x.StudentId == studentId).ToList();
        }

        public virtual Registration GetByStudentAndSectionId(int studentId, int sectionId)
        {
            return _context.Registrations.SingleOrDefault(x => x.StudentId == studentId && x.SectionId == sectionId);
        }

        public virtual Registration GetByStudentAndCourseId(int studentId, int courseId)
        {
            return _context.Registrations.SingleOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
        }
    }
}
