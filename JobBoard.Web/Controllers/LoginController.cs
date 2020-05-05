using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using JobBoard.BusinessLogic;
using System;
using System.Web.Mvc;
using AutoMapper;
using JobBoard.Web.Models;
using System.Web;

namespace JobBoard.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        // GET: Login
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            _session.UserLogout(user.Username);
            return RedirectToAction("Index", "Login");
        }
    }
}