using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace MVCLibraryAutomation2.Filter
{
    public class AuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
            string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();

            if (filterContext.HttpContext.Session["LoginUser"] == null && (controllerName != "login"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller","Login" },
                        {"action","Index" }
                    });
            }
        }
    }
}