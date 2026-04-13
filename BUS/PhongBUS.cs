using DAO;
using DTO;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class Phong_BUS
    {
        // Vì trong DAO dùng hàm static, nên không cần khởi tạo đối tượng daoPhong nữa

        public List<Phong_DTO> LayDanhSachPhong()
        {
            // Gọi đúng tên hàm trong Phong_DAO
            return Phong_DAO.LayDanhSachPhong();
        }

        public bool CapNhatTrangThaiPhong(int maPhong, string trangThaiMoi)
        {
            // Gọi đúng tên hàm trong Phong_DAO
            return Phong_DAO.CapNhatTrangThai(maPhong, trangThaiMoi);
        }

        public List<Phong_DTO> LocPhongTheoLoai(int maLoai)
        {
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null) return null;
            return ds.FindAll(p => p.IMaLoai == maLoai);
        }

        // 2. Thêm phòng mới (Kiểm tra tên trùng)
        public bool ThemPhong(Phong_DTO phong)
        {
            if (string.IsNullOrEmpty(phong.STenPhong)) return false;

            // Kiểm tra trùng tên phòng ở đây
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds != null && ds.Exists(p => p.STenPhong == phong.STenPhong)) return false;

            return Phong_DAO.ThemPhong(phong); // Bạn cần viết hàm này trong DAO
        }

        // 3. Sửa thông tin phòng
        public bool SuaPhong(Phong_DTO phong)
        {
            return Phong_DAO.SuaPhong(phong); // Bạn cần viết hàm này trong DAO
        }

        // 4. Xóa phòng
        public bool XoaPhong(int maPhong)
        {
            return Phong_DAO.XoaPhong(maPhong); // Bạn cần viết hàm này trong DAO
        }


        // Hàm lấy danh sách phòng kèm thông tin khách hàng đang ở để hiện lên lưới
        public DataTable LayDanhSachPhongTongQuan()
        {
            // Bạn cần viết hàm này trong Phong_DAO để thực hiện câu lệnh SQL Join
            // (Join các bảng: Phong, LoaiPhong, PhieuThue, KhachHang)
            return Phong_DAO.LayDanhSachPhongTongQuan();
        }

        // Hàm đếm số lượng phòng theo từng trạng thái để hiện lên các ô màu
        public int DemPhongTheoTrangThai(string trangThai)
        {
            List<Phong_DTO> ds = Phong_DAO.LayDanhSachPhong();
            if (ds == null) return 0;
            return ds.FindAll(p => p.STrangThai == trangThai).Count;
        }
    }
}