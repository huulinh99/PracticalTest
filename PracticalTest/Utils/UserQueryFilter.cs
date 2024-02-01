using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Utils
{
    public class UserQueryFilter
    {
        public string SearchValue { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}