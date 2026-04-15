using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmHoaDon : Form
    {
        HoaDon_BUS busHD = new HoaDon_BUS();
        public frmHoaDon()
        {
            InitializeComponent();
            LoadDSHoaDon();
        }

        private void LoadDSHoaDon()
        {
            List<HoaDon_DTO> ds = busHD.LayDanhSachHoaDon();
            dgvHoaDon.DataSource = ds;

            // Đổi tên Header khớp với tên trong DTO
            dgvHoaDon.Columns["IMaHD"].HeaderText = "Mã HD";
            dgvHoaDon.Columns["SHoTen"].HeaderText = "Tên Khách Hàng"; // Sẽ hiện chữ
            dgvHoaDon.Columns["STenPhong"].HeaderText = "Tên Phòng";  // Sẽ hiện chữ (VD: P101)
            dgvHoaDon.Columns["DtNgayThanhToan"].HeaderText = "Ngày TT";
            dgvHoaDon.Columns["DTongTienPhong"].HeaderText = "Tiền Phòng";
            dgvHoaDon.Columns["DTongTienDV"].HeaderText = "Tiền DV";
            dgvHoaDon.Columns["DTongTienThanhToan"].HeaderText = "Tổng Cộng";

            // ẨN CÁC CỘT ID KHÔNG CẦN THIẾT
            dgvHoaDon.Columns["IMaPhieu"].Visible = false;
            dgvHoaDon.Columns["IMaTK_NguoiLap"].Visible = false;

            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ giao diện
                DateTime tu = dtpTuNgay.Value;
                DateTime den = dtpDenNgay.Value;
                string tenKH = txtTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm

                // 2. Gọi tầng BUS để lấy dữ liệu (Truyền đủ 3 tham số để hết lỗi gạch đỏ)
                // Lưu ý: Đảm bảo HoaDon_BUS.LayHoaDon đã được cập nhật nhận 3 tham số
                DataTable dt = busHD.LayDanhSachHoaDon(tu, den, tenKH);

                // 3. Hiển thị lên DataGridView
                dgvHoaDon.DataSource = dt;

                // 4. Định dạng lại bảng để không bị lỗi tên cột dính nhau như ảnh
                if (dt != null && dt.Rows.Count > 0)
                {
                    FormatDataGridView();

                    // Tính toán lại tổng tiền hiển thị lên các Label bên phải
                    decimal tongTienDV = 0;
                    decimal tongThanhToan = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        tongTienDV += Convert.ToDecimal(row["TongTienDV"]);
                        tongThanhToan += Convert.ToDecimal(row["TongTienThanhToan"]);
                    }

                    // Gán giá trị lên Label (ví dụ lblTongTienDV, lblTongThanhToan)
                    lblTongDV.Text = tongTienDV.ToString("N0") + " VNĐ";
                    lblTongCong.Text = tongThanhToan.ToString("N0") + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }
        private void FormatDataGridView()
        {
            if (dgvHoaDon.Columns.Contains("MaHD")) dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HD";
            if (dgvHoaDon.Columns.Contains("TenPhong")) dgvHoaDon.Columns["TenPhong"].HeaderText = "Tên Phòng";
            if (dgvHoaDon.Columns.Contains("HoTen")) dgvHoaDon.Columns["HoTen"].HeaderText = "Họ Tên";
            if (dgvHoaDon.Columns.Contains("NgayThanhToan")) dgvHoaDon.Columns["NgayThanhToan"].HeaderText = "Ngày Thanh Toán";
            if (dgvHoaDon.Columns.Contains("TongTienPhong")) dgvHoaDon.Columns["TongTienPhong"].HeaderText = "Tiền Phòng";
            if (dgvHoaDon.Columns.Contains("TongTienDV")) dgvHoaDon.Columns["TongTienDV"].HeaderText = "Tiền DV";
            if (dgvHoaDon.Columns.Contains("TongTienThanhToan")) dgvHoaDon.Columns["TongTienThanhToan"].HeaderText = "Tổng Cộng";

            // Tự động giãn đều các cột để không bị mất chữ
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            DateTime tu = dtpTuNgay.Value;
            DateTime den = dtpDenNgay.Value;

            DataTable dt = busHD.LayDanhSachHoaDon(tu, den, keyword);

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.AutoGenerateColumns = true;
            dgvHoaDon.DataSource = dt;

            // Đặt lại header luôn luôn
            FormatDataGridView();
        }
    }
}
