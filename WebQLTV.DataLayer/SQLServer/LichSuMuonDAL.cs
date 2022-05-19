using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQLTV.DomainModel;

namespace WebQLTV.DataLayer.SQLServer
{
    public class LichSuMuonDAL : _BaseDAL, ILichSuMuonDAL
    {
        public LichSuMuonDAL(string connectionString) : base(connectionString)
        {
        }

        public IList<ChiTietMuon> GetList(int MaDocGia)
        {
            List<ChiTietMuon> data = new List<ChiTietMuon>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from ChiTietMuon where MaDocGia =@MaDocGia
                                    order by MaChiTietMuon Desc";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new ChiTietMuon()
                    {
                       MaDocGia = Convert.ToInt32(result["MaDocGia"]),
                       HanTra= Convert.ToDateTime(result["HanTra"]),
                       NgayMuon = Convert.ToDateTime(result["NgayMuon"]),
                       MaChiTietMuon = Convert.ToInt32(result["MaChiTietMuon"]),
                       SoLuongMuon = Convert.ToInt32(result["SoLuongMuon"]),
                       TrangThai = Convert.ToInt32(result["TrangThai"]),
                       ID_NguoiDung = Convert.ToInt32(result["MaNguoiDung"])
                       

                    });
                }
                cn.Close();
            }
            return data;
        }

        public IList<ChiTietMuon> GetListTT(int MaDocGia, int TrangThai)
        {
            List<ChiTietMuon> data = new List<ChiTietMuon>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from ChiTietMuon where MaDocGia =@MaDocGia and TrangThai=@TrangThai
                                    order by MaChiTietMuon Desc";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("MaDocGia", MaDocGia);
                cmd.Parameters.AddWithValue("TrangThai", TrangThai);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new ChiTietMuon()
                    {
                        MaDocGia = Convert.ToInt32(result["MaDocGia"]),
                        HanTra = Convert.ToDateTime(result["HanTra"]),
                        NgayMuon = Convert.ToDateTime(result["NgayMuon"]),
                        MaChiTietMuon = Convert.ToInt32(result["MaChiTietMuon"]),
                        SoLuongMuon = Convert.ToInt32(result["SoLuongMuon"]),
                        TrangThai = Convert.ToInt32(result["TrangThai"]),
                        ID_NguoiDung = Convert.ToInt32(result["MaNguoiDung"])


                    });
                }
                cn.Close();
            }
            return data;
        }

        public CheckDungHan InUsedLS(int MaChiTietMuon, int MaSach)
        {
            CheckDungHan data =new CheckDungHan();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select NgayTra,TraDungHan,MaSach
                                    from Sach_ChiTietTra as sctt join ChiTietTra as ctt
	                                    on sctt.MaChiTietTra = ctt.MaChiTietTra
	                                    where MaChiTietMuon = @mctm and MaSach=@ms";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("mctm", MaChiTietMuon);
                cmd.Parameters.AddWithValue("ms", MaSach);
                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (result.Read())
                {
                    data = new CheckDungHan()
                    {
                        TraDungHan = Convert.ToBoolean(result["TraDungHan"]),
                        NgayTra = Convert.ToDateTime(result["NgayTra"]),
                        MaSach = Convert.ToInt32(result["MaSach"])
                    };
                }
                cn.Close();
            }
            return data;
        }

        public IList<ChiTietSachMuon> ListCTMuon(int MaChiTietMuon)
        {
            List<ChiTietSachMuon> data = new List<ChiTietSachMuon>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from Sach_ChiTietMuon where MaChiTietMuon =@MaChiTietMuon";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("MaChiTietMuon", MaChiTietMuon);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new ChiTietSachMuon()
                    {
                        MaSach = Convert.ToInt32(result["MaSach"]),
                        SoLuong = Convert.ToInt32(result["SoLuong"]),
                        TrangThai = Convert.ToBoolean(result["TrangThai"]),
                        MaChiTietMuon = Convert.ToInt32(result["MaChiTietMuon"])
                    });
                }
                cn.Close();
            }
            return data;
        }
    }
}
