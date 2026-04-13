using DTO;
using DAO;
using System.Collections.Generic;

namespace BUS
{
    public class KhachHang_BUS
    {
        // Vì trong DAO dùng hàm static, bạn nên gọi trực tiếp qua tên lớp KhachHang_DAO
        // thay vì dùng biến daoKH.

        public List<KhachHang_DTO> LayTatCaKhachHang()
        {
            // Đổi từ GetListKhachHang() thành LayKhachHang() cho khớp với DAO
            return KhachHang_DAO.LayKhachHang();
        }

        public bool ThemKhachHang(KhachHang_DTO kh)
        {
            // Logic: Kiểm tra nếu khách hàng đã tồn tại qua số CCCD
            List<KhachHang_DTO> ds = KhachHang_DAO.LayKhachHang();
            if (ds != null)
            {
                foreach (var item in ds)
                {
                    if (item.SCCCD == kh.SCCCD) return false; // Trùng CCCD không cho thêm
                }
            }

            // Đổi từ InsertKhachHang(kh) thành ThemKhachHang(kh) cho khớp với DAO
            return KhachHang_DAO.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            // Đảm bảo bạn đã viết hàm SuaKhachHang (hoặc UpdateKhachHang) bên DAO
            return KhachHang_DAO.SuaKhachHang(kh);
        }

        public List<KhachHang_DTO> TimKiemKhachHang(string tuKhoa)
        {
            List<KhachHang_DTO> ds = KhachHang_DAO.LayKhachHang();
            if (ds == null) return new List<KhachHang_DTO>();

            return ds.FindAll(kh => kh.SHoTen.ToLower().Contains(tuKhoa.ToLower()) || kh.SCCCD.Contains(tuKhoa));
        }
    }
}