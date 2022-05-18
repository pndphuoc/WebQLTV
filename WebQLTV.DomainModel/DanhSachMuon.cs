using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DomainModel
{
    public class DanhSachMuon
    {
        int MaDanhSachMuon { get; set; }
        List<Sach> DanhSachSach { get; set; }
    }
}
