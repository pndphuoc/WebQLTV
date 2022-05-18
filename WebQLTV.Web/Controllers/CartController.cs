using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.DomainModel;

namespace WebQLTV.Web.Controllers
{
    [RoutePrefix("Cart")]
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            DanhSachMuon dsm = new DanhSachMuon();
            DocGia acc = Session["Account"] as DocGia;
            if (acc == null)
            {
                acc = WebQLTV.BusinessLayer.TaiKhoanDataService.GetDocGia(User.Identity.Name);
                Session["Account"] = acc;
            }

            dsm.data = WebQLTV.BusinessLayer.CommonDataService.ListDanhSachMuon(acc.MaDocGia);
            Session["DanhSachMuon"] = dsm;
            return View(dsm);
        }
        [Route("xacnhanmuon")]
        public ActionResult XacNhanMuon()
        {
            DocGia acc = Session["Account"] as DocGia;
            var dsm = (DanhSachMuon)Session["DanhSachMuon"];
            int sl = 0;
            foreach (var item in dsm.data)
            {
                sl += item.SoLuong;
            }

            foreach (var item in dsm.data)
            {
                int curSL = BusinessLayer.CommonDataService.GetSach(item.MaSach).SoLuongCon;
                if (item.SoLuong > curSL)
                {
                    ModelState.AddModelError("SoLuong", "Số lượng một trong những quyển sách này không còn đủ để quý khách mượn! Vui lòng điều chỉnh lại số lượng mượn");
                }
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            WebQLTV.BusinessLayer.CommonDataService.AddCTm(acc.MaDocGia, sl, dsm);
            WebQLTV.BusinessLayer.CommonDataService.DeleteDanhSachMuon(acc.MaDocGia);
            return RedirectToAction("Index");
        }
        [Route("delete/{MaSach}")]
        public ActionResult Delete(int MaSach)
        {
            DocGia acc = Session["Account"] as DocGia;
            WebQLTV.BusinessLayer.CommonDataService.DeleteDanhSachMuon(acc.MaDocGia);
            return RedirectToAction("Index");
        }
    }
}