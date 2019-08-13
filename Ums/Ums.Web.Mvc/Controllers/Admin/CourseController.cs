using System.Web.Mvc;
using Ums.Entities;
using Ums.Framework;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IDepartmentService _departmentService;        
        private readonly IUmsFacade _umsFacade;

        public CourseController(ICourseService service, IDepartmentService departmentService, IUmsFacade umsFacade)
        {
            _service = service;
            _departmentService = departmentService;
            _umsFacade = umsFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();            
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(Course model)
        {

            if (ModelState.IsValid && _service.Insert(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }
            
            ViewBag.Departments = _departmentService.GetAll();
            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(model); 
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Course model)
        {
            if (ModelState.IsValid && _service.Update(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.Departments = _departmentService.GetAll();
            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(model);
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            if (ModelState.IsValid && _umsFacade.DeleteCourse(id))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Index");
            }
            
            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(_service.GetById(id));
        }
    }
}
