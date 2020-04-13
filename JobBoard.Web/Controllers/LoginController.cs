using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using JobBoard.BusinessLogic;
using System;
using System.Web.Mvc;
using JobBoard.BusinessLogic.DBModel;
using AutoMapper;

namespace JobBoard.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
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
                Mapper.Initialize(cfg => cfg.CreateMap<UserLogin,
                ULoginData>());
                var data = Mapper.Map<ULoginData>(login);
                data.LoginIp = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;
                var userLogin = _session.UserLogin(data);
            }
            return View();
        }
    }
}