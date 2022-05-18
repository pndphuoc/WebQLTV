using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.Web.Models;
using WebQLTV;
using QuanLyThuVIen.Model;

namespace WebQLTV.Web.Controllers
{
    [RoutePrefix("Book")]
    public class BookController : Controller
    {
        public ActionResult Index()
        {
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
        [Route("addtocart/{MaSach}/{bit}")]
        public ActionResult AddToCart(int MaSach, int bit)
        {
            DocGia acc = Session["Account"] as DocGia;
            if(acc==null)
            {
                acc = WebQLTV.BusinessLayer.TaiKhoanDataService.GetDocGia(User.Identity.Name);
                Session["Account"] = acc;
            }
            WebQLTV.BusinessLayer.CommonDataService.AddSachMuon(acc.MaDocGia, MaSach, 1);
            if(bit==1)
            {
                BusinessLayer.CommonDataService.DeleteWishlist(acc.MaDocGia, MaSach);
                return RedirectToAction("Index", "wishlist");
            }
            return View("Index");
        }
        [Route("addtowishlist/{MaSach}")]
        public ActionResult AddToWishlist(int MaSach)
        {
            DocGia acc = Session["Account"] as DocGia;
            if (acc == null)
            {
                acc = WebQLTV.BusinessLayer.TaiKhoanDataService.GetDocGia(User.Identity.Name);
                Session["Account"] = acc;
            }
            BusinessLayer.CommonDataService.AddToWishlist(acc.MaDocGia, MaSach);
            return View("Index");
        }

    }
}