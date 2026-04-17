using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace BUS
{
    public class HoaDon_BUS
    {
        // Vì trong DAO các hàm là 'public static', bạn không cần dòng:
        // private HoaDon_DAO daoHD = new HoaDon_DAO();
        // Hãy gọi trực tiếp qua tên lớp HoaDon_DAO.

        public List<HoaDon_DTO> LayDanhSachHoaDon()
        {
            // Gọi đúng hàm static từ DAO
            return HoaDon_DAO.LayHoaDon();
        }
        public static DataTable TimKiem(string giaTri) => HoaDon_DAO.TimKiemHoaDon(giaTri);

        public decimal TinhTongThanhToan(decimal tienPhong, decimal tienDV)
        {
            return tienPhong + tienDV;
        }

        public bool LuuHoaDon(HoaDon_DTO hd)
        {
            // Gán ngày thanh toán là hiện tại trước khi lưu
            hd.DtNgayThanhToan = DateTime.Now;

            if (hd.DTongTienThanhToan <= 0) return false;

            // Gọi đúng hàm static LuuHoaDon từ DAO
            return HoaDon_DAO.LuuHoaDon(hd);
        }

        public decimal LayDoanhThuTheoThang(int thang, int nam)
        {
            decimal tong = 0;
            List<HoaDon_DTO> ds = HoaDon_DAO.LayHoaDon();

            if (ds != null)
            {
                foreach (var hd in ds)
                {
                    // Kiểm tra khớp tháng và năm
                    if (hd.DtNgayThanhToan.Month == thang && hd.DtNgayThanhToan.Year == nam)
                    {
                        tong += hd.DTongTienThanhToan;
                    }
                }
            }
            return tong;
        }

        public decimal TinhTongDoanhThuTatCa()
        {
            decimal tong = 0;
            List<HoaDon_DTO> ds = HoaDon_DAO.LayHoaDon();
            if (ds != null)
            {
                foreach (var hd in ds)
                {
                    tong += hd.DTongTienThanhToan;
                }
            }
            return tong;
        }

        public DataTable LayDanhSachHoaDon(DateTime tu, DateTime den, string hoTen)
        {
            return HoaDon_DAO.LayDSHoaDon(tu, den, hoTen);
        }

        public bool XoaHoaDon(int maHD)
        {
            return HoaDon_DAO.XoaHoaDon(maHD);
        }

        
    }
}