using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DichVu_DAO
    {
        public static List<DichVu_DTO> LayDanhSachDichVu()
        {
            string s = @"SELECT d.MaDV, d.TenDV, d.GiaDV, d.DonViTinh, d.MaPhong, p.TenPhong
                     FROM DichVu d
                     LEFT JOIN Phong p ON d.MaPhong = p.MaPhong";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            List<DichVu_DTO> list = new List<DichVu_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                DichVu_DTO dv = new DichVu_DTO();
                dv.IMaDV = int.Parse(row["MaDV"].ToString());
                dv.STenDV = row["TenDV"].ToString();
                dv.DGiaDV = decimal.Parse(row["GiaDV"].ToString());
                dv.SDonViTinh = row["DonViTinh"].ToString();
                dv.IMaPhong = row["MaPhong"] == DBNull.Value ? 0 : int.Parse(row["MaPhong"].ToString());
                dv.STenPhong = row["TenPhong"].ToString();
                list.Add(dv);
            }
            DataProvider.DongKetNoi(con);
            return list;
        }

        public static bool ThemDichVu(DichVu_DTO dv)
        {
            string s = string.Format(@"INSERT INTO DichVu(TenDV, GiaDV, DonViTinh, MaPhong)
                                   VALUES (N'{0}', {1}, N'{2}', {3})",
                                       dv.STenDV, dv.DGiaDV, dv.SDonViTinh, dv.IMaPhong);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaDichVu(DichVu_DTO dv)
        {
            string s = string.Format(@"UPDATE DichVu 
                                   SET TenDV=N'{0}', GiaDV={1}, DonViTinh=N'{2}', MaPhong={3}
                                   WHERE MaDV={4}",
                                       dv.STenDV, dv.DGiaDV, dv.SDonViTinh, dv.IMaPhong, dv.IMaDV);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaDichVu(int maDV)
        {
            string s = string.Format(@"DELETE FROM DichVu WHERE MaDV={0}", maDV);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }


        public static List<string> LayDanhSachDonViTinh()
        {
            // Lấy duy nhất các đơn vị tính, sắp xếp theo bảng chữ cái
            string s = "SELECT DISTINCT DonViTinh FROM DichVu WHERE DonViTinh IS NOT NULL AND DonViTinh <> '' ORDER BY DonViTinh ASC";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["DonViTinh"].ToString());
            }

            DataProvider.DongKetNoi(con);
            return list;
        }
    }
}
