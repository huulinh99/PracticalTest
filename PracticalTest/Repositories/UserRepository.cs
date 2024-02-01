using PracticalTest.Interfaces;
using PracticalTest.Models;
using PracticalTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Repositories
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(PracticalTestContext context) : base(context)
        {
        }

        public IEnumerable<Users> GetUsersByNRICOrName(string value)
        {
            var users = new List<Users>();
            try
            {
                users = _entities.Where(x => x.Nric.Contains(value) || x.Name.Contains(value)).ToList();
            }
            catch (Exception e)
            {
                TraceLog.WriteToLog(string.Format("Failed when get GetUsersByNRICOrName ") + e.Message.ToString());
            }
            return users;
        }
    }
}