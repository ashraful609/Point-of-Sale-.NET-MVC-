using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private ICategoryRepo categoryRepo;

        public HomeController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Install()
        {
            return View(categoryRepo.GetAll());
        }

       
    }
}