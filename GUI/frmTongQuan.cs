using BUS;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTongQuan : Form
    {
        Phong_BUS busPhong = new Phong_BUS();
        HoaDon_BUS busHoaDon = new HoaDon_BUS();

        public frmTongQuan()
        {
            InitializeComponent();
        }

        private void frmTongQuan_Load(object sender, EventArgs e)
        {
            // Gọi các hàm thực thi khi mở form
            HienThiThongKe();
            HienThiDanhSachChiTiet();
        }

        private void HienThiThongKe()
        {
            // Cập nhật các ô số lượng
            lblPhongTrong.Text = busPhong.DemPhongTheoTrangThai("Trống").ToString();
            lblCoKhach.Text = busPhong.DemPhongTheoTrangThai("Có khách").ToString();
            lblDaDat.Text = busPhong.DemPhongTheoTrangThai("Đã đặt").ToString();

            // Cập nhật doanh thu
            decimal doanhThu = busHoaDon.TinhTongDoanhThuTatCa();
            lblDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";
        }

        private void HienThiDanhSachChiTiet()
        {
            // Lấy dữ liệu JOIN từ 4 bảng
            DataTable dt = busPhong.LayDanhSachPhongTongQuan();

            // Xóa sạch các cột cũ tự tạo trong Design để tránh xung đột tên
            dgvDanhSach.Columns.Clear();

            // Gán dữ liệu
            dgvDanhSach.DataSource = dt;

            // Định dạng lại lưới cho đẹp
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.AllowUserToAddRows = false; // Mất dòng trống cuối cùng
            dgvDanhSach.ReadOnly = true; // Không cho sửa trực tiếp trên lưới
        }
    }
}