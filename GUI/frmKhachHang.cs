using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUS; // Đảm bảo đã Add Reference tới project BUS
using DTO; // Đảm bảo đã Add Reference tới project DTO

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        // Khai báo đối tượng BUS và biến trạng thái
        private KhachHang_BUS busKH = new KhachHang_BUS();
        private bool isThemMoi = false;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            VoHieuHoaInput(); // Khóa các ô nhập lúc mới mở
        }

        // 1. Hàm load dữ liệu lên GridView
        private void LoadDanhSachKhachHang()
        {
            // GUI gọi qua BUS, BUS gọi DAO
            List<KhachHang_DTO> ds = busKH.LayTatCaKhachHang();
            dgvKhachHang.DataSource = ds;

            // Tùy chỉnh hiển thị cột nếu cần
            dgvKhachHang.Columns["IMaKH"].HeaderText = "Mã KH";
            dgvKhachHang.Columns["SHoTen"].HeaderText = "Họ Tên";
            dgvKhachHang.Columns["SCCCD"].HeaderText = "Số CCCD";
        }

        // 2. Các hàm bổ trợ giao diện
        private void LamMoiForm()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            if (cboQuocTich.Items.Count > 0) cboQuocTich.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        private void VoHieuHoaInput()
        {
            txtHoTen.Enabled = txtCCCD.Enabled = txtSDT.Enabled =
            txtDiaChi.Enabled = cboQuocTich.Enabled = false;
        }

        private void KichHoatInput()
        {
            txtHoTen.Enabled = txtCCCD.Enabled = txtSDT.Enabled =
            txtDiaChi.Enabled = cboQuocTich.Enabled = true;
        }

        // 3. Nút THÊM: Chỉ để mở khung nhập liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            isThemMoi = true;
            KichHoatInput();
            LamMoiForm();
            MessageBox.Show("Mời bạn nhập thông tin khách hàng mới, sau đó nhấn LƯU.");
        }

        // 4. Nút LƯU: Xử lý Thêm mới hoặc Cập nhật
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng không để trống Họ tên và CCCD!");
                return;
            }

            // Đóng gói dữ liệu vào DTO
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.SHoTen = txtHoTen.Text.Trim();
            kh.SCCCD = txtCCCD.Text.Trim();
            kh.SSDT = txtSDT.Text.Trim();
            kh.SDiaChi = txtDiaChi.Text.Trim();
            kh.SQuocTich = cboQuocTich.Text;

            if (isThemMoi)
            {
                // Thực hiện THÊM
                if (busKH.ThemKhachHang(kh))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadDanhSachKhachHang();
                    VoHieuHoaInput();
                    isThemMoi = false;
                }
                else MessageBox.Show("Thêm thất bại! CCCD có thể đã tồn tại.");
            }
            else
            {
                // Thực hiện SỬA
                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần sửa!");
                    return;
                }
                kh.IMaKH = int.Parse(txtMaKH.Text);

                if (busKH.SuaKhachHang(kh))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDanhSachKhachHang();
                    VoHieuHoaInput();
                }
                else MessageBox.Show("Cập nhật thất bại!");
            }
        }

        // 5. Nút XÓA
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int ma = int.Parse(txtMaKH.Text);
                if (busKH.XoaKhachHang(ma))
                {
                    MessageBox.Show("Đã xóa khách hàng.");
                    LoadDanhSachKhachHang();
                    LamMoiForm();
                    VoHieuHoaInput();
                }
                else MessageBox.Show("Không thể xóa (Khách hàng có dữ liệu liên quan)!");
            }
        }

        // 6. Sự kiện Click vào GridView để lấy dữ liệu lên TextBox
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isThemMoi = false; // Chuyển sang chế độ Sửa
                KichHoatInput();

                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["IMaKH"].Value?.ToString();
                txtHoTen.Text = row.Cells["SHoTen"].Value?.ToString();
                txtCCCD.Text = row.Cells["SCCCD"].Value?.ToString();
                txtSDT.Text = row.Cells["SSDT"].Value?.ToString();
                txtDiaChi.Text = row.Cells["SDiaChi"].Value?.ToString();
                cboQuocTich.Text = row.Cells["SQuocTich"].Value?.ToString();
            }
        }
    }
}