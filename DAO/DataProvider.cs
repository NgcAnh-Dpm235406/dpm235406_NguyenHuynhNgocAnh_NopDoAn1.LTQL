using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        static string strCon = @"Server=.\SQLEXPRESS;Database=QLKS2;Integrated Security=True;TrustServerCertificate=True;";
        public static SqlConnection MoKetNoi()
        {
            SqlConnection KetNoi = new SqlConnection(strCon);
            KetNoi.Open();
            return KetNoi;
        }

        public static void DongKetNoi(SqlConnection KetNoi)
        {
            if (KetNoi != null && KetNoi.State == ConnectionState.Open)
            {
                KetNoi.Close();
            }
        }
        // Thực hiện truy vấn trả về bảng dữ liệu
        public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection
        KetNoi)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, KetNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Thực hiện truy vấn không trả về dữ liệu
        public static bool TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection
        KetNoi)
        {
            try
            {
                SqlCommand cm = new SqlCommand(sTruyVan, KetNoi);
                cm.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
            return false;
            }
        }
    }
}
