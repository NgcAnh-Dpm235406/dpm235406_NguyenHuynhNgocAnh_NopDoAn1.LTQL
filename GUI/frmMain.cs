using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain(TaiKhoan_DTO user)
        {
            InitializeComponent();
        }

        /// Biến lưu thông tin người dùng đăng nhập
        public static TaiKhoan_DTO loginAccount;

        // Khai báo BUS để dùng
        TaiKhoan_BUS busTK = new TaiKhoan_BUS();
        private void OpenChildForm(Form childForm)
        {
            // Xóa các control cũ trong Main Panel (ví dụ đặt tên là pnlMainContent)
            if (pnlNoiDungChinh.Controls.Count > 0)
            {
                pnlNoiDungChinh.Controls.Clear();
            }

            childForm.TopLevel = false; // Thiết lập Form con không phải là cửa sổ cấp cao nhất
            childForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền Form con
            childForm.Dock = DockStyle.Fill; // Để Form con lấp đầy Main Panel

            pnlNoiDungChinh.Controls.Add(childForm); // Thêm Form con vào Panel
            pnlNoiDungChinh.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Sự kiện Click nút Quản lý Phòng
        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            // Mở Form Quản lý Phòng
            lblTieuDe.Text = "QUẢN LÝ PHÒNG";
            OpenChildForm(new frmQuanLyPhong());
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard (Bạn cần tạo Form này trước)
            lblTieuDe.Text = "TỔNG QUAN";
            OpenChildForm(new frmTongQuan());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard(Bạn cần tạo Form này trước)
            lblTieuDe.Text = "kHÁCH HÀNG";
            OpenChildForm(new frmKhachHang());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard(Bạn cần tạo Form này trước)
            lblTieuDe.Text = "HÓA ĐƠN";
            OpenChildForm(new frmHoaDon());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard(Bạn cần tạo Form này trước)
            lblTieuDe.Text = "DỊCH VỤ";
            OpenChildForm(new frmDichVu());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard(Bạn cần tạo Form này trước)
            lblTieuDe.Text = "THỐNG KÊ";
            //OpenChildForm(new frmThongKe());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Mở Form Dashboard(Bạn cần tạo Form này trước)
            lblTieuDe.Text = "TÀI KHOẢN";
            OpenChildForm(new frmTaiKhoan());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /// 1. Kiểm tra nếu loginAccount tồn tại
            if (loginAccount != null)
            {
                // Hiển thị họ tên lên giao diện
                lblHoTen.Text = "Xin chào, " + loginAccount.STenDangNhap;

                // 2. Thực hiện phân quyền
                PhanQuyenHeThong();
            }
        }

        private void PhanQuyenHeThong()
        {
            // Sử dụng BUS để kiểm tra thay vì so sánh chuỗi trực tiếp
            bool isAdmin = busTK.LaAdmin(loginAccount);

            btnTaiKhoan.Visible = isAdmin;
            // btnThongKe.Visible = isAdmin;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // Đóng Form Main để quay lại Login
            }
        }

        // Hàm dùng chung để "nhúng" Form con vào Panel chính
        private void MoFormCon(Form formCon)
        {
            // 1. Xóa bỏ nội dung cũ đang hiển thị trong Panel
            if (pnlNoiDungChinh.Controls.Count > 0)
            {
                pnlNoiDungChinh.Controls.Clear();
            }

            // 2. Cấu hình Form con để nó có thể nằm gọn trong Panel
            formCon.TopLevel = false;            // Bắt buộc: Để Form không nhảy ra ngoài
            formCon.FormBorderStyle = FormBorderStyle.None; // Bỏ thanh tiêu đề của Form con
            formCon.Dock = DockStyle.Fill;       // Để Form con lấp đầy Panel chính

            // 3. Thêm Form con vào Panel và hiển thị
            pnlNoiDungChinh.Controls.Add(formCon);
            pnlNoiDungChinh.Tag = formCon;
            formCon.BringToFront();
            formCon.Show();
        }

        private void btnQuanlyp_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "QUẢN LÝ PHÒNG";

            // Khởi tạo Form con
            frmQuanLyPhong f = new frmQuanLyPhong();

            // Gọi hàm để nhúng vào Panel (nhớ kiểm tra tên Panel bên trong hàm này)
            OpenChildForm(f);
        }



        private void btnTongQuan_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "TỔNG QUAN";

            // Khởi tạo Form con
            frmTongQuan f = new frmTongQuan();

            // Gọi hàm để nhúng vào Panel (nhớ kiểm tra tên Panel bên trong hàm này)
            OpenChildForm(f);
        }

        private void btnKhachHang_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "KHÁCH HÀNG";

            // Khởi tạo Form con
            frmKhachHang f = new frmKhachHang();

            // Gọi hàm để nhúng vào Panel (nhớ kiểm tra tên Panel bên trong hàm này)
            OpenChildForm(f);
        }

        private void btnHoaDon_Click_1(object sender, EventArgs e)
        {
            lblTieuDe.Text = "HÓA ĐƠN";

            // Khởi tạo Form con
            frmHoaDon f = new frmHoaDon();

            // Gọi hàm để nhúng vào Panel (nhớ kiểm tra tên Panel bên trong hàm này)
            OpenChildForm(f);
        }
    }
}
