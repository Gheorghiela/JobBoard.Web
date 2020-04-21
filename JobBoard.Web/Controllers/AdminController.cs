using JobBoard.Web.Controllers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using JobBoard.Web.Models;

namespace JobBoard.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AdminMod]
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                var u = AutoMapper.Mapper<UserLogin>(user);

                return View(u);
            }

            return View();
        }

        private void SessionStatus()
        {
            throw new NotImplementedException();
        }
    }
}