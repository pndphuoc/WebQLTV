using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class NhaXuatBanDAL : _BaseDAL, ICommonDAL<NhaXuatBan>
    {
        public NhaXuatBanDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(NhaXuatBan data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue = "")
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public NhaXuatBan Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NhaXuatBan> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            throw new NotImplementedException();
        }

        public bool Update(NhaXuatBan data)
        {
            throw new NotImplementedException();
        }
    }
}
