using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLTV.Web.Models
{
    public class SachPaginationResult : BasePaginationResult
    {
        public List<Sach> Data { get; set; }
    }
}