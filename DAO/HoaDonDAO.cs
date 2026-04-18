using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DAO
{
    public class HoaDon_DAO
    {
        static SqlConnection con;

        /// <summary>
        /// Lấy tất cả danh sách hóa đơn kèm Tên KH và Tên Phòng
        /// </summary>
        public static List<HoaDon_DTO> LayHoaDon()
        {
            // JOIN để lấy HoTen từ bảng KhachHang và TenPhong từ bảng Phong
            string sTruyVan = @"SELECT hd.*, kh.HoTen, p.TenPhong 
                                FROM HoaDon hd
                                JOIN PhieuThue pt ON hd.MaPhieu = pt.MaPhieu
                                JOIN KhachHang kh ON pt.MaKH = kh.MaKH
                                JOIN Phong p ON pt.MaPhong = p.MaPhong";

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);

            if (dt == null || dt.Rows.Count == 0) return new List<HoaDon_DTO>();

            List<HoaDon_DTO> lstHD = new List<HoaDon_DTO>();
            foreach (DataRow dr in dt.Rows)
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.IMaHD = int.Parse(dr["MaHD"].ToString());
                hd.IMaPhieu = int.Parse(dr["MaPhieu"].ToString());
                

                // Gán dữ liệu chữ từ câu lệnh JOIN
                hd.SHoTen = dr["HoTen"].ToString();
                hd.STenPhong = dr["TenPhong"].ToString();

                hd.DtNgayThanhToan = DateTime.Parse(dr["NgayThanhToan"].ToString());
                hd.DTongTienPhong = decimal.Parse(dr["TongTienPhong"].ToString());
                hd.DTongTienDV = decimal.Parse(dr["TongTienDV"].ToString());
                hd.DTongTienThanhToan = decimal.Parse(dr["TongTienThanhToan"].ToString());

                lstHD.Add(hd);
            }
            DataProvider.DongKetNoi(con);
            return lstHD;
        }

        /// <summary>
        /// Lọc danh sách hóa đơn theo ngày (Dùng cho chức năng Tìm kiếm/Lọc)
        /// </summary>
        // Thêm tham số string tenKH vào đây
        public static DataTable LayDSHoaDon(DateTime tuNgay, DateTime denNgay, string tenKH)
        {
            string sql = @"SELECT hd.MaHD, p.TenPhong, kh.HoTen, hd.NgayThanhToan, 
                          hd.TongTienPhong, hd.TongTienDV, hd.TongTienThanhToan
                   FROM HoaDon hd
                   JOIN PhieuThue pt ON hd.MaPhieu = pt.MaPhieu
                   JOIN KhachHang kh ON pt.MaKH = kh.MaKH
                   JOIN Phong p ON pt.MaPhong = p.MaPhong
                   WHERE (hd.NgayThanhToan BETWEEN @tu AND @den)";

            // Nếu có từ khóa tìm kiếm khác rỗng thì thêm điều kiện (accent-insensitive, case-insensitive)
            bool hasKeyword = !string.IsNullOrWhiteSpace(tenKH);
            if (hasKeyword)
            {
                sql += " AND kh.HoTen COLLATE Latin1_General_CI_AI LIKE @ten";
            }

            SqlConnection con = DataProvider.MoKetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tu", SqlDbType.DateTime).Value = tuNgay.Date;
                cmd.Parameters.Add("@den", SqlDbType.DateTime).Value = denNgay.Date.AddDays(1).AddSeconds(-1);

                if (hasKeyword)
                {
                    // Dùng NVarChar (Unicode) và truyền tham số với wildcard
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 200).Value = "%" + tenKH.Trim() + "%";
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            finally
            {
                DataProvider.DongKetNoi(con);
            }
        }
        public static DataTable TimKiemHoaDon(string giaTri)
        {
            string sTruyVan = string.Format("SELECT * FROM HoaDon WHERE MaHD LIKE '%{0}%' OR MaKH LIKE '%{0}%'", giaTri);
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        /// <summary>
        /// Lưu hóa đơn mới
        /// </summary>
        public static bool LuuHoaDon(HoaDon_DTO hd)
        {
            // Loại bỏ {4} vì đã dùng GETDATE() trực tiếp trong SQL
            string sTruyVan = string.Format(
                "INSERT INTO HoaDon (MaPhieu, TongTienPhong, TongTienDV, TongTienThanhToan, NgayThanhToan) " +
                "VALUES ({0}, {1}, {2}, {3}, GETDATE())",
                hd.IMaPhieu, hd.DTongTienPhong, hd.DTongTienDV, hd.DTongTienThanhToan);

            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XuLyThanhToan(string maHD, string maPhong)
        {
            // Cập nhật trạng thái hóa đơn thành 'Đã thanh toán' và Phòng thành 'Trống'
            string sql = string.Format(@"UPDATE HoaDon SET TrangThai = N'Đã thanh toán' WHERE MaHD = '{0}';
                                 UPDATE Phong SET TrangThai = N'Trống' WHERE MaPhong = '{1}';", maHD, maPhong);
            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }


        public static DataTable LayPhieuThueChuaCoHoaDon()
        {
            string sql = @"SELECT pt.MaPhieu, p.TenPhong, kh.HoTen
               FROM PhieuThue pt
               INNER JOIN Phong p ON pt.MaPhong = p.MaPhong
               INNER JOIN KhachHang kh ON pt.MaKH = kh.MaKH
               WHERE pt.TrangThai = N'Chưa thanh toán'
                 AND NOT EXISTS (SELECT 1 FROM HoaDon hd WHERE hd.MaPhieu = pt.MaPhieu)";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }



        /// <summary>
        /// Xóa hóa đơn theo mã
        /// </summary>
        public static bool XoaHoaDon(int maHD)
        {
            string sql = string.Format("DELETE FROM HoaDon WHERE MaHD = {0}", maHD);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sql, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
    }
}