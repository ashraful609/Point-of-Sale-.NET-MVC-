using Data;
using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        POSDBContext context;
        public ProductRepo(POSDBContext context) : base(context)
        {
            this.context = context;
        }

        public List<Product> GetByName(string searchTerm)
        {
            return context.Products.Where(i => i.Title.Contains(searchTerm)).ToList();
        }
    }
}
