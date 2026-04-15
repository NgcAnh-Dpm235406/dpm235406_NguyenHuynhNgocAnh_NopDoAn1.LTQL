using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class TaiKhoan_DAO
    {

        // Trong file TaiKhoan_DAO.cs
        public static List<TaiKhoan_DTO> LayDanhSachTaiKhoan()
        {
            // Truy vấn lấy tất cả tài khoản từ bảng TaiKhoan
            string sTruyVan = "SELECT * FROM TaiKhoan";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null) return null;

            List<TaiKhoan_DTO> lstTK = new List<TaiKhoan_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.IMaTK = int.Parse(dr["MaTK"].ToString());
                tk.STenDangNhap = dr["TenDangNhap"].ToString();
                tk.SHoTen = dr["HoTen"].ToString();
                tk.SLoaiTaiKhoan = dr["LoaiTaiKhoan"].ToString();
                // Không lấy mật khẩu đổ lên danh sách để bảo mật
                lstTK.Add(tk);
            }
            DataProvider.DongKetNoi(con);
            return lstTK;
        }
        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format("INSERT INTO TaiKhoan VALUES ('{0}', '{1}', '{2}')", tk.STenDangNhap, tk.SMatKhau, tk.SLoaiTaiKhoan);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTaiKhoan(string tenTK)
        {
            string sTruyVan = string.Format("DELETE FROM TaiKhoan WHERE TenDangNhap = '{0}'", tenTK);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTaiKhoan(TaiKhoan_DTO tk)
        {
            string sTruyVan = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}', LoaiTaiKhoan = '{1}' WHERE TenDangNhap = '{2}'",
                                            tk.SMatKhau, tk.SLoaiTaiKhoan, tk.STenDangNhap);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static TaiKhoan_DTO KiemTraDangNhap(string tenTK, string matKhau)
        {
            // Tên cột phải khớp: TenDangNhap, MatKhau
            string s = string.Format("SELECT * FROM TaiKhoan WHERE TenDangNhap = '{0}' AND MatKhau = '{1}' AND TrangThai = 1", tenTK, matKhau);

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            if (dt != null && dt.Rows.Count > 0)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.IMaTK = int.Parse(dt.Rows[0]["MaTK"].ToString());
                tk.STenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
                tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
                tk.SHoTen = dt.Rows[0]["HoTen"].ToString();
                tk.SLoaiTaiKhoan = dt.Rows[0]["LoaiTaiKhoan"].ToString(); // Khớp với hình

                DataProvider.DongKetNoi(con);
                return tk;
            }

            DataProvider.DongKetNoi(con);
            return null;
        }
    }
}