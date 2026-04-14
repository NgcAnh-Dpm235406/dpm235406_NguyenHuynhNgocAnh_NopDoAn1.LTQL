using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class Phong_DAO
    {
        static SqlConnection con;

        public static List<Phong_DTO> LayDanhSachPhong()
        {
            // 1. Câu truy vấn JOIN để lấy dữ liệu từ cả 2 bảng Phong (p) và LoaiPhong (l)
            string s = @"SELECT p.MaPhong, p.TenPhong, p.MaLoai, p.TrangThai, 
                        l.GiaNgay, l.GiaGio, l.SoNgay, l.SoGio 
                 FROM Phong p 
                 INNER JOIN LoaiPhong l ON p.MaLoai = l.MaLoai";

            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            if (dt == null || dt.Rows.Count == 0)
            {
                if (con != null) DataProvider.DongKetNoi(con);
                return new List<Phong_DTO>();
            }

            List<Phong_DTO> list = new List<Phong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Phong_DTO p = new Phong_DTO();

                // Dữ liệu từ bảng Phong
                p.IMaPhong = int.Parse(dt.Rows[i]["MaPhong"].ToString());
                p.STenPhong = dt.Rows[i]["TenPhong"].ToString();
                p.IMaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                p.STrangThai = dt.Rows[i]["TrangThai"].ToString();

                // Dữ liệu từ bảng LoaiPhong (Các cột bạn vừa yêu cầu)
                // Lưu ý: Ép kiểu decimal cho tiền và int cho số lượng
                p.DGiaNgay = decimal.Parse(dt.Rows[i]["GiaNgay"].ToString());
                p.DGiaGio = decimal.Parse(dt.Rows[i]["GiaGio"].ToString());
                p.ISoNgay = int.Parse(dt.Rows[i]["SoNgay"].ToString());

                p.ISoGio = int.Parse(dt.Rows[i]["SoGio"].ToString());

                list.Add(p);
            }

            DataProvider.DongKetNoi(con);
            return list;
        }

        public static bool ThemPhong(Phong_DTO p)
        {
            string s = string.Format("INSERT INTO Phong(TenPhong, MaLoai, TrangThai) VALUES (N'{0}', {1}, N'{2}')",
                                      p.STenPhong, p.IMaLoai, p.STrangThai);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool SuaPhong(Phong_DTO p)
        {
            string s = string.Format("UPDATE Phong SET TenPhong=N'{0}', MaLoai={1}, TrangThai=N'{2}' WHERE MaPhong={3}",
                                      p.STenPhong, p.IMaLoai, p.STrangThai, p.IMaPhong);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        public static bool XoaPhong(int ma)
        {
            string s = string.Format("DELETE FROM Phong WHERE MaPhong={0}", ma);
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }

        // Thực hiện cập nhật trạng thái phòng (Trống, Có khách, Sửa chữa...)
        public static bool CapNhatTrangThai(int maPhong, string trangThaiMoi)
        {
            // Câu lệnh SQL cập nhật cột TrangThai dựa trên MaPhong
            string sTruyVan = string.Format("UPDATE Phong SET TrangThai = N'{0}' WHERE MaPhong = {1}", trangThaiMoi, maPhong);

            SqlConnection con = DataProvider.MoKetNoi(); // Mở kết nối
            try
            {
                // Gọi hàm thực thi không trả về dữ liệu từ DataProvider
                bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
                return kq;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                // Luôn luôn đóng kết nối để tránh quá tải Database
                DataProvider.DongKetNoi(con);
            }
        }

        //From tổng quan
        // Trong file PhongDAO.cs
        // Sửa trong PhongDAO.cs
        public static DataTable LayDanhSachPhongTongQuan()
        {
            // Câu truy vấn này sẽ lấy TẤT CẢ các phòng (Phong p)
            // Nếu có phiếu thuê chưa thanh toán thì mới hiện HoTen và NgayCheckOutDuKien
            string sTruyVan = @"
        SELECT 
            p.MaPhong, 
            p.TenPhong, 
            lp.TenLoai, 
            kh.HoTen, 
            pt.NgayCheckOutDuKien, 
            p.TrangThai
        FROM Phong p
        LEFT JOIN LoaiPhong lp ON p.MaLoai = lp.MaLoai
        LEFT JOIN PhieuThue pt ON p.MaPhong = pt.MaPhong AND pt.TrangThai = N'Chưa thanh toán'
        LEFT JOIN KhachHang kh ON pt.MaKH = kh.MaKH
        ORDER BY p.MaPhong ASC";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }
    }
}