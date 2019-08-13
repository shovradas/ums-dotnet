using System.Web.Mvc;
using Ums.Entities;
using Ums.Service.Interfaces;
using Ums.Framework;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;
using System;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service;
        private readonly ICourseService _courseService;
        private readonly IUmsFacade _umsFacade;

        public SectionController(ISectionService service, ICourseService courseService, IUmsFacade umsFacade)
        {
            _service = service;
            _courseService = courseService;
            _umsFacade = umsFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_courseService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = _courseService.GetAll();

            if (Request["courseId"] != null)
            {
                Section model = new Section() { CourseId = Convert.ToInt32(Request["courseId"]) };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Section model)
        {
            if (ModelState.IsValid && _service.Insert(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.Courses = _courseService.GetAll();
            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Courses = _courseService.GetAll();
            return View(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Section model)
        {
            if (ModelState.IsValid && _service.Update(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.Courses = _courseService.GetAll();
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
            if (ModelState.IsValid && _umsFacade.DeleteSection(id))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Index");
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error");
            return View(_service.GetById(id));
        }
    }
}
