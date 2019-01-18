using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order : EntityModel
    {
        public DateTime Created { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentType { get; set; }

        public User user { get; set; }
    }
}
