using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbSeeder:DropCreateDatabaseIfModelChanges<POSDBContext>
    {
        protected override void Seed(POSDBContext context)
        {
            base.Seed(context);
            // Admin User
            User user = new User();
            user.Id = 1;
            user.UserName = "admin";
            user.UserRole = "admin";
            user.Password = "pass";
            user.ConfirmPassword = "pass";
            user.UserStatus = 1;
            user.Firstname = "admin";
            user.Lastname = "user";
            user.Email = "admin@pos.com";
            user.Registered = DateTime.Now;
            user.Phone = "+880168123123";

            context.Users.Add(user);
            context.SaveChanges();

            // Demo Category
            Category category = new Category();
            category.Id = 1;
            category.CategoryName = "Cloth";
            category.Created = DateTime.Now;
            context.Categories.Add(category);
            context.SaveChanges();

            // Demo Product
            Product product = new Product();
            product.Id = 1;
            product.Category = category;
            product.Active = true;
            product.Created = DateTime.Now;
            product.Edited = DateTime.Now;
            product.Quantity = 5;
            product.SalePrice = 500;
            product.UnitPrice = 250;
            product.Title = "T-Shirt";
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}
