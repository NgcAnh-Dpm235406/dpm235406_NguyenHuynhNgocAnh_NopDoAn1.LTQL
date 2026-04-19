using System;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace GUI
{
    public partial class frmLogin : Form
    {
        // Nếu các hàm trong TaiKhoan_BUS KHÔNG có chữ 'static', ta giữ nguyên dòng này:
        TaiKhoan_BUS accBus = new TaiKhoan_BUS();

        public frmLogin()
        {
            InitializeComponent();
            // Thiết lập mặc định
            txtMatKhau.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtTen.Text.Trim(); // Nhớ kiểm tra đúng tên ID của TextBox
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Gọi BUS để kiểm tra đăng nhập (Trả về một đối tượng DTO)
                TaiKhoan_DTO loginAcc = accBus.KiemTraDangNhap(user, pass);

                if (loginAcc != null)
                {
                    // 2. LƯU THÔNG TIN VÀO LỚP TOÀN CỤC (Để các Form sau dùng)
                    GlobalUser.TenDangNhap = loginAcc.STenDangNhap; // Hoặc .TenDangNhap tùy biến bạn đặt trong DTO
                    GlobalUser.LoaiTaiKhoan = loginAcc.SLoaiTaiKhoan; // Đây là cột 'Admin', 'Manager' hoặc 'User'
                    GlobalUser.HoTen = loginAcc.SHoTen;
                    MessageBox.Show($"Đăng nhập thành công! Chào {loginAcc.SHoTen} ({GlobalUser.LoaiTaiKhoan})",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Mở Form Main và truyền đối tượng loginAcc vào (như hàm khởi tạo của bạn yêu cầu)
                    frmMain f = new frmMain(loginAcc);
                    this.Hide();
                    f.ShowDialog();

                    this.Show(); // 3. Hiện lại Login
                    txtMatKhau.Clear(); // Xóa pass cũ cho an toàn
                    txtMatKhau.Focus();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // --- Hiển thị mật khẩu khi giữ chuột ---
        private void showPASS_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void showPASS_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Thoát hoàn toàn app để không bị chạy ngầm khi đóng Login
            Application.Exit();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}