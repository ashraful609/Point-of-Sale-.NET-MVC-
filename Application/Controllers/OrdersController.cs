using Data;
using Entity;
using Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class OrdersController : BaseController
    {
        private IProductRepo productRepo;
        private IOrderRepo orderRepo;
        private IUserRepo userRepo;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (!Session["user_role"].Equals("staff"))
            {
                Response.Redirect("/Home/Index");
            }
        }

        public OrdersController(IProductRepo productRepo, IOrderRepo orderRepo,IUserRepo userRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.userRepo = userRepo;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (!Session["user_role"].Equals("staff"))
            {
                Response.Redirect("/Home/Index");
            }
        }

        // GET: Orders/PlaceOrder
        public ActionResult PlaceOrder()
        {
            return View();
        }
        


        // GET: Orders
        public ActionResult Index()
        {
            return View(orderRepo.GetAll());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = orderRepo.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public JsonResult GetProducts(string term)
        {
            POSDBContext p = new POSDBContext();
            List<string> products;
            products = p.Products.Where(x => x.Title.StartsWith(term))
                .Select(y => y.Title).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetProductinfo(string title)
        {
            //POSDBContext p = new POSDBContext();
            //var products=p.Products;

            List<Product> data = productRepo.GetAll();

            Product product = new Product();
            foreach (var v in data)
            {
                if (v.Title.Equals(title))
                {
                    product = v;
                }
            }

            return Json(product, JsonRequestBehavior.AllowGet);

        }



        public ActionResult InsertOrder(int[] cart_data)
        {
            //POSDBContext p = new POSDBContext();
            //var products=p.Products;

            decimal total_amount = 0.0m;
            foreach (int data in cart_data)
            {
                Product p = productRepo.Get(data);
                p.Quantity -= 1;

                total_amount += p.SalePrice;
                productRepo.Update(p);

            }

            Order temp = new Order();
            temp.Id = 1;
            temp.Created = DateTime.Now;
            temp.PaymentType = "cash";
            temp.TotalAmount = total_amount;
            temp.user = userRepo.Get((int)Session["user_id"]);
            orderRepo.Insert(temp);
            return RedirectToAction("PlaceOrder");

        }


    }
}