using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Entity;
using Interfaces;

namespace Application.Controllers
{
    public class UsersController : BaseController
    {
        private IUserRepo userRepo;

        public UsersController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Session["user_role"].Equals("admin"))
            {
                Response.Redirect("/Home/Index");
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(userRepo.GetAll());
        }


        [HttpPost]
        public ActionResult Index(string searchTerm)
        {

            return View(userRepo.GetByName(searchTerm));
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            User user = userRepo.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Registered = DateTime.Now;
            user.UserStatus = 1;
            if (ModelState.IsValid)
            {
                userRepo.Insert(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userRepo.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                User u = userRepo.Get(user.Id);
                user.Password = u.Password;
                user.ConfirmPassword = u.Password;
                userRepo.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            User user = userRepo.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userRepo.Get(id);
            userRepo.Delete(user);
            return RedirectToAction("Index");
        }

    }
}
