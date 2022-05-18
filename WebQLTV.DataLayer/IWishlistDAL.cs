using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer
{
    public interface IWishlistDAL
    {
        void Add(int MaDocGia, int MaSach);
        List<WishBook> ListWishlist(int MaDocGia);
        void Delete(int MaDocGia, int MaSach);
        int GetSoLuongSachCon(int MaSach);
    }
}
