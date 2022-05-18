using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer
{
    public interface ICartDAL
    {
        int insertCart(int MaSach);
        bool deleteCart(int MaSach);
    }
}
