using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ums.Infrastructure.Data.EF;

namespace Ums.Web.Mvc.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Account");
        }

        [NonAction]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [NonAction]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}