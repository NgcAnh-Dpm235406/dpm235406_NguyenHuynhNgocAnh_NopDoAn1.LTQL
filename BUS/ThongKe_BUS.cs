using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BUS
{
    /// <summary>
    /// Lớp thống kê: gom các phép tính báo cáo dùng bởi UI
    /// - Không truy vấn trực tiếp SQL ở đây, chỉ gọi DAO và xử lý bằng LINQ / DataTable trả về
    /// - An toàn với null, kiểu trả về rõ ràng
    /// </summary>
    public class ThongKe_BUS
    {
        /// <summary>
        /// Đếm số phòng theo trạng thái (ví dụ "Trống", "Có khách", ...)
        /// Trả về 0 nếu không lấy được danh sách phòng
        /// </summary>
        public int DemPhongTheoTrangThai(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai)) return 0;

            var ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null || ds.Count == 0) return 0;

            return ds.Count(p => !string.IsNullOrEmpty(p.STrangThai)
                                 && p.STrangThai.Equals(trangThai, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Đếm phòng trống
        /// </summary>
        public int DemPhongTrong()
        {
            return DemPhongTheoTrangThai("Trống");
        }

        /// <summary>
        /// Tổng doanh thu trong ngày hôm nay (theo ngày hệ thống)
        /// Sử dụng DtNgayThanhToan.Date để so sánh ngày
        /// </summary>
        public decimal TinhDoanhThuTrongNgay()
        {
            var ds = HoaDon_DAO.LayHoaDon();
            if (ds == null || ds.Count == 0) return 0m;

            var today = DateTime.Today;
            return ds
                .Where(hd => hd != null && hd.DtNgayThanhToan.Date == today)
                .Sum(hd => hd.DTongTienThanhToan);
        }

        /// <summary>
        /// Tổng doanh thu theo tháng và năm (ví dụ thang=4, nam=2026)
        /// </summary>
        public decimal TinhDoanhThuTheoThang(int thang, int nam)
        {
            var ds = HoaDon_DAO.LayHoaDon();
            if (ds == null || ds.Count == 0) return 0m;

            return ds
                .Where(hd => hd != null && hd.DtNgayThanhToan.Month == thang && hd.DtNgayThanhToan.Year == nam)
                .Sum(hd => hd.DTongTienThanhToan);
        }

        /// <summary>
        /// Tổng doanh thu tất cả thời điểm
        /// </summary>
        public decimal TinhTongDoanhThuTatCa()
        {
            var ds = HoaDon_DAO.LayHoaDon();
            if (ds == null || ds.Count == 0) return 0m;

            return ds.Sum(hd => hd.DTongTienThanhToan);
        }

        /// <summary>
        /// Lấy DataTable các hóa đơn theo khoảng ngày và tên khách (dùng cho hiển thị/filter)
        /// Trả trực tiếp DataTable từ DAO (DAO.LayDSHoaDon đã có)
        /// </summary>
        public DataTable LayThongKeTheoKhoangNgay(DateTime tu, DateTime den, string tenKH = "")
        {
            // Bảo đảm ngày hợp lệ (điền giá trị tối đa/nhiều nhất nếu không truyền)
            DateTime from = tu.Date;
            DateTime to = den.Date;
            return HoaDon_DAO.LayDSHoaDon(from, to, tenKH ?? string.Empty);
        }

        /// <summary>
        /// Trả về danh sách cặp (Tên phòng, Tổng doanh thu) sắp xếp giảm dần theo doanh thu.
        /// Useful để hiển thị "top rooms".
        /// </summary>
        public List<KeyValuePair<string, decimal>> TopPhongTheoDoanhThu(int topN = 5)
        {
            var ds = HoaDon_DAO.LayHoaDon();
            var result = new List<KeyValuePair<string, decimal>>();

            if (ds == null || ds.Count == 0) return result;

            var grouped = ds
                .Where(hd => hd != null && !string.IsNullOrEmpty(hd.STenPhong))
                .GroupBy(hd => hd.STenPhong)
                .Select(g => new
                {
                    TenPhong = g.Key,
                    Tong = g.Sum(h => h.DTongTienThanhToan)
                })
                .OrderByDescending(x => x.Tong)
                .Take(Math.Max(0, topN));

            result.AddRange(grouped.Select(g => new KeyValuePair<string, decimal>(g.TenPhong, g.Tong)));
            return result;
        }
    }
}