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
            // 1. Kiểm tra đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cboTenPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng và chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Tạo đối tượng Phiếu Thuê
                PhieuThue_DTO phieuDTO = new PhieuThue_DTO();

                // Lấy MaPhong từ ValueMember (đã cài đặt ở hàm Load)
                phieuDTO.IMaPhong = Convert.ToInt32(cboTenPhong.SelectedValue);

                phieuDTO.DtNgayCheckIn = dtpCheckIn.Value;
                phieuDTO.DtNgayCheckOutDuKien = dtpCheckOut.Value;
                phieuDTO.STrangThai = "Chưa thanh toán";

                // 3. Logic xử lý Khách hàng (Quan trọng)
                // Bạn nên viết thêm hàm trong BUS để lấy MaKH từ SDT hoặc thêm mới
                // Ở đây tôi tạm giữ logic cũ của bạn nhưng khuyến khích cập nhật
                phieuDTO.IMaKH = 1;

                // 4. Thực thi lưu
                if (busPhieu.ThuePhong(phieuDTO))
                {
                    // Cập nhật trạng thái phòng sang 'Có khách' để không ai đặt trùng
                    busPhong.CapNhatTrangThaiPhong(phieuDTO.IMaPhong, "Có khách");

                    MessageBox.Show($"Đặt thành công phòng {cboTenPhong.Text}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới giao diện và load lại danh sách phòng trống
                    btnLamMoi_Click(null, null);
                    LoadFullCboTenPhongTrong();
                }
                else
                {
                    MessageBox.Show("Không thể lưu phiếu thuê. Vui lòng kiểm tra lại kết nối DB!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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