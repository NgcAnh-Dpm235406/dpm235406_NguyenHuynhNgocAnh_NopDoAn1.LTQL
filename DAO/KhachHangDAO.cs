using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class KhachHang_DAO
    {
        static SqlConnection con;

        // Lấy danh sách khách hàng
        public static List<KhachHang_DTO> LayKhachHang()
        {
            string sTruyVan = "SELECT * FROM KhachHang";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<KhachHang_DTO> lstKH = new List<KhachHang_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang_DTO kh = new KhachHang_DTO();
                kh.IMaKH = int.Parse(dt.Rows[i]["MaKH"].ToString());
                kh.SHoTen = dt.Rows[i]["HoTen"].ToString();
                kh.SCCCD = dt.Rows[i]["CCCD"].ToString();
                kh.SSDT = dt.Rows[i]["SDT"].ToString();
                kh.SDiaChi = dt.Rows[i]["DiaChi"].ToString();
                kh.SQuocTich = dt.Rows[i]["QuocTich"].ToString();
                lstKH.Add(kh);
            }
            DataProvider.DongKetNoi(con);
            return lstKH;
        }

        // Thêm khách hàng mới
        public static bool ThemKhachHang(KhachHang_DTO kh)
        {
            string sTruyVan = string.Format("INSERT INTO KhachHang (HoTen, CCCD, SDT, DiaChi, QuocTich) VALUES (N'{0}', '{1}', '{2}', N'{3}', N'{4}')",
                kh.SHoTen, kh.SCCCD, kh.SSDT, kh.SDiaChi, kh.SQuocTich);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}