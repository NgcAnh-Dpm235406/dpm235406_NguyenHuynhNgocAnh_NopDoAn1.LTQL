using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmTaiKhoan : Form
    {
        string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLKS2;Integrated Security=True";
        bool isTenTKValid = false;
        bool isMatKhauValid = false;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                // Không nên SELECT mật khẩu nếu muốn bảo mật, hoặc chỉ hiện dấu *
                SqlDataAdapter da = new SqlDataAdapter("SELECT TenTK, LoaiTK, MaNV FROM TaiKhoan", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTaiKhoan.DataSource = dt;
            }
        }
        void HienThiDS()
        {
            dgvTaiKhoan.DataSource = TaiKhoan_BUS.LayDanhSachTaiKhoan();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên tài khoản và Mật khẩu!");
                return;
            }

            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                
                string checkQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @ten";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@ten", txtTenTK.Text);
                int count = (int)checkCmd.ExecuteScalar();

                string query = "";
                if (count == 0)
                    query = "INSERT INTO TaiKhoan (TenTK, MatKhau, LoaiTK) VALUES (@ten, @mk, @loai)";
                else
                    query = "UPDATE TaiKhoan SET MatKhau=@mk, LoaiTK=@loai WHERE TenTK=@ten";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ten", txtTenTK.Text);
                cmd.Parameters.AddWithValue("@mk", txtMatKhau.Text);  
                cmd.Parameters.AddWithValue("@loai", cboQuyen.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật tài khoản!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    string query = "DELETE FROM TaiKhoan WHERE TenTK=@ten";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ten", txtTenTK.Text);
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtTenTK.Clear();
            txtMatKhau.Clear();

            
            if (cboQuyen.Items.Count > 0)
                cboQuyen.SelectedIndex = 0; 

            if (cboNhanVien.Items.Count > 0)
                cboNhanVien.SelectedIndex = -1; 

            
            txtTenTK.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            txtTenTK.Clear();
            txtMatKhau.Clear();

            
            if (cboQuyen.Items.Count > 0)
                cboQuyen.SelectedIndex = 0; 

            if (cboNhanVien.Items.Count > 0)
                cboNhanVien.SelectedIndex = -1; 

            
            txtTenTK.Focus();

            HienThiDS();
            btnThem_Click(sender, e);
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiDS();
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTaiKhoan.SelectedRows[0];
                txtTenTK.Text = row.Cells["STenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["SMatKhau"].Value.ToString();
                cboQuyen.Text = row.Cells["SLoaiTaiKhoan"].Value.ToString();
            }
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenTK.Text) && !txtTenTK.Text.Contains(" "))
            {
                isTenTKValid = true;
                txtTenTK.BackColor = Color.White;
            }
            else
            {
                isTenTKValid = false;
                txtTenTK.BackColor = Color.MistyRose;
            }
            KiemTraBatNutLuu();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length >= 6)
            {
                isMatKhauValid = true;
                txtMatKhau.BackColor = Color.White;
            }
            else
            {
                isMatKhauValid = false;
                txtMatKhau.BackColor = Color.MistyRose;
            }
            KiemTraBatNutLuu();
        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraBatNutLuu();
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedIndex != -1)
            {
                KiemTraBatNutLuu();
            }
        }
        private void KiemTraBatNutLuu()
        {
            
            bool isNhanVienSelected = cboNhanVien.SelectedIndex != -1;

            
            btnLuu.Enabled = isTenTKValid && isMatKhauValid && isNhanVienSelected;
        }
    }
}
