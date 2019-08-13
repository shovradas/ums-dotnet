using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ums.Web.Mvc.Models
{
    public class RegistrationsByCourse
    {
        public String Course { get; set; }
        public int SectionCount { get; set; }
        public int StudentCount { get; set; }
    }

    public class RegistrationsByCourseVM
    {
        public IEnumerable<RegistrationsByCourse> RegistrationsByCourse { get; set; }
        public int TotalCourses { get; set; }
        public int TotalSections { get; set; }
        public int TotalStudents { get; set; }
    }

}