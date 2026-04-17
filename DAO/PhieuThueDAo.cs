using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class PhieuThue_DAO
    {
        // 1. Thêm phiếu thuê mới (Dùng khi khách Check-in)
        public static bool ThemPhieuThue(PhieuThue_DTO pt)
        {
            string sTruyVan = string.Format(@"INSERT INTO PhieuThue (MaPhong, MaKH, NgayCheckIn, NgayCheckOutDuKien, TrangThai) 
                VALUES ({0}, {1}, '{2}', '{3}', N'Chưa thanh toán')",
                pt.IMaPhong, pt.IMaKH, pt.DtNgayCheckIn.ToString("yyyy-MM-dd HH:mm:ss"), pt.DtNgayCheckOutDuKien.ToString("yyyy-MM-dd HH:mm:ss"));

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // 2. Lấy phiếu thuê chưa thanh toán theo Mã Phòng (Dùng để lấy thông tin tính tiền)
        public static PhieuThue_DTO LayPhieuChuaThanhToan(int maPhong)
        {
            string sTruyVan = string.Format("SELECT * FROM PhieuThue WHERE MaPhong = {0} AND TrangThai = N'Chưa thanh toán'", maPhong);
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            if (dt == null || dt.Rows.Count == 0) return null;

            DataRow dr = dt.Rows[0];
            return new PhieuThue_DTO
            {
                IMaPhieu = (int)dr["MaPhieu"],
                IMaPhong = (int)dr["MaPhong"],
                IMaKH = (int)dr["MaKH"],
                DtNgayCheckIn = (DateTime)dr["NgayCheckIn"],
                DtNgayCheckOutDuKien = (DateTime)dr["NgayCheckOutDuKien"],
                STrangThai = dr["TrangThai"].ToString()
            };
        }

        // 3. Cập nhật trạng thái phiếu (Dùng sau khi thanh toán xong)
        public static bool CapNhatTrangThai(int maPhieu, string trangThaiMoi)
        {
            string sTruyVan = string.Format("UPDATE PhieuThue SET TrangThai = N'{0}' WHERE MaPhieu = {1}", trangThaiMoi, maPhieu);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static (decimal tienPhong, decimal tienDV, decimal tong) TinhTienTheoPhieu(int maPhieu)
        {
            string sql = @"SELECT 
                      ISNULL(pt.TongTienPhong,0) AS TienPhong,
                      ISNULL(pt.TongTienDV,0) AS TienDV
                   FROM PhieuThue pt
                   WHERE pt.MaPhieu = @maPhieu";

            using (SqlConnection con = DataProvider.MoKetNoi())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@maPhieu", maPhieu);

                SqlDataReader reader = cmd.ExecuteReader();
                decimal tienPhong = 0, tienDV = 0;
                if (reader.Read())
                {
                    tienPhong = Convert.ToDecimal(reader["TienPhong"]);
                    tienDV = Convert.ToDecimal(reader["TienDV"]);
                }
                reader.Close();
                DataProvider.DongKetNoi(con);

                return (tienPhong, tienDV, tienPhong + tienDV);
            }
        }

    }
} 