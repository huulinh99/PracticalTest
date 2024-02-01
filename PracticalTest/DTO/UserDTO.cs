using PracticalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.DTO
{
    public class UserDTO
    {
        public int SerialNumber { get; set; }
        public string Nric { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public DateTime? AvailableDate { get; set; }
        public string SubjectName { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}