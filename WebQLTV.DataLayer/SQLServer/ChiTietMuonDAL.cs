using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer.SQLServer
{
    public class ChiTietMuonDAL : _BaseDAL, IChiTietMuonDAL
    {
        public ChiTietMuonDAL(string connectionString) : base(connectionString)
        {
        }


        public void Add(int MaDocGia, int SoLuongMuon, DanhSachMuon dsm)
        {
            int MaCTM = 0;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"insert into ChiTietMuon (MaDocGia, NgayMuon, SoLuongMuon, HanTra, TrangThai) 
                                    values(@MaDocGia, Getdate(), @SoLuongMuon, dateadd(month, 1, getdate()), -1)
                                    select @@identity";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);
                cmd.Parameters.AddWithValue("SoLuongMuon", SoLuongMuon);

                MaCTM = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            using (SqlConnection cn = OpenConnection())
            {
                foreach (var item in dsm.data)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = @"insert into Sach_ChiTietMuon (MaChiTietMuon, MaSach, TrangThai, SoLuong)
                                        values(@MaChiTietMuon, @MaSach, -1, @SoLuong)
                                        update Sach set SoLuongCon = SoLuongCon - @SoLuong where MaSach = @MaSach";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("MaChiTietMuon", MaCTM);
                    cmd.Parameters.AddWithValue("MaSach", item.MaSach);
                    cmd.Parameters.AddWithValue("SoLuong", item.SoLuong);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
