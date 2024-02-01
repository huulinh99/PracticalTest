using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Utils
{
    public class PaginationOptions
    {
        public int DefaultPageSize { get; set; }
        public int DefaultPageNumber { get; set; }
        public int MaxPageSize { get; set; }
    }
}