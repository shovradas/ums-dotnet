using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ums.Entities;
using Ums.Framework;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Models;

namespace Ums.Web.Mvc.Controllers.Admin
{
    [BasicAuthorization(UserType.Admin)]
    public class ReportController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _departmentService;

        public ReportController(IDepartmentService departmentService, ICourseService courseService)
        {
            _departmentService = departmentService;
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult RegistrationsOverview()
        {
            ChartVM barChartVM = new ChartVM();
            IEnumerable<Department> departments = _departmentService.GetAll();

            foreach (var department in departments)
            {
                int count = department.Courses.Sum(x => x.Sections.Sum(y => y.Students.Distinct().Count()));
                //if (count != 0)
                barChartVM.Labels.Add(department.Name);
                barChartVM.Data.Add(count);
            }

            return View(barChartVM);
        }

        [HttpGet]
        public ActionResult RegistrationsByDepartment()
        {
            IEnumerable<Department> departments = _departmentService.GetAll();
            var result = from dept in departments
                         select new RegistrationsByDepartment()
                         {
                             Department = dept.Name,
                             CourseCount = dept.Courses.Count(),
                             SectionCount = dept.Courses.Sum(x => x.Sections.Count()),
                             StudentCount = dept.Courses.Sum(x => x.Sections.Sum(y=>y.Students.Count()))
                         };

            var model = new RegistrationsByDepartmentVM()
            {
                RegistrationsByDepartment = result,
                TotalDepartments = result.Count(),
                TotalCourses = result.Sum(x => x.CourseCount),
                TotalSections = result.Sum(x => x.SectionCount),
                TotalStudents = result.Sum(x => x.StudentCount)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult RegistrationsByCourse()
        {
            IEnumerable<Course> courses = _courseService.GetAll();
            var result = from course in courses
                         select new RegistrationsByCourse()
                         {
                             Course = String.Format("{0}: {1}", course.Code, course.Name),
                             SectionCount = course.Sections.Count(),
                             StudentCount = course.Sections.Sum(x => x.Students.Count())
                         };

            var model = new RegistrationsByCourseVM()
            {
                RegistrationsByCourse = result,
                TotalCourses = result.Count(),
                TotalSections = result.Sum(x => x.SectionCount),
                TotalStudents = result.Sum(x => x.StudentCount)
            };

            return View(model);
        }
    }
}