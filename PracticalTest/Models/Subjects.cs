﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticalTest.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
