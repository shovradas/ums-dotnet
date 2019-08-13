using System.Web.Mvc;
using Ums.Service.Interfaces;
using Ums.Framework;
using Ums.Web.Mvc.Filters;
using Ums.Entities;
using System.Linq;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Student)]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IRegistrationService _registrationService;
        public StudentRegistrationController(ICourseService courseService, IRegistrationService registrationService)
        {
            _courseService = courseService;
            _registrationService = registrationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Student student = Session["User"] as Student;
            ViewBag.StudentSections = _registrationService.GetByStudentId(student.Id);
            return View(_courseService.GetAllByDepartment(student.DepartmentId).ToList());
        }

        [HttpGet]
        public ActionResult RegisteredCourses()
        {
            Student student = Session["User"] as Student;
            return View(_registrationService.GetByStudentId(student.Id));
        }

        [HttpGet]
        public ActionResult SectionOffers()
        {
            Student student = Session["User"] as Student;
            return View(_courseService.GetAllByDepartment(student.DepartmentId).ToList());
        }
    }
}