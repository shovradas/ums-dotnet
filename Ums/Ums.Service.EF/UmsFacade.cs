using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ums.Entities;
using Ums.Infrastructure.Data.EF;
using Ums.Service.Interfaces;

namespace Ums.Service.EF
{
    public class UmsFacade: IUmsFacade
    {
        private readonly UmsDbContext _context;

        public UmsFacade(UmsDbContext context)
        {
            _context = context;
        }

        //Dependancy: Registration
        public bool DeleteSection(int id)
        {
            try
            {
                Section section = _context.Set<Section>().Find(id);

                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.SectionId == section.Id);                
                foreach (Registration registration in registrations)
                    //Registration
                    _context.Entry(registration).State = EntityState.Deleted;

                //Section
                _context.Entry(section).State = EntityState.Deleted;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Dependancy: Section, Registration
        public bool DeleteCourse(int id)
        {
            try
            {
                Course course = _context.Set<Course>().Find(id);

                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.CourseId == course.Id);
                foreach (Registration registration in registrations)
                    //Registration
                    _context.Entry(registration).State = EntityState.Deleted;

                IEnumerable<Section> sections = _context.Set<Section>().Where(x => x.CourseId == course.Id);
                foreach (Section section in sections)
                    //Section
                    _context.Entry(section).State = EntityState.Deleted;

                //Course
                _context.Entry(course).State = EntityState.Deleted;

                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //Dependancy: Registration, User(Handled by EF)
        public bool DeleteStudent(int id)
        {
            try
            {
                Student student = _context.Set<Student>().Find(id);

                IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.StudentId == student.Id);
                foreach (Registration registration in registrations)
                    //Registration
                    _context.Entry(registration).State = EntityState.Deleted;

                //Student
                _context.Entry(student).State = EntityState.Deleted;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Dependancy: optional: [Student (Handled by EF), Registration(If user is a student)]
        public bool DeleteUser(int id)
        {
            try
            {
                User user = _context.Set<User>().Find(id);

                if (user.Type == Framework.UserType.Student)
                {
                    IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.StudentId == user.Id);
                    foreach (Registration registration in registrations)
                        //Registration
                        _context.Entry(registration).State = EntityState.Deleted;
                }
                //User
                _context.Entry(user).State = EntityState.Deleted;

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }        

        //Depedancy Student(User (Handled by EF), Registration), Course (Section, Registration)
        public bool DeleteDepartment(int id)
        {
            try
            {
                Department department = _context.Set<Department>().Find(id);

                //Course Branch
                IEnumerable<Course> courses = _context.Set<Course>().Where(x => x.DepartmentId == department.Id).ToList();
                foreach (Course course in courses)
                {
                    IEnumerable<Registration> registrations = _context.Set<Registration>().Where(x => x.CourseId == course.Id).ToList();
                    foreach (Registration registration in registrations)
                        //Registration
                        _context.Entry(registration).State = EntityState.Deleted;

                    IEnumerable<Section> sections = _context.Set<Section>().Where(x => x.CourseId == course.Id).ToList();
                    foreach (Section section in sections)
                        //Section
                        _context.Entry(section).State = EntityState.Deleted;

                    //Course
                    _context.Entry(course).State = EntityState.Deleted;
                }

                //Student Branch
                IEnumerable<Student> students = _context.Set<Student>().Where(x => x.DepartmentId == department.Id).ToList();
                foreach (Student student in students)
                    //Student
                    _context.Entry(student).State = EntityState.Deleted;

                //Department
                _context.Entry(department).State = EntityState.Deleted;

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
