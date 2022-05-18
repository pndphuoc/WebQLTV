using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class TacGiaDAL : _BaseDAL, ICommonDAL<TacGia>
    {
        public TacGiaDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(TacGia data)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// dem tac gia
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
                                    from TacGia
                                    where (@searchValue = N'')
                                        or(
                                                (TenTacGia like @searchValue)
                                                
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

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Hien thi danh sach cac Tac gia 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public IList<TacGia> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<TacGia> data = new List<TacGia>();

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from
                                        (
                                            select *,
                                                    row_number() over(order by TenTacGia) as RowNumber
                                            from TacGia
                                            where (@searchValue = N'')
                                                or(
                                                        (TenTacGia like @searchValue)
                                                      
                                                        
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
                    data.Add(new TacGia()
                    {
                        MaTacGia = Convert.ToInt32(result["MaTacGia"]),
                        TenTacGia = Convert.ToString(result["TenTacGia"]),
                        GhiChu = Convert.ToString(result["GhiChu"])
                        
                    });
                }

                cn.Close();
            }
            return data;
        }

        public bool Update(TacGia data)
        {
            throw new NotImplementedException();
        }
    }
}
