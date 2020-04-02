﻿using JobBoard.BusinessLogic.Interfaces;
using JobBoard.Domain.Entities.User;
using JobBoard.BusinessLogic;
using System;
using System.Web.Mvc;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ULoginData login)
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

                var userLogin = _session.ULoginData(data);

                /*
                if (userLogin.Status)
                {
                    // ADD COOKIE

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }

               */
            }

            return View();
        }
    }
}