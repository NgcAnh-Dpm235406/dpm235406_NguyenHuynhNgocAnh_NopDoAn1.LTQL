using DTO;
using DAO;
using System.Collections.Generic;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        private TaiKhoan_DAO daoTK = new TaiKhoan_DAO();

        // Kiểm tra quyền Admin để ẩn/hiện menu
        public bool LaAdmin(TaiKhoan_DTO tk)
        {
            if (tk == null) return false;
            return tk.SLoaiTaiKhoan == "Admin";
        }

        // Có thể thêm hàm đổi mật khẩu hoặc cập nhật trạng thái nếu cần
    }
}