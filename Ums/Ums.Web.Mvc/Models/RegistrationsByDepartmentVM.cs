using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ums.Web.Mvc.Models
{
    public class RegistrationsByDepartment
    {
        public String Department { get; set; }
        public int CourseCount { get; set; }
        public int SectionCount { get; set; }
        public int StudentCount { get; set; }
    }

    public class RegistrationsByDepartmentVM
    {
        public IEnumerable<RegistrationsByDepartment> RegistrationsByDepartment { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalCourses { get; set; }
        public int TotalSections { get; set; }
        public int TotalStudents { get; set; }
    }

}