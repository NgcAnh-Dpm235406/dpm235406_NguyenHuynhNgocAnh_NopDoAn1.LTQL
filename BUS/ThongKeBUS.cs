using DTO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKe_BUS
    {
        private Phong_DAO daoPhong = new Phong_DAO();
        private HoaDon_DAO daoHD = new HoaDon_DAO();

        // Lấy số lượng phòng đang trống để hiển thị lên nhãn (Label) ở trang chủ
        public int LaySoPhongTrong()
        {
            // Logic: Duyệt danh sách phòng từ DAO và đếm phòng có trạng thái 'Trống'
            return daoPhong.LayDanhSachPhong().FindAll(p => p.STrangThai == "Trống").Count;
        }

        // Tính doanh thu sơ bộ trong ngày
        public decimal TinhDoanhThuTrongNgay()
        {
            // Gọi DAO lấy danh sách hóa đơn và cộng tổng tiền
            return daoHD.LayDoanhThuNgay();
        }
    }
}
