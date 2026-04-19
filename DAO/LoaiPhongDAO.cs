using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class LoaiPhong_DAO
    {
        // Lấy toàn bộ bảng Loại Phòng để đổ vào ComboBox
        public static DataTable LayDSLoaiPhong()
        {
            string sTruyVan = "SELECT * FROM LoaiPhong";
            SqlConnection con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return dt;
        }

        public static LoaiPhong_DTO LayLoaiPhongTheoMa(int maLoai)
        {
            string sql = "SELECT MaLoai, TenLoai, GiaNgay, GiaGio FROM LoaiPhong WHERE MaLoai = " + maLoai;
            SqlConnection con = DataProvider.MoKetNoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            LoaiPhong_DTO loaiPhong = null;
            if (reader.Read())
            {
                loaiPhong = new LoaiPhong_DTO();
                loaiPhong.IMaLoai = (int)reader["MaLoai"];
                loaiPhong.STenLoai = reader["TenLoai"].ToString();
                loaiPhong.DGiaNgay = (decimal)reader["GiaNgay"];
                loaiPhong.DGiaGio = (decimal)reader["GiaGio"];
            }

            reader.Close();
            DataProvider.DongKetNoi(con);
            return loaiPhong;
        }

    }
}