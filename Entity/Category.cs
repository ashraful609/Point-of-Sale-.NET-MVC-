using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category : EntityModel
    {
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
    }
}
