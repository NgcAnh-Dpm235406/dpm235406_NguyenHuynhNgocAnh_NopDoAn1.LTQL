using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace GUI
{
    public partial class frmQuanLyPhong : Form
    {
        // Khởi tạo lớp BUS
        Phong_BUS busPhong = new Phong_BUS();
        int maPhongChon = -1; // Lưu trữ mã phòng đang được click chọn

        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadComboBoxLoaiPhong();
            LoadComboBoxTrangThai();
            VeSoDoPhong();
        }

        // 1. Load danh sách loại phòng vào ComboBox
        void LoadComboBoxLoaiPhong()
        {
            // Giả sử bạn có LoaiPhong_BUS, nếu chưa có hãy dùng tạm DataTable từ DAO
            // cboLoaiPhong.DataSource = busLoaiPhong.LayDSLoaiPhong();
            // cboLoaiPhong.DisplayMember = "STenLoai";
            // cboLoaiPhong.ValueMember = "IMaLoai";
        }

        // 2. Load các trạng thái cố định
        void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Trống", "Có khách", "Đã đặt", "Sửa chữa" });
            cboTrangThai.SelectedIndex = 0;
        }

        // 3. Hàm vẽ sơ đồ phòng bằng Guna2TileButton
        void VeSoDoPhong()
        {
            flpDanhSachPhong.Controls.Clear();
            List<Phong_DTO> dsPhong = busPhong.LayDanhSachPhong();

            if (dsPhong == null) return;

            foreach (Phong_DTO item in dsPhong)
            {
                // Sử dụng Guna2TileButton giống mẫu bạn gửi
                Guna.UI2.WinForms.Guna2TileButton btn = new Guna.UI2.WinForms.Guna2TileButton();
                btn.Width = 100;
                btn.Height = 100;
                btn.BorderRadius = 8;
                btn.Text = item.STenPhong + Environment.NewLine + item.STrangThai;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // Đổ màu theo trạng thái
                if (item.STrangThai == "Trống")
                    btn.FillColor = Color.FromArgb(46, 204, 113); // Xanh lá
                else if (item.STrangThai == "Có khách")
                    btn.FillColor = Color.FromArgb(231, 76, 60); // Đỏ
                else if (item.STrangThai == "Đã đặt")
                    btn.FillColor = Color.FromArgb(241, 196, 15); // Vàng
                else if (item.STrangThai == "Sửa chữa")
                    btn.FillColor = Color.FromArgb(149, 165, 166); // Xám (Flat UI Gray)
                else
                    btn.FillColor = Color.Silver; // Màu bạc cho các trường hợp khác nếu có

                // Sự kiện khi click vào một phòng trên sơ đồ
                btn.Click += (s, ev) => {
                    maPhongChon = item.IMaPhong;
                    txtTenPhong.Text = item.STenPhong;
                    cboTrangThai.Text = item.STrangThai;
                    cboLoaiPhong.SelectedValue = item.IMaLoai;

                    // Hiển thị giá tiền từ DTO (đã JOIN từ bảng LoaiPhong)
                    txtGiaNgay.Text = item.DGiaNgay.ToString("N0") + " VNĐ";
                    txtGiaGio.Text = item.DGiaGio.ToString("N0") + " VNĐ";

                    // Tính tiền tạm tính nếu cần
                    TinhTienTamTinh(item);
                };

                flpDanhSachPhong.Controls.Add(btn);
            }
        }

        void TinhTienTamTinh(Phong_DTO p)
        {
            // Logic tính tiền dựa trên DGiaNgay, DGiaGio và số giờ ở thực tế
            // txtTienTamTinh.Text = ...
        }

        // 4. Sự kiện Thêm Phòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!");
                return;
            }

            Phong_DTO p = new Phong_DTO();
            p.STenPhong = txtTenPhong.Text;
            p.IMaLoai = (int)cboLoaiPhong.SelectedValue;
            p.STrangThai = cboTrangThai.Text;

            if (busPhong.ThemPhong(p)) // Bạn cần viết hàm ThemPhong trong BUS/DAO
            {
                MessageBox.Show("Thêm phòng mới thành công!");
                VeSoDoPhong();
            }
        }

        // 5. Sự kiện Sửa Phòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maPhongChon == -1) return;

            Phong_DTO p = new Phong_DTO();
            p.IMaPhong = maPhongChon;
            p.STenPhong = txtTenPhong.Text;
            p.IMaLoai = (int)cboLoaiPhong.SelectedValue;
            p.STrangThai = cboTrangThai.Text;

            if (busPhong.SuaPhong(p)) // Bạn cần viết hàm SuaPhong trong BUS/DAO
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                VeSoDoPhong();
            }
        }

        // 6. Sự kiện Xóa Phòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maPhongChon == -1) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (busPhong.XoaPhong(maPhongChon))
                {
                    MessageBox.Show("Đã xóa phòng!");
                    VeSoDoPhong();
                    ResetInput();
                }
            }
        }

        void ResetInput()
        {
            maPhongChon = -1;
            txtTenPhong.Clear();
            txtGiaNgay.Clear();
            txtGiaGio.Clear();
            cboTrangThai.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}