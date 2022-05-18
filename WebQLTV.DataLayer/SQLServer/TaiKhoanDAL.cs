using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class TaiKhoanDAL : _BaseDAL, ITaiKhoanDAL
    {
        public TaiKhoanDAL(string connectionString) : base(connectionString)
        {
        }

        public bool CheckLogin(string username, string password)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from DocGia where (UserName = @username) and (Password = @password)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                result = Convert.ToBoolean(cmd.ExecuteScalar());

                cn.Close();
            }
            return result;
        }

        public bool ChangePass(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
