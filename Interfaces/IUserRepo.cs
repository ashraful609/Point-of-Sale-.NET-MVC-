using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Interfaces
{
    public interface IUserRepo : IRepository<User>, ISearcher<User>
    {
        User Match(string uname, string pass);
        
    }
}
