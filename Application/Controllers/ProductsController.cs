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
    public class ProductsController : BaseController
    {
        private IProductRepo productRepo;
        private ICategoryRepo categoryRepo;

        public ProductsController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Session["user_role"].Equals("manager"))
            {
                Response.Redirect("/Home/Index");
            }
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(productRepo.GetAll());
        }

        // POST: Inventory/Index/productName
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            return View(productRepo.GetByName(searchTerm));
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            Product product = productRepo.Get(id);
            product.Category = categoryRepo.Get(product.Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var categories = categoryRepo.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.Created = DateTime.Now;
            product.Edited = DateTime.Now;
            product.Active = true;
            if (ModelState.IsValid)
            {
                productRepo.Insert(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = categoryRepo.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName");
            Product product = productRepo.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            product.Edited = DateTime.Now;
            if (ModelState.IsValid)
            {
                productRepo.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return Details(id);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productRepo.Get(id);
            productRepo.Delete(product);
            return RedirectToAction("Index");
        }


        public ActionResult ReportProduct() {
            List<Product> plist = productRepo.GetAll();      
            return View(plist.OrderByDescending(x=> x.SalePrice));
        }

    }
}
