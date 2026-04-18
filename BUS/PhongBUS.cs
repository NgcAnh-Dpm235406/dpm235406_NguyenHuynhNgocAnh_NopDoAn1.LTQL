using DAO;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class Phong_BUS
    {
        // 1. Lấy danh sách phòng
        public static List<Phong_DTO> LayDanhSachPhong()
        {
            return Phong_DAO.LayDanhSachPhong();
        }

        // 2. Cập nhật trạng thái phòng
        public static bool CapNhatTrangThaiPhong(int maPhong, string trangThaiMoi)
        {
            return Phong_DAO.CapNhatTrangThai(maPhong, trangThaiMoi);
        }

        // 3. Lọc phòng theo loại
        public static List<Phong_DTO> LocPhongTheoLoai(int maLoai)
        {
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null) return null;
            return ds.FindAll(p => p.IMaLoai == maLoai);
        }

        // 4. Thêm phòng mới (kiểm tra tên trùng)
        public static bool ThemPhong(Phong_DTO phong)
        {
            if (string.IsNullOrEmpty(phong.STenPhong)) return false;

            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds != null && ds.Exists(p => p.STenPhong == phong.STenPhong)) return false;

            return Phong_DAO.ThemPhong(phong);
        }

        // 5. Sửa thông tin phòng
        public static bool SuaPhong(Phong_DTO phong)
        {
            return Phong_DAO.SuaPhong(phong);
        }

        // 6. Xóa phòng
        public static bool XoaPhong(int maPhong)
        {
            return Phong_DAO.XoaPhong(maPhong);
        }

        // 7. Đếm số lượng phòng theo trạng thái
        public static int DemPhongTheoTrangThai(string trangThai)
        {
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null) return 0;
            return ds.FindAll(p => p.STrangThai == trangThai).Count;
        }

        // 8. Lấy phòng trống theo loại
        public static DataTable LayPhongTrongTheoLoai(int maLoai)
        {
            return Phong_DAO.LayPhongTrongTheoLoai(maLoai);
        }

        // 9. Lấy tất cả phòng trống
        public static DataTable LayTatCaPhongTrong()
        {
            return Phong_DAO.LayTatCaTenPhongTrong();
        }
    }
}
