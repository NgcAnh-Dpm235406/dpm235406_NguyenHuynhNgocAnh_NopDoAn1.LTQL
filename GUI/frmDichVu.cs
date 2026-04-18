using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmDichVu : Form
    {
        bool isMaValid = false;
        bool isTenValid = false;
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLKS2;Integrated Security=True";
        SqlConnection sqlCon = null;
        public frmDichVu()
        {
            InitializeComponent();
        } 
        void LoadData()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM DichVu", sqlCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvDichVu.DataSource = dt;
        }
        private void frmDichVu_Load(object sender, EventArgs e)
                {
                    LoadData();
                }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

            string query = "INSERT INTO DichVu (TenDV, DonGia, DonViTinh) VALUES (@ten, @gia, @dvt)";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.Parameters.AddWithValue("@ten", txtTenDV.Text);
            cmd.Parameters.AddWithValue("@gia", numDonGia.Value);
            cmd.Parameters.AddWithValue("@dvt", txtDonViTinh.Text);

            int kq = cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
            txtMaDV.Clear();
            txtTenDV.Clear();
            numDonGia.Value = 0;
            txtDonViTinh.Clear();
            txtTenDV.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string query = "DELETE FROM DichVu WHERE MaDV=@ma";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ma", txtMaDV.Text);
                    cmd.ExecuteNonQuery();
                    LoadData();
                    btnThem_Click(null, null); // Xóa trắng ô nhập sau khi xóa dưới DB
                }
            }
        }
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtMaDV.Text = dgvDichVu.Rows[i].Cells[0].Value.ToString();
                txtTenDV.Text = dgvDichVu.Rows[i].Cells[1].Value.ToString();
                numDonGia.Value = Convert.ToDecimal(dgvDichVu.Rows[i].Cells[2].Value);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!");
                return;
            }

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                string query = "";

                if (string.IsNullOrEmpty(txtMaDV.Text)) 
                    query = "INSERT INTO DichVu VALUES (@ten, @gia, @dvt)";
                else 
                    query = "UPDATE DichVu SET TenDV=@ten, DonGia=@gia, DonViTinh=@dvt WHERE MaDV=@ma";

                SqlCommand cmd = new SqlCommand(query, con);
                if (!string.IsNullOrEmpty(txtMaDV.Text)) cmd.Parameters.AddWithValue("@ma", txtMaDV.Text);
                cmd.Parameters.AddWithValue("@ten", txtTenDV.Text);
                cmd.Parameters.AddWithValue("@gia", numDonGia.Value);
                cmd.Parameters.AddWithValue("@dvt", txtDonViTinh.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thông tin!");
                LoadData();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "SELECT * FROM DichVu WHERE TenDV LIKE @ten";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@ten", "%" + txtTimKiem.Text + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvDichVu.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            txtMaDV.Clear();
            txtTenDV.Clear();
            numDonGia.Value = 0;
            txtDonViTinh.Clear();
            txtTimKiem.Clear();
            LoadData();
            txtTenDV.Focus();
            MessageBox.Show("Đã hủy thao tác nhập liệu.", "Thông báo");
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDV.Text) || txtMaDV.Text.Length > 10)
            {
                txtMaDV.BackColor = Color.LightPink; // Báo hiệu lỗi nhập liệu
                isMaValid = false;
            }
            else
            {
                txtMaDV.BackColor = Color.White;
                isMaValid = true;
            }
            KiemTraBatNutLuu();
        }

        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            if (numDonGia.Value < 0)
            {
                numDonGia.Value = 0;
            }
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                isTenValid = false;
            }
            else
            {
                isTenValid = true;
            }
            KiemTraBatNutLuu();
        }

        private void txtDonViTinh_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                
                if (txtDonViTinh.Text.Length > 20)
                {
                    txtDonViTinh.Text = txtDonViTinh.Text.Substring(0, 20);
                    txtDonViTinh.SelectionStart = txtDonViTinh.Text.Length;
                }
            }

            
            KiemTraBatNutLuu();
        }
        private void KiemTraBatNutLuu()
        {
            bool isDonViValid = !string.IsNullOrWhiteSpace(txtDonViTinh.Text);
            btnLuu.Enabled = isMaValid && isTenValid && isDonViValid;
        }
    }
}
