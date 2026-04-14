using BUS;
using DTO;
using System;
using System.Data;
using System.Linq;
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
            // Gọi trực tiếp nếu bạn không muốn/không thể sửa Designer
            HienThiThongKe();
            HienThiDanhSachChiTiet();
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
            DataTable dt = busPhong.LayDanhSachPhongTongQuan();

            if (dt != null)
            {
                // Tắt chế độ tự tạo cột để dùng cột đã tạo trong Design
                dgvDanhSach.AutoGenerateColumns = false;

                // Gán DataPropertyName dựa trên thứ tự cột trong Designer
                // 0: MaPhong, 1: TenPhong, 2: TenLoai, 3: KhachHang, 4: NgayTra, 5: TrangThai
                dgvDanhSach.Columns[0].DataPropertyName = "MaPhong";
                dgvDanhSach.Columns[1].DataPropertyName = "TenPhong";
                dgvDanhSach.Columns[2].DataPropertyName = "TenLoai";
                dgvDanhSach.Columns[3].DataPropertyName = "HoTen";
                dgvDanhSach.Columns[4].DataPropertyName = "NgayCheckOutDuKien";
                dgvDanhSach.Columns[5].DataPropertyName = "TrangThai";

                dgvDanhSach.DataSource = dt;
                dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void prpDanhSach_Click(object sender, EventArgs e)
        {

        }
    }
}