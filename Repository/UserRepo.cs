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
    public class UserRepo : Repository<User>, IUserRepo, ISearcher<User>
    {
        POSDBContext context;
        public UserRepo(POSDBContext context) : base(context)
        {
            this.context = context;
        }

        public User Match(string uname, string pass)
        {
            return context.Users.SingleOrDefault(i => i.UserName == uname && i.Password == pass);
        }

        public List<User> GetByName(string searchTerm)
        {
            return context.Users.Where(i => i.UserName.Contains(searchTerm)).ToList();

        }
    }
}
