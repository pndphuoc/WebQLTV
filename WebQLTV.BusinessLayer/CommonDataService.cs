using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DataLayer;
using WebQLTV.DomainModel;

namespace WebQLTV.BusinessLayer
{
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Sach> sachDB;
        private static readonly ITacGiaDAL tacGiaDB;
        private static readonly ILichSuMuonDAL lichsuDB;
        static CommonDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            switch (provider)
            {
                case "SQLServer":
                    sachDB = new DataLayer.SQLServer.SachDAL(connectionString);
                    tacGiaDB = new DataLayer.SQLServer.TacGiaDAL(connectionString);
                    lichsuDB = new DataLayer.SQLServer.LichSuMuonDAL(connectionString);
                    break;
            }
        }
        public static List<Sach> ListSach(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = sachDB.Count(searchValue);
            return sachDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Sach> ListSach()
        {
            return sachDB.List().ToList();
        }

        #region
        public static List<TacGia> ListTacGia(int MaSach)
        {
            return tacGiaDB.List(MaSach).ToList();
        }
        #endregion

        #region Lịch sử mượn trả

        public static List<ChiTietMuon> ListLS(int MaDocGia)
        {
            return lichsuDB.GetList(MaDocGia).ToList();
        }
        public static List<ChiTietSachMuon> ListCTMuon(int MaChiTietMuon)
        {
            return lichsuDB.ListCTMuon(MaChiTietMuon).ToList();
        }
        public static CheckDungHan InUsedLS(int MaChiTietMuon, int MaSach)
        {
            return lichsuDB.InUsedLS(MaChiTietMuon, MaSach);
        }
        public static List<ChiTietMuon> ListLSTT(int MaDocGia,int TrangThai)
        {
            return lichsuDB.GetListTT(MaDocGia, TrangThai).ToList();
        }
        #endregion
    }

}
