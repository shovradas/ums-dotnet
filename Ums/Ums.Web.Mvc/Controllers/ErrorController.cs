using System.Web.Mvc;

namespace Ums.Web.Mvc.Controllers
{
    public class ErrorController : ControllerBase
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }

        // GET: Error
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}