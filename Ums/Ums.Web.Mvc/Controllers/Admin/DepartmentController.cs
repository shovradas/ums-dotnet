using System.Web.Mvc;
using Ums.Entities;
using Ums.Service.Interfaces;
using Ums.Framework;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IUmsFacade _umsFacade;
        public DepartmentController(IDepartmentService service, IUmsFacade umsFacade)
        {
            _service = service;
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
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(Department model)
        {
            if (ModelState.IsValid && _service.Insert(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Department model)
        {
            if (ModelState.IsValid && _service.Update(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

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
            if (ModelState.IsValid && _umsFacade.DeleteDepartment(id))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Index");
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(_service.GetById(id));
        }
    }
}
