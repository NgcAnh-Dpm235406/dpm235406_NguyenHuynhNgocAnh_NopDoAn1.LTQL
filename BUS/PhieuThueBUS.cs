using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class PhieuThue_BUS
    {
        // Nghiệp vụ thuê phòng
        public bool ThuePhong(PhieuThue_DTO pt)
        {
            // Kiểm tra nếu mã phòng hoặc mã khách không hợp lệ
            if (pt.IMaPhong <= 0 || pt.IMaKH <= 0) return false;

            // Gọi DAO để lưu
            return PhieuThue_DAO.ThemPhieuThue(pt);
        }

        // Lấy phiếu thuê đang hoạt động của một phòng
        public PhieuThue_DTO TimPhieuTheoMaPhong(int maPhong)
        {
            return PhieuThue_DAO.LayPhieuChuaThanhToan(maPhong);
        }

        // Hoàn tất phiếu thuê (đổi sang trạng thái Đã thanh toán)
        public bool HoanTatPhieuThue(int maPhieu)
        {
            return PhieuThue_DAO.CapNhatTrangThai(maPhieu, "Đã thanh toán");
        }
    }
}