using QuanLyThuVIen.Model;
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



        /// <summary>
        /// Kiem tra dang nhap
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DocGia CheckLogin(string username, string password)
        {
            DocGia acc = new DocGia();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from DocGia where (UserName = @username) and (Password = @password)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if(dbReader.Read())
                {
                    acc = new DocGia()
                    {
                        MaDocGia = Convert.ToInt32(dbReader["MaDocGia"]),
                        TenDocGia = Convert.ToString(dbReader["TenDocGia"]),
                        NgaySinh = Convert.ToDateTime(dbReader["NgaySinh"]),
                        MaChucDanh = Convert.ToInt32(dbReader["MaChucDanh"]),
                        GioiTinh = Convert.ToBoolean(dbReader["GioiTinh"]),
                        Email = Convert.ToString(dbReader["Email"]),
                        DiaChi = Convert.ToString(dbReader["DiaChi"]),
                        SoDienThoai = Convert.ToString(dbReader["SoDienThoai"]),
                        NgayDangKy = Convert.ToDateTime(dbReader["NgayDangKy"]),
                        NgayHetHan = Convert.ToDateTime(dbReader["NgayHetHan"]),
                        Lop = Convert.ToString(dbReader["Lop"]),
                        MaKhoa = Convert.ToInt32(dbReader["MaKhoa"]),
                        KhoaHoc = Convert.ToInt32(dbReader["KhoaHoc"]),
                        Username = Convert.ToString(dbReader["Username"]),
                        Password = Convert.ToString(dbReader["Password"])
                    };
                }
                cn.Close();
            }
            return acc;
        }



        /// <summary>
        /// Lay thong tin doc gia bang ma doc gia
        /// </summary>
        /// <param name="MaDocGia"></param>
        /// <returns></returns>
        public DocGia GetDocGia (string username)
        {
            DocGia data = null;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from DocGia where Username = @username";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@username", username);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (dbReader.Read())
                {
                    data = new DocGia()
                    {
                        MaDocGia = Convert.ToInt32(dbReader["MaDocGia"]),
                        TenDocGia = Convert.ToString(dbReader["TenDocGia"]),
                        NgaySinh = Convert.ToDateTime(dbReader["NgaySinh"]),
                        MaChucDanh = Convert.ToInt32(dbReader["MaChucDanh"]),
                        GioiTinh = Convert.ToBoolean(dbReader["GioiTinh"]),
                        Email = Convert.ToString(dbReader["Email"]),
                        DiaChi = Convert.ToString(dbReader["DiaChi"]),
                        SoDienThoai = Convert.ToString(dbReader["SoDienThoai"]),
                        NgayDangKy = Convert.ToDateTime(dbReader["NgayDangKy"]),
                        NgayHetHan = Convert.ToDateTime(dbReader["NgayHetHan"]),
                        Lop = Convert.ToString(dbReader["Lop"]),
                        MaKhoa = Convert.ToInt32(dbReader["MaKhoa"]),
                        KhoaHoc = Convert.ToInt32(dbReader["KhoaHoc"]),
                        Username = Convert.ToString(dbReader["Username"]),
                        Password = Convert.ToString(dbReader["Password"])

                    };
                }

                cn.Close();
            }
            return data;
        }


        /// <summary>
        /// Thay doi mat khau
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ChangePass(string username, string password)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"update DocGia set Password = @password where Username = @username ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                result = Convert.ToBoolean(cmd.ExecuteScalar());

                cn.Close();
            }
            return result;
        }


        
    }
}
