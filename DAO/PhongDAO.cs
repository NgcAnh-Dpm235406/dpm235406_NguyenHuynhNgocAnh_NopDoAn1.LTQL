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
            string s = @"SELECT p.MaPhong, p.TenPhong, p.MaLoai, p.TrangThai,
                        l.GiaNgay, l.GiaGio, p.SoNgay, p.SoGio
                 FROM Phong p
                 INNER JOIN LoaiPhong l ON p.MaLoai = l.MaLoai";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(s, con);

            List<Phong_DTO> list = new List<Phong_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Phong_DTO p = new Phong_DTO();
                p.IMaPhong = int.Parse(dt.Rows[i]["MaPhong"].ToString());
                p.STenPhong = dt.Rows[i]["TenPhong"].ToString();
                p.IMaLoai = int.Parse(dt.Rows[i]["MaLoai"].ToString());
                p.STrangThai = dt.Rows[i]["TrangThai"].ToString();
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
            string s = @"INSERT INTO Phong(TenPhong, MaLoai, TrangThai, SoNgay, SoGio, TongTien)
                 VALUES (N'" + p.STenPhong + "', " + p.IMaLoai + ", N'" + p.STrangThai + "', " +
                         p.ISoNgay + ", " + p.ISoGio + ", " + p.DTongTien + ")";

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(s, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }



        public static bool SuaPhong(Phong_DTO p)
        {
            // Bỏ GiaNgay và GiaGio vì bảng Phong không có 2 cột này (nó nằm ở bảng LoaiPhong)
            // Cập nhật TenPhong, MaLoai, TrangThai, SoNgay, SoGio và TongTien
            string s = @"UPDATE Phong 
                 SET TenPhong = N'" + p.STenPhong +
                         "', MaLoai = " + p.IMaLoai +
                         ", TrangThai = N'" + p.STrangThai +
                         "', SoNgay = " + p.ISoNgay +
                         ", SoGio = " + p.ISoGio +
                         ", TongTien = " + p.DTongTien +
                         " WHERE MaPhong = " + p.IMaPhong;

            SqlConnection con = DataProvider.MoKetNoi();
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
        // Thêm vào file Phong_DAO.cs
        public static DataTable LayPhongTrongTheoLoai(int maLoai)
        {
            // Truy vấn lấy các phòng theo loại và phải đang TRỐNG
            string sTruyVan = string.Format(@"SELECT MaPhong, TenPhong 
                                     FROM Phong 
                                     WHERE MaLoai = {0} AND TrangThai LIKE N'%Trống%'", maLoai);

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            return dt;
        }

        public static DataTable LayTatCaTenPhongTrong()
        {
            // Truy vấn lấy tất cả tên phòng và mã phòng
            string sTruyVan = "SELECT MaPhong, TenPhong FROM Phong WHERE TrangThai = N'Trống'";

            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            return dt;
        }

        public static bool CapNhatTrangThaiPhong(int maPhong, string trangThaiMoi)
        {
            string sTruyVan = string.Format("UPDATE Phong SET TrangThai = N'{0}' WHERE MaPhong = {1}",
                                            trangThaiMoi, maPhong);

            SqlConnection con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);

            return kq;
        }

        public static bool KiemTraTenPhongTonTai(string tenPhong)
        {
            string sql = "SELECT COUNT(*) FROM Phong WHERE TenPhong = @TenPhong";
            SqlConnection con = DataProvider.MoKetNoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TenPhong", tenPhong);

            object result = cmd.ExecuteScalar(); // trả về số lượng
            int count = Convert.ToInt32(result);

            DataProvider.DongKetNoi(con);
            return count > 0;
        }




    }
}