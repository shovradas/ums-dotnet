using System.Web.Mvc;
using Ums.Entities;
using Ums.Service.Interfaces;
using Ums.Framework;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;
using System;
using System.Collections;
using System.Security.Cryptography;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IDepartmentService _departmentService;
        private readonly IUmsFacade _umsFacade;
        private readonly CryptoHelper _cryptoHelper;

        public StudentController(IStudentService service, IDepartmentService departmentService, IUmsFacade umsFacade, CryptoHelper cryptoHelper)
        {
            _service = service;
            _departmentService = departmentService;
            _umsFacade = umsFacade;
            _cryptoHelper = cryptoHelper;
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
        public ActionResult Create(Student model)
        {
            model.Type = UserType.Student;
            using (MD5 md5Hash = MD5.Create())
            {
                model.Password = _cryptoHelper.GetMd5Hash(md5Hash, "0");
            }
            ModelState["Password"].Errors.Clear();          
            int count = ((ICollection)_service.GetAll()).Count;
            model.FormattedId = String.Format($"{DateTime.Now.Year.ToString().Substring(2, 2)}-{model.DepartmentId}-{count}");
            ModelState["FormattedId"].Errors.Clear();

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
        [ActionName("Edit")]
        public ActionResult EditPost(Student model)
        {
            ModelState["Password"].Errors.Clear();

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
            if (ModelState.IsValid && _umsFacade.DeleteStudent(id))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
                return View(_service.GetById(id));
            }
        }
    }
}
