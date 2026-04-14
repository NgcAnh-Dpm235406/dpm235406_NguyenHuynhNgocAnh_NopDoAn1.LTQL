using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoaDon : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=Quan_Ly_Khach_San;Integrated Security=True";
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                // Giả sử bạn có một stored procedure hoặc query kết hợp bảng SuDungDichVu và DichVu
                string query = @"SELECT SUM(dv.DonGia * sd.SoLuong) 
                         FROM SuDungDichVu sd JOIN DichVu dv ON sd.MaDV = dv.MaDV 
                         WHERE sd.MaPhong = @maPhong AND sd.TrangThai = 'Chưa thanh toán'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@maPhong", cboPhong.SelectedValue);

                object ketQua = cmd.ExecuteScalar();
                decimal tienDV = (ketQua != DBNull.Value) ? Convert.ToDecimal(ketQua) : 0;

                // Giả sử tiền phòng cố định hoặc lấy từ bảng Phong
                decimal tienPhong = 500000; // Ví dụ 500k

                txtTongTien.Text = (tienDV + tienPhong).ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                string query = "INSERT INTO HoaDon (NgayLap, TongTien, MaPhong) VALUES (@ngay, @tong, @maPhong)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ngay", dtpNgayLap.Value);
                cmd.Parameters.AddWithValue("@tong", Convert.ToDecimal(txtTongTien.Text));
                cmd.Parameters.AddWithValue("@maPhong", cboPhong.SelectedValue);

                cmd.ExecuteNonQuery();

                // Cập nhật trạng thái phòng thành 'Trống' sau khi thanh toán
                string updatePhong = "UPDATE Phong SET TrangThai = N'Trống' WHERE MaPhong = @maPhong";
                SqlCommand cmdUpdate = new SqlCommand(updatePhong, con);
                cmdUpdate.Parameters.AddWithValue("@maPhong", cboPhong.SelectedValue);
                cmdUpdate.ExecuteNonQuery();

                MessageBox.Show("Thanh toán thành công!");
                LoadAllHoaDon();
                LoadComboBoxPhong(); // Refresh danh sách phòng trống
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxPhong();
            LoadAllHoaDon();
        }

        void LoadComboBoxPhong()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhong, TenPhong FROM Phong WHERE TrangThai = N'Có khách'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboPhong.DataSource = dt;
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "MaPhong";
            }
        }

        void LoadAllHoaDon()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoaDon", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHoaDon.DataSource = dt;
            }
        }

        
    }
}
