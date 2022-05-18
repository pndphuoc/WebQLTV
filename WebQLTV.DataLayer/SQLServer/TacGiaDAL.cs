using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class TacGiaDAL : _BaseDAL, ITacGiaDAL
    {
        public TacGiaDAL(string connectionString) : base(connectionString)
        {
        }


        public List<TacGia> List(int MaSach)
        {
            List<TacGia> lstTacGia = new List<TacGia>();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from Sach_TacGia as stg join TacGia as tg on tg.MaTacGia = stg.MaTacGia 
                                where stg.MaSach = @MaSach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@MaSach", MaSach);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dbReader.Read())
                {
                    lstTacGia.Add(new TacGia()
                    {
                        MaTacGia = Convert.ToInt32(dbReader["MaTacGia"]),
                        TenTacGia = Convert.ToString(dbReader["TenTacGia"]),
                        GhiChu = Convert.ToString(dbReader["GhiChu"])

                    });
                }
                cn.Close();
            }
            return lstTacGia;
        }

        /// <summary>
        ///  lay thong tin tac gia
        /// </summary>
        /// <param name="matacgia"></param>
        /// <returns></returns>
        public TacGia Get(int matacgia)
        {
            TacGia data = null;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TacGia where MaTacGia = @matacgia";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@matacgia", matacgia);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (dbReader.Read())
                {
                    data = new TacGia()
                    {
                        MaTacGia = Convert.ToInt32(dbReader["MaTacGia"]),
                        TenTacGia = Convert.ToString(dbReader["TenTacGia"]),
                        GhiChu = Convert.ToString(dbReader["GhiChu"])

                    };
                }

                cn.Close();
            }

            return data;
        }
    }
}
