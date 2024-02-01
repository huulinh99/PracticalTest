using PracticalTest.DTO;
using PracticalTest.Models;
using PracticalTest.Utils;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PracticalTest.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserList = new List<UserDTO>();
            Metadata = new PaginationMetadata();
            Users = new Users();
        }
        public List<UserDTO> UserList { get; set; }
        public SelectList SubjectList { get; set; }
        public PaginationMetadata Metadata { get; set; }
        public Users Users { get; set; }
    }
}