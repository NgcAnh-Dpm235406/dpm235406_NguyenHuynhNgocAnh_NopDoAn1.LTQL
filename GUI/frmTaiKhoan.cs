using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiDS();
            LamMoi();
        }

        // Hàm tải dữ liệu lên GridView
        void HienThiDS()
        {
            dgvTaiKhoan.DataSource = TaiKhoan_BUS.LayDanhSachTaiKhoan();

            // Định dạng tiêu đề cột cho đẹp
            if (dgvTaiKhoan.Columns.Count > 0)
            {
                dgvTaiKhoan.Columns["IMaTK"].HeaderText = "Mã TK";
                dgvTaiKhoan.Columns["STenDangNhap"].HeaderText = "Tên Đăng Nhập";
                dgvTaiKhoan.Columns["SHoTen"].HeaderText = "Họ Tên";
                dgvTaiKhoan.Columns["SLoaiTaiKhoan"].HeaderText = "Loại TK";
                dgvTaiKhoan.Columns["SMatKhau"].HeaderText = "Mật khẩu";
            }
        }

        // 1. Chức năng Làm mới (Reset các ô nhập liệu)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaTK.ResetText();
            txtTenTK.ResetText();
            txtMatKhau.ResetText(); // Ô Mật khẩu trong Designer của bạn
            txtHoTen.ResetText();
            cboLoaiTK.SelectedIndex = 0;
            txtTenTK.Enabled = true; // Cho phép nhập lại tên TK khi thêm mới
        }
        // --- 1. CHỨC NĂNG THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên TK và Mật khẩu!");
                return;
            }

            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.STenDangNhap = txtTenTK.Text;
            tk.SMatKhau = txtMatKhau.Text; // txtCCCD là ô mật khẩu trong Designer của bạn
            tk.SHoTen = txtHoTen.Text;
            tk.SLoaiTaiKhoan = cboLoaiTK.Text;

            if (TaiKhoan_BUS.Them(tk))
            {
                MessageBox.Show("Thêm thành công!");
                HienThiDS();
                btnLamMoi_Click(null, null);
            }
            else MessageBox.Show("Thêm thất bại (Tên TK có thể đã tồn tại)!");
        }

        // --- 2. CHỨC NĂNG SỬA ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa từ danh sách!");
                return;
            }

            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.IMaTK = int.Parse(txtMaTK.Text);
            tk.STenDangNhap = txtTenTK.Text;
            tk.SMatKhau = txtMatKhau.Text;
            tk.SHoTen = txtHoTen.Text;
            tk.SLoaiTaiKhoan = cboLoaiTK.Text;

            if (TaiKhoan_BUS.Sua(tk))
            {
                MessageBox.Show("Cập nhật thành công!");
                HienThiDS();
            }
            else MessageBox.Show("Cập nhật thất bại!");
        }

        // 2. Chức năng Lưu (Dùng cho cả Thêm và Sửa)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrEmpty(txtTenTK.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!");
                return;
            }

            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.STenDangNhap = txtTenTK.Text;
            tk.SMatKhau = txtMatKhau.Text;
            tk.SHoTen = txtHoTen.Text;
            tk.SLoaiTaiKhoan = cboLoaiTK.Text;

            // Nếu txtMaTK trống -> Thêm mới, nếu có -> Sửa
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                if (TaiKhoan_BUS.Them(tk))
                {
                    MessageBox.Show("Thêm mới thành công!");
                }
                else MessageBox.Show("Thêm mới thất bại!");
            }
            else
            {
                tk.IMaTK = int.Parse(txtMaTK.Text);
                if (TaiKhoan_BUS.Sua(tk))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else MessageBox.Show("Cập nhật thất bại!");
            }

            HienThiDS();
            LamMoi();
        }

        // 3. Chức năng Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text)) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (TaiKhoan_BUS.Xoa(txtTenTK.Text))
                {
                    MessageBox.Show("Đã xóa thành công!");
                    HienThiDS();
                    LamMoi();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        // Sự kiện Click vào dòng trên DataGridView để lấy dữ liệu lên các ô
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvTaiKhoan.Rows[e.RowIndex];
                txtMaTK.Text = r.Cells["IMaTK"].Value.ToString();
                txtTenTK.Text = r.Cells["STenDangNhap"].Value.ToString();
                txtHoTen.Text = r.Cells["SHoTen"].Value.ToString();
                cboLoaiTK.Text = r.Cells["SLoaiTaiKhoan"].Value.ToString();
                // Lấy mật khẩu hiện lên ô nhập (sẽ hiện dấu * do đã chỉnh UseSystemPasswordChar)
                txtMatKhau.Text = r.Cells["SMatKhau"].Value.ToString();

                
            }
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}