using DAO;
using DTO;
using System.Collections.Generic;
using System.Data; // Thêm để dùng DataTable nếu cần

namespace BUS
{
    public class KhachHang_BUS
    {
        // Hàm lấy danh sách trả về List DTO (Dùng cho logic)
        public List<KhachHang_DTO> LayTatCaKhachHang()
        {
            return KhachHang_DAO.LayKhachHang();
        }

        // Hàm kiểm tra trung CCCD
        public bool KiemTraTrungCCCD(string cccd)
        {
            List<KhachHang_DTO> ds = KhachHang_DAO.LayKhachHang();
            return ds != null && ds.Exists(x => x.SCCCD == cccd);
        }

        public bool ThemKhachHang(KhachHang_DTO kh)
        {
            // Tận dụng hàm kiểm tra trùng đã viết ở trên
            if (KiemTraTrungCCCD(kh.SCCCD)) return false;

            return KhachHang_DAO.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            return KhachHang_DAO.SuaKhachHang(kh);
        }

        // QUAN TRỌNG: Bỏ 'static' để tránh lỗi gạch đỏ ở GUI
        public bool XoaKhachHang(int maKH)
        {
            return KhachHang_DAO.XoaKhachHang(maKH);
        }

        public List<KhachHang_DTO> TimKiemKhachHang(string tuKhoa)
        {
            List<KhachHang_DTO> ds = KhachHang_DAO.LayKhachHang();
            if (ds == null) return new List<KhachHang_DTO>();

            return ds.FindAll(kh => kh.SHoTen.ToLower().Contains(tuKhoa.ToLower()) ||
                                   kh.SCCCD.Contains(tuKhoa));
        }
    }
}