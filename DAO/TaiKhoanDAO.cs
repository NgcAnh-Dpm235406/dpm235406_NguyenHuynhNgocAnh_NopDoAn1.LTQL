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
                tk.SMatKhau = dr["MatKhau"].ToString();
                lstTK.Add(tk);
            }
            DataProvider.DongKetNoi(con);
            return lstTK;
        }
        // Trong TaiKhoan_DAO.cs
        public static bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            string s = string.Format("INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan, TrangThai) VALUES ('{0}', '{1}', N'{2}', '{3}', 1)",
                        tk.STenDangNhap, tk.SMatKhau, tk.SHoTen, tk.SLoaiTaiKhoan);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaTaiKhoan(TaiKhoan_DTO tk)
        {
            string s = string.Format("UPDATE TaiKhoan SET MatKhau='{0}', HoTen=N'{1}', LoaiTaiKhoan='{2}' WHERE MaTK={3}",
                        tk.SMatKhau, tk.SHoTen, tk.SLoaiTaiKhoan, tk.IMaTK);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaTaiKhoan(string tenTK)
        {
            string s = string.Format("DELETE FROM TaiKhoan WHERE TenDangNhap = '{0}'", tenTK);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        // Thêm hàm này vào class TaiKhoan_DAO
        public static TaiKhoan_DTO KiemTraDangNhap(string tenTK, string matKhau)
        {
            // Truy vấn tìm tài khoản khớp user/pass và đang hoạt động (TrangThai = 1)
            string s = string.Format("SELECT * FROM TaiKhoan WHERE TenDangNhap = '{0}' AND MatKhau = '{1}' AND TrangThai = 1", tenTK, matKhau);

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Nếu tìm thấy, đóng gói dữ liệu vào DTO để trả về
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.IMaTK = int.Parse(dt.Rows[0]["MaTK"].ToString());
                tk.STenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
                tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
                tk.SHoTen = dt.Rows[0]["HoTen"].ToString();
                tk.SLoaiTaiKhoan = dt.Rows[0]["LoaiTaiKhoan"].ToString();

                DataProvider.DongKetNoi(con);
                return tk;
            }

            DataProvider.DongKetNoi(con);
            return null; // Không tìm thấy tài khoản
        }

       
        
    }
}