using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer
{
    public interface ICommonDAL<T> where T : class
    {
        IList<T> List(int page = 1, int pageSize = 0, string searchValue = "");
        int Count(string searchValue = "");
        T Get(int id);
        int Add(T data);
        bool Update(T data);
        bool Delete(int id);
        bool InUsed(int id);

    }
}

