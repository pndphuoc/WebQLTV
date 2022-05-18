using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            NhaXuatBan data = null;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from NhaXuatBan where MaNhaXuatBan = @MaNhaXuatBan";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@MaNhaXuatBan", id);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (dbReader.Read())
                {
                    data = new NhaXuatBan()
                    {
                        MaNhaXuatBan = Convert.ToInt32(dbReader["MaNhaXuatBan"]),
                        TenNhaXuatBan = Convert.ToString(dbReader["TenNhaXuatBan"]),
                        GhiChu = Convert.ToString(dbReader["GhiChu"])

                    };
                }

                cn.Close();
            }

            return data;
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NhaXuatBan> List()
        {
            List<NhaXuatBan> data = new List<NhaXuatBan>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from NhaXuatBan";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;


                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new NhaXuatBan()
                    {
                        MaNhaXuatBan = Convert.ToInt32(result["MaNhaXuatBan"]),
                         TenNhaXuatBan = Convert.ToString(result["TenNhaXuatBan"]),
                         GhiChu = Convert.ToString(result["GhiChu"])
                    });
                }
                cn.Close();
            }
            return data;
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
