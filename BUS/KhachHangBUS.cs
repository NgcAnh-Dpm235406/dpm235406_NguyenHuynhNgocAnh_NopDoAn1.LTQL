using DTO;
using DAO;
using System.Collections.Generic;

namespace BUS
{
    public class KhachHang_BUS
    {
        private KhachHang_DAO daoKH = new KhachHang_DAO();

        public List<KhachHang_DTO> LayTatCaKhachHang()
        {
            return daoKH.GetListKhachHang();
        }

        public bool ThemKhachHang(KhachHang_DTO kh)
        {
            // Logic: Kiểm tra nếu khách hàng đã tồn tại qua số CCCD
            List<KhachHang_DTO> ds = daoKH.GetListKhachHang();
            foreach (var item in ds)
            {
                if (item.SCCCD == kh.SCCCD) return false; // Trùng CCCD không cho thêm
            }
            return daoKH.InsertKhachHang(kh);
        }

        public bool SuaKhachHang(KhachHang_DTO kh)
        {
            return daoKH.UpdateKhachHang(kh);
        }

        public List<KhachHang_DTO> TimKiemKhachHang(string tuKhoa)
        {
            return daoKH.GetListKhachHang().FindAll(kh => kh.SHoTen.ToLower().Contains(tuKhoa.ToLower()) || kh.SCCCD.Contains(tuKhoa));
        }
    }
}