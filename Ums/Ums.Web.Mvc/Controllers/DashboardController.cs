using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ums.Entities;
using Ums.Framework;
using Ums.Infrastructure.Data.EF;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Models;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthentication]
    public class DashboardController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IRegistrationService _registrationService;

        public DashboardController(IUserService service, IDepartmentService departmentService, ICourseService courseService, IStudentService studentService, IRegistrationService registrationService)
        {
            _service = service;
            _departmentService = departmentService;
            _courseService = courseService;
            _studentService = studentService;
            _registrationService = registrationService;
        }

        public ActionResult Index()
        {
            User user = Session["User"] as User;
            if (user != null)
            {
                if (user.Type == UserType.Admin)
                    return RedirectToAction("Admin");
                else if (user.Type == UserType.Student)
                    return RedirectToAction("Student");
            }            
            return RedirectToAction("UnAuthorized", "Error");
        }

        [BasicAuthorization(UserType.Admin)]
        public ActionResult Admin()
        {
            ChartVM barChartVM = new ChartVM();            
            ICollection<Department> departments = _departmentService.GetAll().ToList();

            foreach (var department in departments)
            {
                int count = department.Courses.Sum(x => x.Sections.Sum(y => y.Students.Distinct().Count()));
                if (count != 0)
                {
                    barChartVM.Labels.Add(department.Name);
                    barChartVM.Data.Add(count);
                }
                
            }

            ChartVM pieChartVM = new ChartVM();
            pieChartVM.Labels.Add(UserType.Admin.ToString());
            pieChartVM.Labels.Add(UserType.Student.ToString());
            ICollection<User> users = _service.GetAll().ToList();
            pieChartVM.Data.Add(users.Count(x=>x.Type==UserType.Admin));
            pieChartVM.Data.Add(users.Count(x=>x.Type==UserType.Student));

            AdminDashboardVM model = new AdminDashboardVM()
            {
                DepartmentCount = _departmentService.GetAll().Count(),
                CourseCount = _courseService.GetAll().Count(),
                StudentCount = _studentService.GetAll().Count(),
                RegistrationCount = _registrationService.GetAll().Select(x=>x.StudentId).Distinct().Count(),
                BarChartVM = barChartVM,
                PieChartVM = pieChartVM
            };

            return View(model);
        }

        [BasicAuthorization(UserType.Student)]
        public ActionResult Student()
        {
            Student student = Session["User"] as Student;
            return View(_registrationService.GetByStudentId(student.Id));
        }
    }
}