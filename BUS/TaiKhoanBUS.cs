using DAO;
using DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class TaiKhoan_BUS
    {

        // Trong file TaiKhoan_DAO.cs
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
                tk.IMaTK = int.Parse(dt.Rows[i]["MaTK"].ToString());
                tk.STenDangNhap = dt.Rows[i]["TenDangNhap"].ToString();
                tk.SHoTen = dt.Rows[i]["HoTen"].ToString();
                tk.SLoaiTaiKhoan = dt.Rows[i]["LoaiTaiKhoan"].ToString();
                // Không nên lấy mật khẩu khi đổ vào danh sách quản lý

                lstTK.Add(tk);
            }
            DataProvider.DongKetNoi(con);
            return lstTK;
        }
        // Vì TaiKhoan_DAO dùng các hàm static, bạn có thể gọi trực tiếp qua tên lớp
        // Hoặc giữ nguyên khai báo này nếu muốn dùng theo thực thể:
        private TaiKhoan_DAO daoTK = new TaiKhoan_DAO();

        // 1. Hàm kiểm tra đăng nhập (Kết nối GUI và DAO)
        public TaiKhoan_DTO KiemTraDangNhap(string tenTK, string matKhau)
        {
            // Kiểm tra nghiệp vụ cơ bản trước khi gọi xuống DAO
            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                return null;
            }

            // Gọi hàm KiemTraDangNhap từ TaiKhoan_DAO
            return TaiKhoan_DAO.KiemTraDangNhap(tenTK, matKhau);
        }

        // 2. Kiểm tra quyền Admin để ẩn/hiện menu (Dành cho frmMain)
        public bool LaAdmin(TaiKhoan_DTO tk)
        {
            if (tk == null) return false;

            // Lưu ý: Kiểm tra xem trong DTO bạn đặt là SLoaiTaiKhoan (String) 
            // hay ILoaiTaiKhoan (Int). 
            // Nếu là Int: return tk.ILoaiTaiKhoan == 1; (với 1 là Admin)
            return tk.SLoaiTaiKhoan == "Admin";
        }

        // 3. Hàm lấy danh sách (nếu sau này bạn làm trang quản lý nhân viên)
        public List<TaiKhoan_DTO> LayDSTaiKhoan()
        {
            return TaiKhoan_DAO.LayDanhSachTaiKhoan();
        }
    }
}