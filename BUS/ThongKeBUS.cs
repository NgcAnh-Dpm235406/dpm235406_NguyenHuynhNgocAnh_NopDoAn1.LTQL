using DTO;
using DAO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class ThongKe_BUS
    {
        // Vì Phong_DAO và HoaDon_DAO dùng hàm static, bạn không cần (và không nên)
        // khởi tạo: private Phong_DAO daoPhong = new Phong_DAO();
        // Hãy xóa các dòng khởi tạo đối tượng cũ.

        // 1. Lấy số lượng phòng đang trống
        public int LaySoPhongTrong()
        {
            // Gọi đúng hàm LayDanhSachPhong() từ lớp static Phong_DAO
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null) return 0;

            // Tìm các phòng có trạng thái là "Trống"
            return ds.FindAll(p => p.STrangThai == "Trống").Count;
        }

        // 2. Tính doanh thu sơ bộ trong ngày
        public decimal TinhDoanhThuTrongNgay()
        {
            decimal tong = 0;
            // Gọi đúng hàm LayHoaDon() từ lớp static HoaDon_DAO
            List<HoaDon_DTO> ds = HoaDon_DAO.LayHoaDon();

            if (ds != null)
            {
                DateTime homNay = DateTime.Now;
                foreach (var hd in ds)
                {
                    // So sánh ngày thanh toán với ngày hôm nay
                    if (hd.DtNgayThanhToan.Date == homNay.Date)
                    {
                        tong += hd.DTongTienThanhToan;
                    }
                }
            }
            return tong;
        }
    }
}