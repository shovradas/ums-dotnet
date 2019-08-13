using System;
using Ums.Infrastructure.Data.EF;
using Ums.Entities;
using Ums.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ums.Service.EF
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        private readonly UmsDbContext _context;

        public CourseService(UmsDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllByDepartment(int deptId)
        {
            return _context.Set<Course>().Where(x => x.DepartmentId == deptId);
        }
    }
}
