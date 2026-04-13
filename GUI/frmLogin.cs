using BUS;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        // Khởi tạo BUS
        TaiKhoan_BUS accBus = new TaiKhoan_BUS();

        public frmLogin()
        {
            InitializeComponent();
            // Thiết lập mặc định
            txtMatKhau.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin; // Nhấn Enter trên bàn phím sẽ tự kích hoạt btnLogin
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtTen.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi BUS kiểm tra
            TaiKhoan_DTO loginAcc = accBus.KiemTraDangNhap(user, pass);

            if (loginAcc != null)
            {
                MessageBox.Show("Đăng nhập thành công! Chào " + loginAcc.SHoTen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 1. Khởi tạo Form Main
                frmMain f = new frmMain(loginAcc);

                // 2. Ẩn form Login
                this.Hide();

                // 3. Hiển thị Main dưới dạng Dialog. 
                // Khi người dùng nhấn Đăng xuất (this.Close() ở frmMain), code sẽ chạy tiếp dòng dưới.
                f.ShowDialog();

                // 4. Khi quay lại Login: Xóa trắng mật khẩu và hiện Form
                txtMatKhau.Clear();
                this.Show();
                txtMatKhau.Focus(); // Để con trỏ vào ô mật khẩu cho lần đăng nhập sau
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit(); // Thoát hoàn toàn ứng dụng
            }
        }

        // --- Hiển thị mật khẩu (Cải tiến) ---
        private void showPASS_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void showPASS_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        // --- Đảm bảo đóng Form Login là đóng sạch ứng dụng ---
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu form Login bị đóng thủ công (dấu X), thoát hẳn app để không chạy ngầm
            if (this.Visible == true)
            {
                Application.Exit();
            }
        }
    }
}