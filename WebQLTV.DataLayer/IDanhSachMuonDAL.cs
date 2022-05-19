using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer
{
    public interface IDanhSachMuonDAL
    {
        bool Add(int MaDocGia, int MaSach, int SoLuong);
        bool Delete(int MaDocGia);
        bool Update(int MaDocGia, SachMuon data);
        List<SachMuon> List(int MaDocGia);
    }
}
