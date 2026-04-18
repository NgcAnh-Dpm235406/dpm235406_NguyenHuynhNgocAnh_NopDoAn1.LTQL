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

        public (decimal tongPhong, decimal tongDV, decimal tongThanhToan) TinhTongTheoKhach(string hoTen)
        {
            DataTable dt = HoaDon_DAO.LayDSHoaDon(new DateTime(1753, 1, 1), new DateTime(9998, 12, 31), hoTen);
            decimal tongPhong = 0, tongDV = 0, tongThanhToan = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal phong = 0, dv = 0, tt = 0;
                decimal.TryParse(row["TongTienPhong"]?.ToString(), out phong);
                decimal.TryParse(row["TongTienDV"]?.ToString(), out dv);
                decimal.TryParse(row["TongTienThanhToan"]?.ToString(), out tt);

                tongPhong += phong;
                tongDV += dv;
                tongThanhToan += tt;
            }

            return (tongPhong, tongDV, tongThanhToan);
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

        public DataTable LayPhieuThueChuaCoHoaDon()
        {
            return HoaDon_DAO.LayPhieuThueChuaCoHoaDon();
        }
        public (decimal tienPhong, decimal tienDV, decimal tong) TinhTienTheoPhieu(int maPhieu)
        {
            return PhieuThue_DAO.TinhTienTheoPhieu(maPhieu);
        }

    }
}