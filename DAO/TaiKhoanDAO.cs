using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        // Kiểm tra thông tin đăng nhập
        public static TaiKhoan_DTO KiemTraDangNhap(string tenTK, string matKhau)
        {
            // Truy vấn tìm tài khoản khớp tên và mật khẩu
            string sTruyVan = string.Format("SELECT * FROM TaiKhoan WHERE TenTK = '{0}' AND MatKhau = '{1}'", tenTK, matKhau);

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt != null && dt.Rows.Count > 0)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.STenDangNhap = dt.Rows[0]["TenTaiKhoan"].ToString();
                tk.SMatKhau = dt.Rows[0]["MatKhau"].ToString();
                tk.ILoaiTaiKhoan = int.Parse(dt.Rows[0]["LoaiTaiKhoan"].ToString());

                DataProvider.DongKetNoi(con);
                return tk;
            }

            DataProvider.DongKetNoi(con);
            return null;
        }

        // Lấy danh sách tài khoản (dành cho quản lý nhân viên)
        public static List<TaiKhoan_DTO> LayDanhSachTaiKhoan()
        {
            string sTruyVan = "SELECT * FROM TaiKhoan";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null) return null;

            List<TaiKhoan_DTO> lstTK = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.STenDangNhap = dt.Rows[i]["TenTaiKhoan"].ToString();
                tk.ILoaiTaiKhoan = int.Parse(dt.Rows[i]["LoaiTaiKhoan"].ToString());
                lstTK.Add(tk);
            }
            DataProvider.DongKetNoi(con);
            return lstTK;
        }

        // Đổi mật khẩu
        public static bool DoiMatKhau(string tenTK, string matKhauMoi)
        {
            string sTruyVan = string.Format("UPDATE TaiKhoan SET MatKhau = '{0}' WHERE TenTK = '{1}'", matKhauMoi, tenTK);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}