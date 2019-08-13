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
    public class BasicAuthorization : ActionFilterAttribute
    {
        UserType _userType;

        public BasicAuthorization(UserType userType)
        {
            _userType = userType;
        }

        override public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
            else
            {
                User user = filterContext.HttpContext.Session["User"] as User;

                if (user.Type != _userType)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Dashboard", action = "Index" }));
                    filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                }
            }
        }
    }
}