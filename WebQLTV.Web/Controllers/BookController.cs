using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.Web.Models;
using WebQLTV;

namespace WebQLTV.Web.Controllers
{
    [RoutePrefix("Book")]
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            //PaginationSearchInput model = Session["BOOK_SEARCH"] as PaginationSearchInput;
            //if (model == null)
            //{
            //    model = new PaginationSearchInput()
            //    {
            //        Page = 1,
            //        PageSize = 10,
            //        SearchValue = ""
            //    };
            //}
            return View();
        }
        public ActionResult Search(Models.PaginationSearchInput input)
        {
            int rowCount = 0;
            var data = BusinessLayer.CommonDataService.ListSach(input.Page, input.PageSize, input.SearchValue, out rowCount);
            Models.SachPaginationResult model = new Models.SachPaginationResult()
            {
                Page = input.Page,
                PageSize = input.PageSize,
                SearchValue = input.SearchValue,
                RowCount = rowCount,
                Data = data
            };
            Session["SACH_SEARCH"] = input;
            return View(model);
        }
        //[Route("addtocart/{maSach}")]
        //public ActionResult AddToCart(int MaSach)
        //{

        //}

    }
}