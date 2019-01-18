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
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(POSDBContext context) : base(context)
        {

        }
    }
}
