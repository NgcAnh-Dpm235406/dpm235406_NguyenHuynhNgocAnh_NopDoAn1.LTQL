using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmQuanLyPhong : Form
    {
        // Khởi tạo lớp BUS
        Phong_BUS busPhong = new Phong_BUS();
        LoaiPhong_BUS busLoaiPhong = new LoaiPhong_BUS();
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

            // Đăng ký sự kiện TextChanged trực tiếp bằng code để chắc chắn nó chạy
            txtGiaNgay.TextChanged += txtGiaNgay_TextChanged;
            txtGiaGio.TextChanged += txtGiaGio_TextChanged;
        }

        // 1. Load danh sách loại phòng vào ComboBox
        void LoadComboBoxLoaiPhong()
        {
            // Giao diện (GUI) gọi qua BUS - ĐÚNG CHUẨN
            DataTable dt = busLoaiPhong.LayDanhSachLoaiPhong();

            if (dt != null)
            {
                cboLoaiPhong.DataSource = dt;
                cboLoaiPhong.DisplayMember = "TenLoai";
                cboLoaiPhong.ValueMember = "MaLoai";
            }
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
            List<Phong_DTO> dsPhong = Phong_BUS.LayDanhSachPhong();

            if (dsPhong == null) return;

            foreach (Phong_DTO item in dsPhong)
            {
                // Sử dụng Guna2TileButton giống mẫu bạn gửi
                Guna.UI2.WinForms.Guna2TileButton btn = new Guna.UI2.WinForms.Guna2TileButton();
                btn.Width = 67;
                btn.Height = 67;
                btn.BorderRadius = 8;
                btn.Text = item.STenPhong + Environment.NewLine + item.STrangThai;
                btn.Font = new Font("Time New Roman ", 9, FontStyle.Bold);

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

                    txtGiaNgay.Text = item.DGiaNgay.ToString("N0");
                    txtGiaGio.Text = item.DGiaGio.ToString("N0");

                    // KHÔNG gán cứng bằng "0", mà phải lấy từ item (DTO)
                    txtNgay.Text = item.ISoNgay.ToString();
                    txtGio.Text = item.ISoGio.ToString();

                    // Gọi hàm tính tiền để hiện tổng tiền ngay khi click
                    TinhTienTamTinh();
                };

                flpDanhSachPhong.Controls.Add(btn);
            }
        }

        // Tạo một hàm tính toán chung
        void TinhTienTamTinh()
        {
            // Loại bỏ dấu phẩy và chữ VNĐ để lấy số thuần túy
            string sGiaNgay = txtGiaNgay.Text.Replace(",", "").Replace("VNĐ", "").Trim();
            string sGiaGio = txtGiaGio.Text.Replace(",", "").Replace("VNĐ", "").Trim();

            decimal giaNgay = 0, giaGio = 0;
            int soNgay = 0, soGio = 0;

            decimal.TryParse(sGiaNgay, out giaNgay);
            decimal.TryParse(sGiaGio, out giaGio);
            int.TryParse(txtNgay.Text, out soNgay);
            int.TryParse(txtGio.Text, out soGio);

            decimal tong = (giaNgay * soNgay) + (giaGio * soGio);

            // Hiển thị lại với định dạng tiền tệ
            txtTienTT.Text = tong.ToString("N0") + " VNĐ";
        }

        // Gọi hàm này trong sự kiện TextChanged của txtSoNgay và txtSoGio
        private void txtSoNgay_TextChanged(object sender, EventArgs e) => TinhTienTamTinh();
        private void txtSoGio_TextChanged(object sender, EventArgs e) => TinhTienTamTinh();

        // 4. Sự kiện Thêm Phòng
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Xóa trắng các TextBox
            txtTenPhong.Clear();
            txtGiaNgay.Clear();
            txtGiaGio.Clear();
            txtNgay.Text = "0";
            txtGio.Text = "0";
            txtTienTT.Text = "0 VNĐ";
            // 2. Đưa các ComboBox về mặc định
            cboTrangThai.SelectedIndex = 0; // Trống
            if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
            // 3. Mở khóa các ô nhập liệu
            MoKhoaTatCa();
            maPhongChon = -1; // Reset mã phòng để hiểu là đang thêm mới chứ không phải sửa
            // 4. Đặt tiêu điểm vào ô Tên phòng để người dùng nhập luôn
            txtTenPhong.Focus();
            MessageBox.Show("Vui lòng nhập thông tin phòng mới, sau đó nhấn LƯU.");
        }

        // 5. Sự kiện Sửa Phòng
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maPhongChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một phòng từ danh sơ đồ trước khi sửa!");
                return;
            }
            // 1. Mở khóa các ô để người dùng nhập (ReadOnly = false)
            txtTenPhong.ReadOnly = false;
            // Vì bạn dùng Guna2 nên dùng thuộc tính Enabled cũng được hoặc dùng ReadOnly
            txtGiaNgay.Enabled = true;
            txtGiaGio.Enabled = true;
            cboLoaiPhong.Enabled = true;
            cboTrangThai.Enabled = true;
            // 2. Thay đổi màu nền để người dùng biết là đang trong chế độ sửa
            txtTenPhong.FillColor = Color.White;
            txtGiaNgay.FillColor = Color.White;
            txtGiaGio.FillColor = Color.White;
            // 3. Đưa con trỏ vào ô Tên phòng
            txtTenPhong.Focus();
           
        }

        // 6. Sự kiện Xóa Phòng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maPhongChon == -1) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (Phong_BUS.XoaPhong(maPhongChon))
                {
                    MessageBox.Show("Đã xóa phòng!");
                    VeSoDoPhong();
                    ResetInput();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maPhongChon == -1) return;

            // Giả sử bạn đã có logic tính tiền trong txtTienTamTinh
            DialogResult result = MessageBox.Show("Xác nhận thanh toán cho phòng này?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // 1. Đưa phòng về trạng thái trống
                if (Phong_BUS.CapNhatTrangThaiPhong(maPhongChon, "Trống"))
                {
                    MessageBox.Show("Thanh toán thành công!");
                    VeSoDoPhong(); // Cập nhật lại sơ đồ phòng thành màu xanh
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
            txtNgay.Clear();
            txtGio.Clear();
            txtTienTT.Text = "0 VNĐ";
            cboTrangThai.SelectedIndex = 0; // Đưa về mặc định "Trống"
            MoKhoaTatCa(); // Mở khóa các ô bị mờ để sẵn sàng nhập phòng mới
        }


        // Sự kiện khi thay đổi nội dung ô Giá phòng ngày
        // Khi nhập vào ô Giá Ngày hoặc Số Ngày
        private void txtGiaNgay_TextChanged(object sender, EventArgs e)
        {
            TinhTienTamTinh();
        }

        private void txtGiaGio_TextChanged(object sender, EventArgs e)
        {
            TinhTienTamTinh();
        }


        void MoKhoaTatCa()
        {
            txtGiaNgay.Enabled = true;
            txtNgay.Enabled = true;
            txtGiaGio.Enabled = true;
            txtGio.Enabled = true;
            // Trả lại màu trắng ban đầu
            txtNgay.FillColor = Color.White;
            txtGiaNgay.FillColor = Color.White;
            txtGio.FillColor = Color.White;
            txtGiaGio.FillColor = Color.White;
        }


        // Trong file frmQuanLyPhong.cs, hàm btnLuu_Click
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }

            // 2. Khởi tạo đối tượng DTO và lấy dữ liệu từ giao diện
            Phong_DTO p = new Phong_DTO();
            p.STenPhong = txtTenPhong.Text.Trim();
            p.IMaLoai = (int)cboLoaiPhong.SelectedValue;
            p.STrangThai = cboTrangThai.Text;

            // Giá ngày/giờ
            string sGiaNgay = txtGiaNgay.Text.Replace(",", "").Replace("VNĐ", "").Trim();
            string sGiaGio = txtGiaGio.Text.Replace(",", "").Replace("VNĐ", "").Trim();

            decimal giaNgay = 0, giaGio = 0;
            decimal.TryParse(sGiaNgay, out giaNgay);
            decimal.TryParse(sGiaGio, out giaGio);

            p.DGiaNgay = giaNgay;
            p.DGiaGio = giaGio;

            // >>> Bổ sung lấy số ngày và số giờ <<<
            int soNgay = 0, soGio = 0;
            int.TryParse(txtNgay.Text, out soNgay);
            int.TryParse(txtGio.Text, out soGio);

            p.ISoNgay = soNgay;
            p.ISoGio = soGio;

            // 3. Phân loại xử lý: Thêm mới hoặc Cập nhật
            if (maPhongChon == -1)
            {
                if (Phong_BUS.ThemPhong(p))
                {
                    MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeSoDoPhong();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại! Có thể tên phòng đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                p.IMaPhong = maPhongChon;

                if (Phong_BUS.SuaPhong(p))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VeSoDoPhong();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Lỗi: Không thể cập nhật dữ liệu xuống Database.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

}