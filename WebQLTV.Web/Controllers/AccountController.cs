using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.BusinessLayer;

namespace WebQLTV.Web.Controllers
{
    [Authorize]
    public class AccountController :Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //TODO: Code lại để kiểm tra đúng tài khoản đăng nhập
            DocGia acc = TaiKhoanDataService.CheckLogin(username, password);

            if (acc !=null)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(username, false);
                DocGia DG =TaiKhoanDataService.GetDocGia(username);
                Session["MaDocGia"] = DG.MaDocGia;
                Session["Account"] = acc;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.UserName = username;
            ViewBag.Message = "Đăng nhập thất bại";
            return View();
        }


        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}