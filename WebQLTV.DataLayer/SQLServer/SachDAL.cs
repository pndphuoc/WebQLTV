using QuanLyThuVIen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLTV.DataLayer.SQLServer
{
    public class SachDAL : _BaseDAL, ICommonDAL<Sach>
    {
        public SachDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Sach data)
        {
            int result = 0;
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"insert into Sach (TenSach, MaNhaXuatBan, MaNgonNgu,SoLuong,
                                    NamXuatBan,DonGia,SoTaiBan,TinhTrang,Anh,MaLoaiSach,SoLuongCon)
                                    values(@TenSach, @MaNhaXuatBan, @MaNgonNgu,@SoLuong,
                                    @NamXuatBan,@DonGia,@SoTaiBan,@TinhTrang,@Anh,@MaLoaiSach,@SoLuongCon)
                                   select @@identity;";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("TenSach", data.TenSach);
                cmd.Parameters.AddWithValue("MaNhaXuatBan", data.MaNhaXuatBan);
                cmd.Parameters.AddWithValue("MaNgonNgu", data.MaNgonNgu);
                cmd.Parameters.AddWithValue("SoLuong", data.SoLuong);
                cmd.Parameters.AddWithValue("NamXuatBan", data.NamXuatBan);
                cmd.Parameters.AddWithValue("DonGia", data.DonGia);
                cmd.Parameters.AddWithValue("SoTaiBan", data.SoTaiBan);
                cmd.Parameters.AddWithValue("TinhTrang", data.TinhTrang);
                cmd.Parameters.AddWithValue("MaLoaiSach", data.MaLoaiSach);
                cmd.Parameters.AddWithValue("SoLuongCon", data.SoLuongCon);
                cmd.Parameters.AddWithValue("Anh", data.Anh);

                result = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            return result;
        }

        public int Count(string searchValue = "")
        {
            int count = 0;

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select count(*)
                                    from Sach
                                    where (@searchValue = N'')
                                        or(TEnSach like @searchValue)";
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

        public Sach Get(int id)
        {
            Sach data = null;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Sach where MaSach = @MaSach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("MaSach", id);

                var dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (dbReader.Read())
                {
                    data = new Sach()
                    {
                        TenSach = Convert.ToString(dbReader["TenSach"]),
                        DonGia = Convert.ToInt32(dbReader["DonGia"]),
                        Anh = Convert.ToString(dbReader["Anh"]),
                        MaLoaiSach = Convert.ToInt32(dbReader["MaLoaiSach"]),
                        MaNgonNgu = Convert.ToInt32(dbReader["MaNgonNgu"]),
                        MaNhaXuatBan = Convert.ToInt32(dbReader["MaNhaXuatBan"]),
                        MaSach = Convert.ToInt32(dbReader["MaSach"]),
                        NamXuatBan = Convert.ToInt32(dbReader["NamXuatBan"]),
                        SoLuong = Convert.ToInt32(dbReader["SoLuong"]),
                        SoTaiBan = Convert.ToInt32(dbReader["SoTaiBan"]),
                        TinhTrang = Convert.ToBoolean(dbReader["TinhTrang"]),
                        SoLuongCon = Convert.ToInt32(dbReader["SoLuongCon"])
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
        public IList<Sach> List()
        {
            List<Sach> data = new List<Sach>();

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from Sach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;


                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new Sach()
                    {
                        TenSach = Convert.ToString(result["TenSach"]),
                        DonGia = Convert.ToInt32(result["DonGia"]),
                        Anh = Convert.ToString(result["Anh"]),
                        MaLoaiSach = Convert.ToInt32(result["MaLoaiSach"]),
                        MaNgonNgu = Convert.ToInt32(result["MaNgonNgau"]),
                        MaNhaXuatBan = Convert.ToInt32(result["MaNhaXuatBan"]),
                        MaSach = Convert.ToInt32(result["MaSach"]),
                        NamXuatBan = Convert.ToInt32(result["NamXuatBan"]),
                        SoLuong = Convert.ToInt32(result["SoLuong"]),
                        SoTaiBan = Convert.ToInt32(result["SoTaiBan"]),
                        TinhTrang = Convert.ToBoolean(result["TinhTrang"]),
                        SoLuongCon = Convert.ToInt32(result["SoLuongCon"])
                    });
                }
                cn.Close();
            }
            return data;
        }
        public IList<Sach> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Sach> data = new List<Sach>();

            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"select *
                                    from
                                        (
                                            select *,
                                                    row_number() over(order by TenSach) as RowNumber
                                            from Sach
                                            where (@searchValue = N'')
                                                or(TenSach like @searchValue)
                                        ) as t
                                    where (@pageSize) = 0 or (t.RowNumber between(@page -1) *@pageSize + 1 and @page *@pageSize)
                                    order by t.RowNumber; ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                var result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (result.Read())
                {
                    data.Add(new Sach()
                    {
                        TenSach = Convert.ToString(result["TenSach"]),
                        DonGia = Convert.ToInt32(result["DonGia"]),
                        Anh = Convert.ToString(result["Anh"]),
                        MaLoaiSach = Convert.ToInt32(result["MaLoaiSach"]),
                        MaNgonNgu = Convert.ToInt32(result["MaNgonNgu"]),
                        MaNhaXuatBan = Convert.ToInt32(result["MaNhaXuatBan"]),
                        MaSach = Convert.ToInt32(result["MaSach"]),
                        NamXuatBan = Convert.ToInt32(result["NamXuatBan"]),
                        SoLuong = Convert.ToInt32(result["SoLuong"]),
                        SoTaiBan = Convert.ToInt32(result["SoTaiBan"]),
                        TinhTrang = Convert.ToBoolean(result["TinhTrang"]),
                        SoLuongCon = Convert.ToInt32(result["SoLuongCon"])
                    });
                }
                cn.Close();
            }
            return data;
        }

        public bool Update(Sach data)
        {

            bool result = false;

            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"update Sach
                    set 
                                        TenSach = @TenSach, MaNhaXuatBan = @MaNhaXuatBan, MaNgonNgu = @MaNgonNgu,SoLuong = @SoLuong,
                                        NamXuatBan = @NamXuatBan,DonGia = @DonGia,SoTaiBan = @SoTaiBan,TinhTrang = @TinhTrang,
                                        Anh = @Anh,MaLoaiSach = @MaLoaiSach,SoLuongCon = @SoLuongCon
                    where MaSach = @MaSach";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("TenSach", data.TenSach);
                cmd.Parameters.AddWithValue("MaNhaXuatBan", data.MaNhaXuatBan);
                cmd.Parameters.AddWithValue("MaNgonNgu", data.MaNgonNgu);
                cmd.Parameters.AddWithValue("SoLuong", data.SoLuong);
                cmd.Parameters.AddWithValue("NamXuatBan", data.NamXuatBan);
                cmd.Parameters.AddWithValue("DonGia", data.DonGia);
                cmd.Parameters.AddWithValue("SoTaiBan", data.SoTaiBan);
                cmd.Parameters.AddWithValue("TinhTrang", data.TinhTrang);
                cmd.Parameters.AddWithValue("Anh", data.Anh);
                cmd.Parameters.AddWithValue("MaLoaiSach", data.MaLoaiSach);
                cmd.Parameters.AddWithValue("SoLuongCon", data.SoLuongCon);

                result = cmd.ExecuteNonQuery() > 0;

                cn.Close();
            }

            return result;
        }
    }
}
