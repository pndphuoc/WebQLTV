using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer.SQLServer
{
    public class WishlistDAL : _BaseDAL, IWishlistDAL
    {
        public WishlistDAL(string connectionString) : base(connectionString)
        {
        }

        public void Add(int MaDocGia, int MaSach)
        {
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"if not exists (select * from Wishlist
                                where MaDocGia = @MaDocGia and MaSach = @MaSach) insert into Wishlist values (@MaDocGia, @MaSach)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);
                cmd.Parameters.AddWithValue("MaSach", MaSach);

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public void Delete(int MaDocGia, int MaSach)
        {
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"delete from Wishlist
                                where MaDocGia = @MaDocGia and MaSach = @MaSach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);
                cmd.Parameters.AddWithValue("MaSach", MaSach);

                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }

        public int GetSoLuongSachCon(int MaSach)
        {
            int sl = 0;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select SoLuongCon from Sach where MaSach = @MaSach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaSach", MaSach);

                sl = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            return sl;
        }

        public List<WishBook> ListWishlist(int MaDocGia)
        {
            var listWL = new List<WishBook>();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from Wishlist where MaDocGia = @MaDocGia";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dbReader.Read())
                {
                    listWL.Add(new WishBook()
                    {
                        MaSach = Convert.ToInt32(dbReader["MaSach"])
                    });
                }
                cn.Close();
            }
            for (int i =0; i< listWL.Count; i++)
            {
                using (SqlConnection cn = OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"select min(ctm.HanTra) from ChiTietMuon as ctm 
                                        join Sach_ChiTietMuon as sctm on ctm.MaChiTietMuon = sctm.MaChiTietMuon 
                                        where sctm.MaSach = @MaSach";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("MaSach", listWL[i].MaSach);

                    listWL[i].NgayDuKien = Convert.ToDateTime(cmd.ExecuteScalar());

                    cn.Close();
                }
            }
            return listWL;
        }
    }
}
