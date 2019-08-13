using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ums.Entities;
using Ums.Framework;

namespace Ums.Web.Mvc.Filters
{
    public class BasicAuthentication: ActionFilterAttribute
    {
        override public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
        }
    }
}