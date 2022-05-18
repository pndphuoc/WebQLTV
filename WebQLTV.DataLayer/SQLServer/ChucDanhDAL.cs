using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class ChucDanhDAL : _BaseDAL, ICommonDAL<ChucDanh>
    {
        public ChucDanhDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(ChucDanh data)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Dem 
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public int Count(string searchValue = "")
        {
            int count = 0;

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select count(*)
                                    from ChucDanh
                                    where (@searchValue = N'')
                                        or(
                                                (TenChucDanh like @searchValue)
                                                
                                            )";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                count = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            return count;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Lay thong tin chuc danh
        /// </summary>
        /// <param name="machucdanh"></param>
        /// <returns></returns>
        public ChucDanh Get(int machucdanh)
        {
            ChucDanh data = null;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from ChucDanh where MaChucDanh = @machucdanh";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@machucdanh", machucdanh);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (dbReader.Read())
                {
                    data = new ChucDanh()
                    {
                        MaChucDanh = Convert.ToInt32(dbReader["MaChucDanh"]),
                        TenChucDanh = Convert.ToString(dbReader["TenChucDanh"]),
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



        /// <summary>
        /// Hien thi danh sach Chuc danh
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public IList<ChucDanh> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<ChucDanh> data = new List<ChucDanh>();

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from
                                        (
                                            select *,
                                                    row_number() over(order by TenChucDanh) as RowNumber
                                            from ChucDanh
                                            where (@searchValue = N'')
                                                or(
                                                        (TenChucDanh like @searchValue)
                                                      
                                                        
                                                    )
                                        ) as t
                                    where (@pageSize=0) or (t.RowNumber between(@page -1) *@pageSize + 1 and @page *@pageSize)
                                    order by t.RowNumber; ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new ChucDanh()
                    {
                        MaChucDanh = Convert.ToInt32(result["MaChucDanh"]),
                        TenChucDanh = Convert.ToString(result["TenChucDanh"]),
                        GhiChu = Convert.ToString(result["GhiChu"])

                    });
                }

                cn.Close();
            }
            return data;
        }

        public bool Update(ChucDanh data)
        {
            throw new NotImplementedException();
        }
    }
}
