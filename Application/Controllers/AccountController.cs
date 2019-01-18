using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepo userRepo;

        public AccountController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            User matchedUser = userRepo.Match(username, password);
            if (matchedUser != null)
            {
                Session["user_id"] = matchedUser.Id;
                Session["user_role"] = matchedUser.UserRole;
                Session["username"] = matchedUser.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user_id"] = null;
            Session["user_role"] = null;
            Session["username"] = null;
            return RedirectToAction("Login");
        }

    }
}