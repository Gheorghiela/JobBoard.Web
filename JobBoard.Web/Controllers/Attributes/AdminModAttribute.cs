using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobBoard.Web.Controllers.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;
        public AdminModAttribute()
        {
            var businessLogic = new BusinessLogic.BussinesLogic();
            _sessionBusinessLogic = businessLogic.GetSessionBL();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["LOGIN-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.Administrator)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new
                    {
                        controller = "Error",
                        action = "Error404"
                    }));

                }
            }
        }
    }
}