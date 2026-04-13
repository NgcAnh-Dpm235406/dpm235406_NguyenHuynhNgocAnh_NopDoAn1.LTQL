using BUS; // Đổi từ QLKS1.PUS sang BUS 
using DTO; // Đổi từ QLKS1.DTO sang DTO cho khớp với các file trước
using GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        // Sử dụng tên lớp TaiKhoan_BUS mà mình đã thống nhất
        TaiKhoan_BUS accBus = new TaiKhoan_BUS();

        public frmLogin()
        {
            InitializeComponent();
            // Đảm bảo mật khẩu luôn ẩn khi vừa mở form
            txtMatKhau.UseSystemPasswordChar = true;
        }

        // Sự kiện khi nhấn nút Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtTen.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

            // Gọi hàm KiemTraDangNhap từ BUS (Trả về TaiKhoan_DTO)
            TaiKhoan_DTO loginAcc = accBus.KiemTraDangNhap(user, pass);

            if(loginAcc != null)
{
                // Chào bằng Họ tên sẽ chuyên nghiệp hơn
                MessageBox.Show("Đăng nhập thành công! Chào " + loginAcc.SHoTen);

                frmMain f = new frmMain(loginAcc);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện nhấn vào nút PictureBox1 (Icon Shutdown)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Hiện mật khẩu khi nhấn giữ chuột vào icon con mắt
        private void showPASS_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void showPASS_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Có thể thêm các thiết lập ban đầu ở đây
        }
    }
}