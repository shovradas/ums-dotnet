using System.Web.Mvc;
using System.Linq;
using Ums.Entities;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Helpers;
using Ums.Web.Mvc.Filters;
using Ums.Framework;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly ISectionService _sectionService;

        public RegistrationController(IRegistrationService service, IDepartmentService departmentService, IStudentService studentService, ISectionService sectionService)
        {
            _service = service;
            _departmentService = departmentService;
            _studentService = studentService;
            _sectionService = sectionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_departmentService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id) //Section ID
        {
            return View(_sectionService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create(int id) //Section ID
        {
            Section section = _sectionService.GetById(id);

            Registration model = new Registration()
            {
                Section = section,
                CourseId = section.CourseId,
                SectionId = id
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Registration model)
        {
            Student student = _studentService.GetByFormattedId(Request["formattedId"]);
            Section section = _sectionService.GetById(model.SectionId);

            if (student != null && section != null)
            {
                model.DateTime = System.DateTime.Now;
                model.StudentId = student.Id;
                if (ModelState.IsValid && student.DepartmentId==section.Course.DepartmentId && _service.Insert(model))
                {
                    TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                    return RedirectToAction("Details", new { id = model.SectionId });
                }
            }            

            model.Section = section;
            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "The Student is already Registered in this section or does not belong to this course");
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)  //Registration ID
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(Registration model)
        {
            model = _service.GetById(model.Id);
            if (ModelState.IsValid && _service.Delete(model.Id))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.SectionId });
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(model);
        }
    }
}
