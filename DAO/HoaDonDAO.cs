using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class HoaDon_DAO
    {
        static SqlConnection con;

        // Lấy danh sách hóa đơn
        public static List<HoaDon_DTO> LayHoaDon()
        {
            string sTruyVan = "SELECT * FROM HoaDon";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return null;

            List<HoaDon_DTO> lstHD = new List<HoaDon_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.IMaHD = int.Parse(dt.Rows[i]["MaHD"].ToString());
                hd.IMaPhieu = int.Parse(dt.Rows[i]["MaPhieu"].ToString());
                hd.IMaTK_NguoiLap = int.Parse(dt.Rows[i]["MaTK_NguoiLap"].ToString());
                hd.DtNgayThanhToan = DateTime.Parse(dt.Rows[i]["NgayThanhToan"].ToString());
                hd.DTongTienPhong = decimal.Parse(dt.Rows[i]["TongTienPhong"].ToString());
                hd.DTongTienDV = decimal.Parse(dt.Rows[i]["TongTienDV"].ToString());
                hd.DTongTienThanhToan = decimal.Parse(dt.Rows[i]["TongTienThanhToan"].ToString());

                lstHD.Add(hd);
            }
            DataProvider.DongKetNoi(con);
            return lstHD;
        }

        // Lưu hóa đơn khi thanh toán
        public static bool LuuHoaDon(HoaDon_DTO hd)
        {
            string sTruyVan = string.Format("INSERT INTO HoaDon (MaPhieu, MaTK_NguoiLap, TongTienPhong, TongTienDV, TongTienThanhToan) VALUES ({0}, {1}, {2}, {3}, {4})",
                hd.IMaPhieu, hd.IMaTK_NguoiLap, hd.DTongTienPhong, hd.DTongTienDV, hd.DTongTienThanhToan);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}