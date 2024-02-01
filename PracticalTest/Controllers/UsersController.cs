using PracticalTest.DTO;
using PracticalTest.Interfaces;
using PracticalTest.Models;
using PracticalTest.Utils;
using PracticalTest.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PracticalTest.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;

        public UsersController(IUserService userService, ISubjectService subjectService)
        {
            _userService = userService;
            _subjectService = subjectService;
        }

        // GET: Users
        public ActionResult UserDetails(UserQueryFilter filters)
        {
            var users = _userService.GetUsers(filters);
            var subjects = _subjectService.GetSubjects();
            var userViewModel = new UserViewModel
            {
                UserList = users.Data,
                Metadata = users.Metadata,
                SubjectList = new SelectList(subjects, "Id", "SubjectName")
            };

            if (users != null)
            {
                return View("UserDetails", userViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public void AddUser(Users users)
        {
            _userService.InsertUser(users);
        }

        [HttpPost]
        public ActionResult EditUser(string ID)
        {
            var userViewModel = _userService.GetById(ID);

            if (userViewModel != null)
            {
                return View("_AddUserDetails", userViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public void UpdateUser(Users users)
        {
            _userService.UpdateUser(users);
        }
    }
}