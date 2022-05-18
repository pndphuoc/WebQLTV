using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DataLayer;

namespace WebQLTV.BusinessLayer
{
    public class TaiKhoanDataService
    {
        private static readonly ITaiKhoanDAL taikhoanDB;


        static TaiKhoanDataService()
        {
            string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            switch (provider)
            {
                case "SQLServer":
                    taikhoanDB = new DataLayer.SQLServer.TaiKhoanDAL(connectionString);

                    break;
            }
        }


        /// <summary>
        /// kiem tra dang nhap
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckLogin(string username, string password)
        {
            return taikhoanDB.CheckLogin(username, password);
        }
    }
}
