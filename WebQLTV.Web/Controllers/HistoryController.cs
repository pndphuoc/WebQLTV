
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLTV.BusinessLayer;
using WebQLTV.DomainModel;

namespace WebQLTV.Web.Controllers
{   
    [Authorize]
    public class HistoryController: Controller
    {
        public ActionResult Index(int? TrangThai)
        {
            ViewBag.s = TrangThai;
            if (TrangThai != null)
            {
                List<ChiTietMuon> model = CommonDataService.ListLSTT(Convert.ToInt32(Session["MaDocGia"]),(int)TrangThai);
                return View(model);
            }
            else
            {
                List<ChiTietMuon> model = CommonDataService.ListLS(Convert.ToInt32(Session["MaDocGia"]));
                return View(model);
            }

            
            
        }
       
    }
}