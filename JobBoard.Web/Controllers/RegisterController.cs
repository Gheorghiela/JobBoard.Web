using System.Web.Mvc;
using JobBoard.Web.Models;
using JobBoard.BusinessLogic.Interfaces;
using JobBoard.BusinessLogic;
using System.Web;
using JobBoard.Domain.Entities.User;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegister _register;
        private readonly ISession _session;
        // GET: Login
        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _register = bl.GetRegisterBL();
            var ss = new BusinessLogic.BusinessLogic();
            _session = ss.GetSessionBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister user)
        {
            URegisterData data = new URegisterData
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email
            };

            _register.UserRegister(data);

            ULoginData u = new ULoginData
            {
                Credential = user.Username,
                Password = user.Password
            };

            _session.UserLogin(u);

            HttpCookie cookie = _session.GenCookie(u.Credential);
            ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}