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



        #region cac ham lien quan den tai khoan doc gia
        
        
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


        /// <summary>
        /// Lay thong tin cua doc gia bang ma doc gia
        /// </summary>
        /// <param name="madocgia"></param>
        /// <returns></returns>
        public static DocGia GetDocGia (string username)
        {
            return taikhoanDB.GetDocGia(username);
        }
        #endregion
    }
}
