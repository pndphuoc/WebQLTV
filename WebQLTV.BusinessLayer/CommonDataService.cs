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
        private static readonly IDanhSachMuonDAL danhSachMuonDB;
        private static readonly ICommonDAL<NhaXuatBan> nxbDB;
        private static readonly IChiTietMuonDAL ctmDB;
        private static readonly IWishlistDAL wishlistDB;
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
                    danhSachMuonDB = new DataLayer.SQLServer.DanhSachMuonDAL(connectionString);
                    nxbDB = new DataLayer.SQLServer.NhaXuatBanDAL(connectionString);
                    ctmDB = new DataLayer.SQLServer.ChiTietMuonDAL(connectionString);
                    wishlistDB = new DataLayer.SQLServer.WishlistDAL(connectionString);
                    break;
            }
        }
        #region Sách
        public static List<Sach> ListSach(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = sachDB.Count(searchValue);
            return sachDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Sach> ListSach()
        {
            return sachDB.List().ToList();
        }
        public static Sach GetSach(int MaSach)
        {
            return sachDB.Get(MaSach);
        }
        #endregion
        #region Tác giả
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
        #region Danh sách mượn
        public static bool AddSachMuon(int MaDocGia, int MaSach, int SoLuong)
        {
            return danhSachMuonDB.Add(MaDocGia, MaSach, SoLuong);
        }
        public static List<SachMuon> ListDanhSachMuon(int MaDocGia)
        {
            return danhSachMuonDB.List(MaDocGia);
        }
        public static bool DeleteDanhSachMuon(int MaDocGia)
        {
            return danhSachMuonDB.Delete(MaDocGia);
        }
        #endregion
        #region Nhà xuất bản
        public static NhaXuatBan GetNXB(int MaNXB)
        {
            return nxbDB.Get(MaNXB);
        }
        #endregion
        #region Chi tiết mượn
        public static void AddCTm(int MaDocGia, int SoLuongMuon, DanhSachMuon data)
        {
            ctmDB.Add(MaDocGia, SoLuongMuon, data);
        }
        #endregion
        #region wishlist
        public static void AddToWishlist(int MaDocGia, int MaSach)
        {
            wishlistDB.Add(MaDocGia, MaSach);
        }
        public static List<WishBook> ListWishlist(int MaDocGia)
        {
            return wishlistDB.ListWishlist(MaDocGia);
        }
        public static void DeleteWishlist(int MaDocGia, int MaSach)
        {
            wishlistDB.Delete(MaDocGia, MaSach);
        }
        public static int GetSoLuongSachCon(int MaSach)
        {
            return wishlistDB.GetSoLuongSachCon(MaSach);
        }
        #endregion
    }

}
