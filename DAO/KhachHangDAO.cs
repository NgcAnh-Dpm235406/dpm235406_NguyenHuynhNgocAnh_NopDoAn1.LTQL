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

        // Thêm hàm này vào trong lớp KhachHang_DAO
        public static bool SuaKhachHang(KhachHang_DTO kh)
        {
            string sTruyVan = string.Format("UPDATE KhachHang SET HoTen = N'{0}', CCCD = '{1}', SDT = '{2}', DiaChi = N'{3}', QuocTich = N'{4}' WHERE MaKH = {5}",
                kh.SHoTen, kh.SCCCD, kh.SSDT, kh.SDiaChi, kh.SQuocTich, kh.IMaKH);

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaKhachHang(int maKH)
        {
            try
            {
                // Câu lệnh SQL xóa dựa trên mã khách hàng
                string sTruyVan = string.Format("DELETE FROM KhachHang WHERE MaKH = {0}", maKH);

                // Mở kết nối
                SqlConnection con = DataProvider.MoKetNoi();

                // Thực thi truy vấn không lấy dữ liệu (Trả về true nếu thành công)
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);

                // Đóng kết nối
                DataProvider.DongKetNoi(con);

                return kq;
            }
            catch (Exception)
            {
                // Nếu có lỗi (ví dụ: khách hàng đang có hóa đơn, không thể xóa vì ràng buộc khóa ngoại)
                return false;
            }
        }
    }
}