using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DataLayer;

namespace WebQLTV.BusinessLayer
{
    public static class CommonDataService
    {
        private static readonly ICommonDAL<Sach> sachDB;
        static CommonDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            switch (provider)
            {
                case "SQLServer":
                    sachDB = new DataLayer.SQLServer.SachDAL(connectionString);
                    break;
            }
        }
        public static List<Sach> ListSach(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = sachDB.Count(searchValue);
            return sachDB.List(page, pageSize, searchValue).ToList();
        }
        public static List<Sach> ListSach()
        {
            return sachDB.List().ToList();
        }
    }
    
}
