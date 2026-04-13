using DTO;
using DAO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class HoaDon_BUS
    {
        private HoaDon_DAO daoHD = new HoaDon_DAO();

        public List<HoaDon_DTO> LayDanhSachHoaDon()
        {
            return daoHD.GetListHoaDon();
        }

        // Logic quan trọng: Tính toán tổng tiền thanh toán cuối cùng
        public decimal TinhTongThanhToan(decimal tienPhong, decimal tienDV)
        {
            return tienPhong + tienDV;
        }

        public bool LuuHoaDon(HoaDon_DTO hd)
        {
            // Logic: Gán ngày thanh toán là ngày hiện tại trước khi lưu
            hd.DtNgayThanhToan = DateTime.Now;

            if (hd.DTongTienThanhToan <= 0) return false; // Không cho lưu hóa đơn 0 đồng

            return daoHD.InsertHoaDon(hd);
        }

        public decimal LayDoanhThuTheoThang(int thang, int nam)
        {
            decimal tong = 0;
            List<HoaDon_DTO> ds = daoHD.GetListHoaDon();
            foreach (var hd in ds)
            {
                if (hd.DtNgayThanhToan.Month == thang && hd.DtNgayThanhToan.Year == nam)
                {
                    tong += hd.DTongTienThanhToan;
                }
            }
            return tong;
        }
    }
}