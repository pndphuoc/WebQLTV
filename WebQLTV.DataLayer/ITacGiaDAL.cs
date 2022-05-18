using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer
{
    public interface ITacGiaDAL
    {
        List<TacGia> List(int MaSach);

    }
}
