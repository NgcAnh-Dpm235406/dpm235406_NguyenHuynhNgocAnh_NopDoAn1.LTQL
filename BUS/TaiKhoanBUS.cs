using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static List<TaiKhoan_DTO> LayDanhSachTaiKhoan()
        {
            return TaiKhoan_DAO.LayDanhSachTaiKhoan();
        }

        public static bool Them(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.ThemTaiKhoan(tk);
        }

        public static bool Sua(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.SuaTaiKhoan(tk);
        }

        public static bool Xoa(string tenTK)
        {
            return TaiKhoan_DAO.XoaTaiKhoan(tenTK);
        }

        // Thêm hàm này vào class TaiKhoan_BUS
        public TaiKhoan_DTO KiemTraDangNhap(string tenTK, string matKhau)
        {
            // Kiểm tra nghiệp vụ đơn giản: không được để trống
            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                return null;
            }

            // Gọi xuống DAO để lấy kết quả
            return TaiKhoan_DAO.KiemTraDangNhap(tenTK, matKhau);
        }
    }
}