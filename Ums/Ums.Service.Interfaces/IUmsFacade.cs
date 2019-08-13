using System;
using System.Collections.Generic;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface IUmsFacade
    {
        //Section
        //Dependancy: Registration
        bool DeleteSection(int id);

        //Course
        //Dependancy: Section,Registration
        bool DeleteCourse(int id);

        //Student
        //Dependancy: Registration, User (Handled by EF)
        bool DeleteStudent(int id);

        //User
        //Dependancy: Notification, optional: [Student, Registration]
        bool DeleteUser(int id);

        //Department
        //Depedancy: Student(User, Notification, Registration), Course (Section, Registration)
        bool DeleteDepartment(int id); 
    }
}
