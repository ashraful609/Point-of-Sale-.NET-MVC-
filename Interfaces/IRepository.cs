using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<Model> where Model : EntityModel
    {
        List<Model> GetAll();
        Model Get(int id);
        int Insert(Model model);
        int Update(Model model);
        int Delete(Model model);
    }
}
