using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderDetail : EntityModel
    {

        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public Product product { get; set; }
        public Order order { get; set; }
    }
}
