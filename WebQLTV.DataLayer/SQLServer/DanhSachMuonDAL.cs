using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer.SQLServer
{
    public class DanhSachMuonDAL : _BaseDAL, IDanhSachMuonDAL
    {
        public DanhSachMuonDAL(string connectionString) : base(connectionString)
        {
        }

        public bool Add(int MaDocGia, int MaSach, int SoLuong)
        {
            bool result = false;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"if not exists (select * from DanhSachMuon where MaDocGia = @MaDocGia and MaSach = @MaSach)
                                    begin
                                        insert into DanhSachMuon (MaDocGia, MaSach, SoLuong) 
                                        values (@MaDocGia, @MaSach, @SoLuong)
                                    end
                                    else
                                    begin
                                        update DanhSachMuon set SoLuong = SoLuong + 1 where MaDocGia = @MaDocGia and MaSach = @MaSach
                                    end";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);
                cmd.Parameters.AddWithValue("MaSach", MaSach);
                cmd.Parameters.AddWithValue("SoLuong", SoLuong);

                result = cmd.ExecuteNonQuery() > 0;

                cn.Close();
            }
            return result;
        }

        public bool Delete(int MaDocGia)
        {
            bool result;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"delete from DanhSachMuon where MaDocGia = @MaDocGia";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);

                result = cmd.ExecuteNonQuery() > 0;

                cn.Close();
            }
            return result;
        }

        public List<SachMuon> List(int MaDocGia)
        {
            List<SachMuon> lstSach = new List<SachMuon>();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select * from DanhSachMuon where MaDocGia = @MaDocGia";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    lstSach.Add(new SachMuon()
                    {
                        MaSach = Convert.ToInt32(result["MaSach"]),
                        SoLuong = Convert.ToInt32(result["SoLuong"])
                    });
                }

                cn.Close();
            }
            return lstSach;
        }


        public bool Update(int MaDocGia, SachMuon data)
        {
            throw new NotImplementedException();
        }
    }
}
