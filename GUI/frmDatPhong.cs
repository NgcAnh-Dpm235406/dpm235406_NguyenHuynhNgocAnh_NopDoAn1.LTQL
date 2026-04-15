using BUS; // Thêm reference đến tầng BUS
using DTO; // Thêm reference đến tầng DTO
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDatPhong : Form
    {
        // Khai báo các lớp nghiệp vụ
        LoaiPhong_BUS busLoai = new LoaiPhong_BUS();
        Phong_BUS busPhong = new Phong_BUS();
        KhachHang_BUS busKhach = new KhachHang_BUS();
        PhieuThue_BUS busPhieu = new PhieuThue_BUS(); // Bộ PhieuThue bạn vừa tạo

        public frmDatPhong()
        {
            InitializeComponent();
        }
        bool isLoading = true; // Thêm biến này
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            isLoading = true;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);

            LoadComboBoxLoaiPhong();
            isLoading = false; // Load xong mới cho phép sự kiện chạy
            LoadFullCboTenPhongTrong();
        }


        private void LoadComboBoxLoaiPhong()
        {
            // Giả sử hàm LayDanhSachLoaiPhong() trong BUS trả về DataTable có cột "MaLoai", "TenLoai"
            DataTable dt = busLoai.LayDanhSachLoaiPhong();

            if (dt != null && dt.Rows.Count > 0)
            {
                cboLoaiPhong.DataSource = dt;
                cboLoaiPhong.DisplayMember = "TenLoai"; // Tên hiển thị cho người dùng
                cboLoaiPhong.ValueMember = "MaLoai";     // Giá trị ẩn bên dưới để lưu vào DB
                cboLoaiPhong.SelectedIndex = -1;       // Mặc định chưa chọn cái nào
            }
        }
        private void LoadFullCboTenPhongTrong()
        {
            // Gọi hàm từ BUS
            DataTable dt = busPhong.LayTatCaPhongTrong();

            if (dt != null && dt.Rows.Count > 0)
            {
                cboTenPhong.DataSource = dt;
                cboTenPhong.DisplayMember = "TenPhong"; // Hiển thị tên phòng (VD: Phòng 101)
                cboTenPhong.ValueMember = "MaPhong";   // Giá trị ẩn là mã phòng để lưu vào CSDL
                cboTenPhong.SelectedIndex = -1;        // Mặc định không chọn cái nào để người dùng tự chọn
            }
            else
            {
                cboTenPhong.DataSource = null;
                cboTenPhong.Text = "Không có phòng trống";
            }
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            // 1. Kiểm tra SelectedValue không null
            if (cboLoaiPhong.SelectedValue != null)
            {
                int maLoai = 0;

                // 2. Xử lý ép kiểu an toàn (Quan trọng)
                if (cboLoaiPhong.SelectedValue is DataRowView drv)
                {
                    maLoai = Convert.ToInt32(drv["MaLoai"]);
                }
                else
                {
                    int.TryParse(cboLoaiPhong.SelectedValue.ToString(), out maLoai);
                }

                // 3. Nếu lấy được mã loại hợp lệ (>0) thì mới gọi BUS
                if (maLoai > 0)
                {
                    DataTable dtSoPhong = busPhong.LayPhongTrongTheoLoai(maLoai);

                    if (dtSoPhong != null && dtSoPhong.Rows.Count > 0)
                    {
                        cboTenPhong.DataSource = dtSoPhong;
                        cboTenPhong.DisplayMember = "TenPhong";
                        cboTenPhong.ValueMember = "MaPhong";
                    }
                    else
                    {
                        // Nếu không có phòng nào thỏa mãn (Trống)
                        cboTenPhong.DataSource = null;
                        cboTenPhong.Text = "Hết phòng";
                    }
                }
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || cboTenPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đủ Họ tên, SĐT và chọn Số phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PhieuThue_DTO phieuDTO = new PhieuThue_DTO();

                // --- ĐOẠN SỬA QUAN TRỌNG NHẤT ---
                // Lấy chuỗi "Phòng 101", sau đó cắt bỏ chữ "Phòng " để lấy số 101
                string selectedRoom = cboTenPhong.SelectedItem.ToString(); // Lấy "Phòng 101"
                string roomNumber = selectedRoom.Replace("Phòng ", "").Trim(); // Còn lại "101"
                phieuDTO.IMaPhong = int.Parse(roomNumber); // Chuyển "101" thành số 101
                                                           // -------------------------------

                phieuDTO.DtNgayCheckIn = dtpCheckIn.Value;
                phieuDTO.DtNgayCheckOutDuKien = dtpCheckOut.Value;
                phieuDTO.STrangThai = "Chưa thanh toán";

                // Giả sử bạn tạm để MaKH = 1 để test nếu chưa làm phần Khách hàng
                phieuDTO.IMaKH = 1;

                if (busPhieu.ThuePhong(phieuDTO))
                {
                    // Cập nhật trạng thái phòng trong DB thành 'Có khách'
                    busPhong.CapNhatTrangThaiPhong(phieuDTO.IMaPhong, "Có khách");

                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể lưu vào cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            cboLoaiPhong.SelectedIndex = -1;
            cboTenPhong.DataSource = null; // Xóa list số phòng
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            numSoNguoi.Value = 1;
            
            txtTienCoc.Text = "";
            txtGhiChu.Text = "";
        }

        private void cboLoaiPhong_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}