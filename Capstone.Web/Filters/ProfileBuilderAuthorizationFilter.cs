using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capstone.Web.Filters
{
    public class ProfileBuilderAuthorizationFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Checking to see if the url contains a username
            if (filterContext.ActionParameters.ContainsKey("username"))
            {
                var impliedUsername = (string)filterContext.ActionParameters["username"];
                ProfileBuilderController controller = filterContext.Controller as ProfileBuilderController;

                if (controller != null)
                {
                    var actualUsername = controller.CurrentUser;

                    if (!controller.IsAuthenticated)
                    {
                        var routeValueDictionary = new RouteValueDictionary(new { controller = "User", action = "LogIn", nextPage = filterContext.HttpContext.Request.Url });
                        filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
                    }
                    else
                    {
                        if (impliedUsername.ToLower() != actualUsername.ToLower())
                        {
                            //stop lying the usernames dont match
                            filterContext.Result = new HttpStatusCodeResult(403);
                        }
                    }
                }
            }


            base.OnActionExecuting(filterContext);
        }
    }
}