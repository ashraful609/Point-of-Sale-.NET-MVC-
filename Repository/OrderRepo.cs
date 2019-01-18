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
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        POSDBContext context;
        public OrderRepo(POSDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
