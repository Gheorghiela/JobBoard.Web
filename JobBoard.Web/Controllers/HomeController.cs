using JobBoard.Web.Extension;
using JobBoard.Web.Models;
using System;
using System.Web.Mvc;

namespace JobBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                UserLogin u = new UserLogin
                {
                    Credential = user.Username,
                };
                return View(u);
            }
            return View();
        }

        private void SessionStatus()
        {
            throw new NotImplementedException();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult BlogSingle()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult JobListings()
        {
            return View();
        }

        public ActionResult JobSingle()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Protfolio()
        {
            return View();
        }

        public ActionResult PortfolioSingle()
        {
            return View();
        }

        public ActionResult PostJob()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult ServiceSingle()
        {
            return View();
        }

        public ActionResult Testimonials()
        {
            return View();
        }
    }
}