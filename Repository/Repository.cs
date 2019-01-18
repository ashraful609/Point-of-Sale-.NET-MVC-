using Entity;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.Entity.Migrations;

namespace Repository
{
    public class Repository<Model> : IRepository<Model> where Model : EntityModel
    {
        public POSDBContext Context { get; }
        public Repository(POSDBContext context)
        {
            this.Context = context;
        }

        public int Delete(Model model)
        {
            Context.Set<Model>().Remove(model);
            return Context.SaveChanges();
        }

        public Model Get(int id)
        {
            return Context.Set<Model>().Find(id);
        }

        public List<Model> GetAll()
        {
            return Context.Set<Model>().ToList();
        }

        public int Insert(Model model)
        {
            Context.Set<Model>().Add(model);
            return Context.SaveChanges();
        }

        public int Update(Model model)
        {
            Context.Set<Model>().AddOrUpdate(model);
            return Context.SaveChanges();
        }
    }
}
