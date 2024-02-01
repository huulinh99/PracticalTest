using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticalTest.Utils
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Data = new List<T>();
        }
        public List<T> Data { get; set; }
        public PaginationMetadata Metadata { get; set; }
    }
}