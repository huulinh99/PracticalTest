using PracticalTest.DTO;
using PracticalTest.Models;
using PracticalTest.Utils;
using PracticalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Interfaces
{
    public interface IUserService
    {
        PagedResult<UserDTO> GetUsers(UserQueryFilter filters);
        UserViewModel GetById(string id);
        void InsertUser(Users user);
        void UpdateUser(Users user);
    }
}
