using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer
{
    public interface ILichSuMuonDAL
    {
        IList<ChiTietMuon> GetList(int MaDocGia);
        CheckDungHan InUsedLS(int MaChiTietMuon, int MaSach);
        IList<ChiTietSachMuon> ListCTMuon(int MaChiTietMuon);
        IList<ChiTietMuon> GetListTT(int MaDocGia,int TrangThai);

    }
}
