using System.Web.Mvc;
using Ums.Entities;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthentication()]
    public class AjaxServiceController : Controller
    {
        IRegistrationService _registrationService;
        ISectionService _sectionService;

        public AjaxServiceController(IRegistrationService registrationService, ISectionService sectionService)
        {
            _registrationService = registrationService;
            _sectionService = sectionService;
        }

        [HttpPost]
        public ActionResult Register(Registration model)
        {
            Section section = _sectionService.GetById(model.SectionId);
            var existingReg = _registrationService.GetByStudentAndCourseId(model.StudentId, section.CourseId);
            
            if (existingReg != null)
            {
                existingReg.DateTime = System.DateTime.Now;
                existingReg.SectionId = model.SectionId;
                existingReg.CourseId = section.CourseId;

                if (ModelState.IsValid && _registrationService.Update(existingReg))
                    return Json(existingReg.Id);
            }
            else
            {
                model.DateTime = System.DateTime.Now;
                model.CourseId = section.CourseId;

                if (ModelState.IsValid && _registrationService.Insert(model))                
                    return Json(model.Id);                    
            }

            return Json(0);
        }

        [HttpPost]
        public ActionResult Deregister(Registration model)
        {
            var existingReg = _registrationService.GetByStudentAndSectionId(model.StudentId, model.SectionId);

            if (existingReg != null)
            {
                _registrationService.Delete(existingReg.Id);
                return Json(-1);
            }
            else
                return Json(0);
        }
    }
}