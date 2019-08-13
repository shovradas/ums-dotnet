using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Ums.Entities;
using Ums.Framework;
using Ums.Infrastructure.Data.EF;
using Ums.Service.Interfaces;
using Ums.Web.Mvc.Filters;
using Ums.Web.Mvc.Helpers;

namespace Ums.Web.Mvc.Controllers
{
    [BasicAuthorization(UserType.Admin)]
    public class UserController :  ControllerBase
    {
        private readonly IUserService _service;
        private readonly CryptoHelper _cryptoHelper;
        private readonly IUmsFacade _umsFacade;

        public UserController(IUserService service, CryptoHelper cryptoHelper, IUmsFacade umsFacade)
        {
            _service = service;
            _cryptoHelper = cryptoHelper;
            _umsFacade = umsFacade;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetAll().Where(x=>x.Type!=UserType.Student));
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
        public ActionResult Create(User model)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                model.Password = _cryptoHelper.GetMd5Hash(md5Hash, "0");
            }
            ModelState["Password"].Errors.Clear();

            if (ModelState.IsValid && _service.Insert(model))
            {
                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error. Note: Username and Email must be unique");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(User model)
        {
            ModelState["Password"].Errors.Clear();

            if (ModelState.IsValid && _service.Update(model))
            {                
                User user = Session["User"] as User;
                if (user.Id == model.Id)
                    return RedirectToAction("Login", "Account");

                TempData["AlertMessage"] = AlertHelper.SuccessAlert("Success!", "Your last operation was successful");
                return RedirectToAction("Details", new { id = model.Id });
            }

            ViewBag.AlertMessage = AlertHelper.DangerAlert("Error!", "Your last operation issued an error. Note: Username and Email must be unique");
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id, UmsDbContext _ctx)
        {
            if (ModelState.IsValid && _umsFacade.DeleteUser(id))
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