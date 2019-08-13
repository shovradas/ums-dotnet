using System.Collections.Generic;
using Ums.Entities;

namespace Ums.Service.Interfaces
{
    public interface ICourseService : IService<Course>
    {
        IEnumerable<Course> GetAllByDepartment(int deptId);
    }
}