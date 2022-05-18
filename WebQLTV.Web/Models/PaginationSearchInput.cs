using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLTV.Web.Models
{
    public class PaginationSearchInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchValue { get; set; }
    }
}