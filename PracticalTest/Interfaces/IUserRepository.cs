using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        IEnumerable<Users> GetUsersByNRICOrName(string value);
    }
}
