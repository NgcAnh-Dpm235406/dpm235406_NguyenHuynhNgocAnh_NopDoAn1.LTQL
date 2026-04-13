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
    }
}