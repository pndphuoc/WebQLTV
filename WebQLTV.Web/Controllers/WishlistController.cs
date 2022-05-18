using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.DomainModel;

namespace WebQLTV.Web.Controllers
{
    [RoutePrefix("Wishlist")]
    public class WishlistController : Controller
    {
        public ActionResult Index()
        {
            DocGia acc = Session["Account"] as DocGia;
            if (acc == null)
            {
                acc = WebQLTV.BusinessLayer.TaiKhoanDataService.GetDocGia(User.Identity.Name);
                Session["Account"] = acc;
            }
            List<WishBook> lstWB = BusinessLayer.CommonDataService.ListWishlist(acc.MaDocGia);
            return View(lstWB);
        }
        [Route("delete/{MaSach}")]
        public ActionResult Delete(int MaSach)
        {
            DocGia acc = Session["Account"] as DocGia;
            if (acc == null)
            {
                acc = WebQLTV.BusinessLayer.TaiKhoanDataService.GetDocGia(User.Identity.Name);
                Session["Account"] = acc;
            }
            BusinessLayer.CommonDataService.DeleteWishlist(acc.MaDocGia, MaSach);
            return RedirectToAction("Index");
        }
    }
}