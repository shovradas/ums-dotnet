using System;
using System.Collections.Generic;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface IStudentService : IService<Student>
    {
        Student GetByFormattedId(String formattedId);
        IEnumerable<Student> GetAllByDepartment(int departmentId);
    }
}
