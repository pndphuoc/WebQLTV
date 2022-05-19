using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer
{
    public interface IChiTietMuonDAL
    {
        void Add(int MaDocGia, int SoLuongMuon, DanhSachMuon data);
    }
}
