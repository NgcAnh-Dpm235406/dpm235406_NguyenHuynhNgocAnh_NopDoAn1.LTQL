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
            if (dt == null) { MessageBox.Show("DataTable = null"); return; }
            // Hiển thị tên các cột trả về
            var cols = string.Join(", ", dt.Columns.Cast<System.Data.DataColumn>().Select(c => c.ColumnName));
            MessageBox.Show("Cols: " + cols);
            if (dt.Rows.Count > 0)
            {
                var row0 = string.Join(" | ", dt.Columns.Cast<System.Data.DataColumn>().Select(c =>
                    dt.Rows[0][c] == DBNull.Value ? "<null>" : dt.Rows[0][c].ToString()));
                MessageBox.Show("Row0: " + row0);
            }

            dgvDanhSach.Columns.Clear();
            dgvDanhSach.DataSource = dt;
            dgvDanhSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.ReadOnly = true;
        }
    }
}