using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product : EntityModel
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public Category Category { get; set; }
    }
}
