using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticalTest.Models
{
    public partial class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialNumber { get; set; }
        public string Nric { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? AvailableDate { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}
