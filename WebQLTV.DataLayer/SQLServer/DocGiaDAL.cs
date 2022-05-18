using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class DocGiaDAL : _BaseDAL, ICommonDAL<DocGia>
    {
        public DocGiaDAL(string connectionString) : base(connectionString)
        {
        }
        public int Add(DocGia data)
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

        public DocGia Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DocGia> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            throw new NotImplementedException();
        }

        public bool Update(DocGia data)
        {
            throw new NotImplementedException();
        }
    }
}
