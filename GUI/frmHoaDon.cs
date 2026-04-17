using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoaDon : Form
    {
        private HoaDon_BUS busHD = new HoaDon_BUS();
        // Khai báo ở đầu class frmHoaDon
        private int maPhieuDangChon = 0;
        private decimal tienPhong = 0;
        private decimal tienDV = 0;
        private decimal tienThanhToan = 0;

        public frmHoaDon()
        {
            InitializeComponent();
            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;

            btnLoc.Click -= btnLoc_Click;
            btnLoc.Click += btnLoc_Click;

            txtTimKiem.TextChanged -= txtTimKiem_TextChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            if (btnInHoaDon != null)
            {
                btnInHoaDon.Click -= BtnInHoaDon_Click;
                btnInHoaDon.Click += BtnInHoaDon_Click;
            }
            if (guna2Button1 != null) // Export
            {
                guna2Button1.Click -= BtnXuatExcel_Click;
                guna2Button1.Click += BtnXuatExcel_Click;
            }
            if (guna2Button2 != null) // Delete
            {
                guna2Button2.Click -= BtnXoaHoaDon_Click;
                guna2Button2.Click += BtnXoaHoaDon_Click;
            }

            LoadDSHoaDon();



        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadCboPhieuThue();
        }
        private void LoadDSHoaDon()
        {
            DateTime tu = new DateTime(1753, 1, 1);
            DateTime den = new DateTime(9998, 12, 31);
            ApplyFilter(tu, den, string.Empty);

            // Hiển thị tổng toàn bộ
            decimal tongAll = busHD.TinhTongDoanhThuTatCa();
            if (lblTongAll != null) lblTongAll.Text = tongAll.ToString("N0");
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime tu = dtpTuNgay.Value.Date;
            DateTime den = dtpDenNgay.Value.Date;
            string tenKH = txtTimKiem.Text.Trim();
            ApplyFilter(tu, den, tenKH);
        }


        private void LoadCboPhieuThue()
        {
            // 1. Lấy dữ liệu từ lớp BUS
            DataTable dt = busHD.LayPhieuThueChuaCoHoaDon();

            if (dt != null && dt.Rows.Count > 0)
            {
                // 2. Gán nguồn dữ liệu cho ComboBox
                cboPhieuThue.DataSource = dt;

                // 3. Thiết lập cột hiển thị và cột giá trị
                // Hiển thị mã phiếu để người dùng chọn
                cboPhieuThue.DisplayMember = "MaPhieu";

                // Giá trị thực sự nhận được khi chọn là MaPhieu
                cboPhieuThue.ValueMember = "MaPhieu";

                // 4. (Tùy chọn) Để ComboBox không chọn sẵn dòng nào khi mới load
                cboPhieuThue.SelectedIndex = -1;
            }
            else
            {
                cboPhieuThue.DataSource = null;
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadDSHoaDon();
            }
            else
            {
                DateTime tu = dtpTuNgay.Value.Date;
                DateTime den = dtpDenNgay.Value.Date;
                string tenKH = txtTimKiem.Text.Trim();
                ApplyFilter(tu, den, tenKH);
            }
        }

        private void ApplyFilter(DateTime tu, DateTime den, string tenKH)
        {
            try
            {
                DataTable dt = busHD.LayDanhSachHoaDon(tu, den, tenKH);

                if ((dt == null || dt.Rows.Count == 0) && !string.IsNullOrWhiteSpace(tenKH))
                {
                    dt = busHD.LayDanhSachHoaDon(new DateTime(1753, 1, 1), new DateTime(9998, 12, 31), tenKH);
                }

                dgvHoaDon.DataSource = null;
                dgvHoaDon.Columns.Clear();

                dgvHoaDon.AutoGenerateColumns = true;
                dgvHoaDon.DataSource = dt;

                FormatDataGridView();

                // Tính tổng toàn bộ trong phạm vi lọc
                decimal tongTienDV = 0m;
                decimal tongThanhToan = 0m;
                decimal tongTienPhong = 0m;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        decimal dv = 0m, tt = 0m;
                        if (dt.Columns.Contains("TongTienDV")) decimal.TryParse(row["TongTienDV"]?.ToString(), out dv);
                        if (dt.Columns.Contains("TongTienThanhToan")) decimal.TryParse(row["TongTienThanhToan"]?.ToString(), out tt);
                        tongTienDV += dv;
                        tongThanhToan += tt;
                    }
                    tongTienPhong = tongThanhToan - tongTienDV;
                }

                if (lblTongTienDV != null) lblTongTienDV.Text = tongTienDV.ToString("N0");
                if (lblTongTienPhong != null) lblTongTienPhong.Text = tongTienPhong.ToString("N0");
                if (lblTongT != null) lblTongT.Text = tongThanhToan.ToString("N0");

                // Cập nhật tổng toàn bộ (toàn hệ thống)
                decimal tongAll = busHD.TinhTongDoanhThuTatCa();
                if (lblTongAll != null) lblTongAll.Text = tongAll.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy/hiển thị dữ liệu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvHoaDon.Columns.Contains("MaHD")) dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HD";
            if (dgvHoaDon.Columns.Contains("TenPhong")) dgvHoaDon.Columns["TenPhong"].HeaderText = "Tên Phòng";
            if (dgvHoaDon.Columns.Contains("HoTen")) dgvHoaDon.Columns["HoTen"].HeaderText = "Họ Tên";
            if (dgvHoaDon.Columns.Contains("NgayThanhToan")) dgvHoaDon.Columns["NgayThanhToan"].HeaderText = "Ngày TT";
            if (dgvHoaDon.Columns.Contains("TongTienPhong")) dgvHoaDon.Columns["TongTienPhong"].HeaderText = "Tiền Phòng";
            if (dgvHoaDon.Columns.Contains("TongTienDV")) dgvHoaDon.Columns["TongTienDV"].HeaderText = "Tiền DV";
            if (dgvHoaDon.Columns.Contains("TongTienThanhToan")) dgvHoaDon.Columns["TongTienThanhToan"].HeaderText = "Tổng Cộng";

            if (dgvHoaDon.Columns.Contains("MaPhieu")) dgvHoaDon.Columns["MaPhieu"].Visible = false;
            if (dgvHoaDon.Columns.Contains("MaTK_NguoiLap")) dgvHoaDon.Columns["MaTK_NguoiLap"].Visible = false;

            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null) return;
            DataRowView drv = dgvHoaDon.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            string hoTen = drv["HoTen"].ToString();
            var (tongPhong, tongDV, tongThanhToan) = busHD.TinhTongTheoKhach(hoTen);

            lblTongTienPhong.Text = tongPhong.ToString("N0");
            lblTongTienDV.Text = tongDV.ToString("N0");
            lblTongT.Text = tongThanhToan.ToString("N0");
        }

        // Các hàm In, Xuất Excel, Xóa giữ nguyên như bạn đã viết


        // In hóa đơn: tạo bản in đơn giản từ dòng đang chọn
        private void BtnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRowView drv = (DataRowView)dgvHoaDon.CurrentRow.DataBoundItem;

                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

                printDoc.PrintPage += (s, ev) =>
                {
                    Graphics g = ev.Graphics;
                    // 1. Khai báo Font & Pen chuyên nghiệp
                    Font fTitle = new Font("Arial", 20, FontStyle.Bold);
                    Font fInfoBold = new Font("Arial", 11, FontStyle.Bold);
                    Font fNormal = new Font("Arial", 11, FontStyle.Regular);
                    Font fItalic = new Font("Arial", 10, FontStyle.Italic);
                    Pen pThick = new Pen(Color.Black, 2);
                    Pen pThin = new Pen(Color.Gray, 1);

                    float y = ev.MarginBounds.Top;
                    float x = ev.MarginBounds.Left;
                    float w = ev.MarginBounds.Width;
                    float colAmountX = x + w - 150; // Vị trí cột tiền

                    // --- PHẦN ĐẦU: THÔNG TIN KHÁCH SẠN ---
                    g.DrawString("Phượng Hoàng HOTEL", fInfoBold, Brushes.DarkBlue, x, y);
                    y += 20;
                    g.DrawString("Địa chỉ: Mỹ Phước, Long Xuyên, AN Giang", fItalic, Brushes.Black, x, y);
                    y += 20;
                    g.DrawString("Hotline: 0123.456.789", fItalic, Brushes.Black, x, y);
                    y += 40;

                    // --- TIÊU ĐỀ HÓA ĐƠN ---
                    string header = "HÓA ĐƠN THANH TOÁN";
                    SizeF szHeader = g.MeasureString(header, fTitle);
                    g.DrawString(header, fTitle, Brushes.Black, x + (w - szHeader.Width) / 2, y);
                    y += szHeader.Height + 30;

                    // --- THÔNG TIN KHÁCH HÀNG (Sử dụng 2 cột) ---
                    g.DrawString($"Khách hàng: {drv["HoTen"]}", fNormal, Brushes.Black, x, y);
                    g.DrawString($"Mã HD: {drv["MaHD"]}", fNormal, Brushes.Black, x + w - 150, y);
                    y += 25;
                    g.DrawString($"Phòng: {drv["TenPhong"]}", fNormal, Brushes.Black, x, y);
                    DateTime ngayTT = Convert.ToDateTime(drv["NgayThanhToan"]);
                    g.DrawString($"Ngày: {ngayTT:dd/MM/yyyy}", fNormal, Brushes.Black, x + w - 150, y);
                    y += 40;

                    // --- BẢNG CHI TIẾT THANH TOÁN ---
                    // Vẽ tiêu đề bảng
                    g.FillRectangle(Brushes.LightGray, x, y, w, 30);
                    g.DrawRectangle(pThin, x, y, w, 30);
                    g.DrawString("DANH MỤC THANH TOÁN", fInfoBold, Brushes.Black, x + 10, y + 7);
                    g.DrawString("THÀNH TIỀN", fInfoBold, Brushes.Black, colAmountX, y + 7);
                    y += 35;

                    // Nội dung bảng (Tiền phòng)
                    decimal tPhong = Convert.ToDecimal(drv["TongTienPhong"]);
                    g.DrawString("1. Tiền thuê phòng", fNormal, Brushes.Black, x + 10, y);
                    // Căn phải số tiền
                    string sPhong = tPhong.ToString("N0");
                    float wPhong = g.MeasureString(sPhong, fNormal).Width;
                    g.DrawString(sPhong, fNormal, Brushes.Black, x + w - 20 - wPhong, y);
                    y += 25;

                    // Nội dung bảng (Tiền dịch vụ)
                    decimal tDV = Convert.ToDecimal(drv["TongTienDV"]);
                    g.DrawString("2. Phí dịch vụ đi kèm", fNormal, Brushes.Black, x + 10, y);
                    string sDV = tDV.ToString("N0");
                    float wDV = g.MeasureString(sDV, fNormal).Width;
                    g.DrawString(sDV, fNormal, Brushes.Black, x + w - 20 - wDV, y);
                    y += 30;

                    // --- TỔNG CỘNG ---
                    g.DrawLine(pThick, x, y, x + w, y);
                    y += 10;
                    decimal tong = Convert.ToDecimal(drv["TongTienThanhToan"]);
                    g.DrawString("TỔNG TIỀN THANH TOÁN:", fInfoBold, Brushes.Black, x + 10, y);

                    string sTong = tong.ToString("N0") + " VNĐ";
                    Font fTong = new Font("Arial", 14, FontStyle.Bold);
                    float wTong = g.MeasureString(sTong, fTong).Width;
                    g.DrawString(sTong, fTong, Brushes.Red, x + w - 20 - wTong, y);
                    y += 50;

                    // --- CHỮ KÝ ---
                    float xSig = x + w - 200;
                    g.DrawString("Người lập hóa đơn", fInfoBold, Brushes.Black, xSig, y);
                    y += 20;
                    g.DrawString("(Ký và ghi rõ họ tên)", fItalic, Brushes.Black, xSig, y);

                    y += 100;
                    string foot = "Cảm ơn Quý khách đã lựa chọn dịch vụ của chúng tôi!";
                    g.DrawString(foot, fItalic, Brushes.Gray, x + (w - g.MeasureString(foot, fItalic).Width) / 2, y);
                };

                using (PrintPreviewDialog pp = new PrintPreviewDialog())
                {
                    pp.Document = printDoc;
                    pp.WindowState = FormWindowState.Maximized;
                    pp.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private string[] BuildInvoiceLinesFromRow(DataRow row)
        {
            string maHD = row.Table.Columns.Contains("MaHD") ? row["MaHD"].ToString() : "";
            string tenPhong = row.Table.Columns.Contains("TenPhong") ? row["TenPhong"].ToString() : "";
            string hoTen = row.Table.Columns.Contains("HoTen") ? row["HoTen"].ToString() : "";
            string ngay = row.Table.Columns.Contains("NgayThanhToan") ? row["NgayThanhToan"].ToString() : "";
            string tienPhong = row.Table.Columns.Contains("TongTienPhong") ? row["TongTienPhong"].ToString() : "0";
            string tienDV = row.Table.Columns.Contains("TongTienDV") ? row["TongTienDV"].ToString() : "0";
            string tong = row.Table.Columns.Contains("TongTienThanhToan") ? row["TongTienThanhToan"].ToString() : "0";

            return new string[]
            {
                $"Mã HD: {maHD}",
                $"Khách hàng: {hoTen}",
                $"Phòng: {tenPhong}",
                $"Ngày TT: {ngay}",
                $"Tiền phòng: {tienPhong}",
                $"Tiền DV: {tienDV}",
                $"Tổng cộng: {tong}"
            };
        }

        // Xuất CSV (Excel mở được): lưu file do user chọn
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dgvHoaDon.DataSource as DataTable;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    FileName = "HoaDon_Export.csv",
                    Title = "Lưu file Excel (CSV)"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var sb = new StringBuilder();

                    // Header
                    var columnNames = dt.Columns.Cast<DataColumn>().Select(c => QuoteValue(c.ColumnName));
                    sb.AppendLine(string.Join(",", columnNames));

                    // Rows
                    foreach (DataRow row in dt.Rows)
                    {
                        var fields = dt.Columns.Cast<DataColumn>().Select(c => QuoteValue(row[c]?.ToString()));
                        sb.AppendLine(string.Join(",", fields));
                    }

                    // Ghi UTF-8 BOM để Excel nhận đúng encoding
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                    MessageBox.Show("Xuất file thành công: " + sfd.FileName, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string QuoteValue(string value)
        {
            if (value == null) return "\"\"";
            string escaped = value.Replace("\"", "\"\"");
            return $"\"{escaped}\"";
        }

        // Xóa hóa đơn được chọn — gọi qua BUS (GUI không gọi DAO trực tiếp)
        private void BtnXoaHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRowView drv = dgvHoaDon.CurrentRow.DataBoundItem as DataRowView;
                if (drv == null)
                {
                    MessageBox.Show("Không thể lấy thông tin hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = drv.Row;
                if (!row.Table.Columns.Contains("MaHD"))
                {
                    MessageBox.Show("Cột MaHD không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(row["MaHD"].ToString(), out int maHD))
                {
                    MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa hóa đơn {maHD}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // Gọi qua BUS để xóa
                bool ok = busHD.XoaHoaDon(maHD);
                if (ok)
                {
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh filter
                    btnLoc_Click(this, EventArgs.Empty);
                    HienThiDanhSachHD();
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTongTienDV_Click(object sender, EventArgs e)
        {

        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            // Lấy trực tiếp từ SelectedValue và ép kiểu an toàn
            if (cboPhieuThue.SelectedValue != null && int.TryParse(cboPhieuThue.SelectedValue.ToString(), out int maPhieu))
            {
                HoaDon_DTO hd = new HoaDon_DTO();
                hd.IMaPhieu = maPhieu;
                hd.DTongTienPhong = decimal.Parse(lblTongTienPhong.Text); // Lấy từ Label hiển thị
                hd.DTongTienDV = decimal.Parse(lblTongTienDV.Text);
                hd.DTongTienThanhToan = decimal.Parse(lblTongAll.Text);

                if (busHD.LuuHoaDon(hd))
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    LoadCboPhieuThue(); // Load lại danh sách để mất phiếu vừa thanh toán
                    HienThiDanhSachHD(); // Gọi hàm này để cập nhật lại GridView
                    LoadCboPhieuThue();  // Cập nhật lại ComboBox vì phiếu này đã thanh toán
                }
                else
                {
                    MessageBox.Show("Lưu thất bại. Vui lòng kiểm tra lại dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu thuê từ danh sách!");
            }
        }



        private void LoadPhieuThueChuaCoHoaDon()
        {
            // Lấy danh sách phiếu thuê chưa có hóa đơn từ BUS
            DataTable dt = busHD.LayPhieuThueChuaCoHoaDon();

            cboPhieuThue.DataSource = dt;
            cboPhieuThue.DisplayMember = "MaPhieu";   // Hiển thị mã phiếu
            cboPhieuThue.ValueMember = "MaPhieu";     // Giá trị thực là mã phiếu
        }

        private void cboPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra SelectedValue có thực sự là một giá trị đơn lẻ (không phải DataRowView)
            if (cboPhieuThue.SelectedValue != null && !(cboPhieuThue.SelectedValue is DataRowView))
            {
                try
                {
                    int maPhieuDangChon = Convert.ToInt32(cboPhieuThue.SelectedValue);

                    // Gọi BUS để lấy thông tin tiền
                    var (tPhong, tDV, tTong) = busHD.TinhTienTheoPhieu(maPhieuDangChon);

                    // Gán lên UI (Giả sử các biến dưới đây là TextBox hoặc Label)
                    tienPhong = tPhong;
                    tienDV = tDV;
                    tienThanhToan = tTong;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                }
            }
        }

        private void HienThiDanhSachHD()
        {
            List<HoaDon_DTO> ds = busHD.LayDanhSachHoaDon();
            dgvHoaDon.DataSource = ds;

            if (dgvHoaDon.ColumnCount > 0)
            {
                dgvHoaDon.Columns["IMaHD"].HeaderText = "Mã HD";
                dgvHoaDon.Columns["SHoTen"].HeaderText = "Khách Hàng";
                dgvHoaDon.Columns["STenPhong"].HeaderText = "Phòng";
                dgvHoaDon.Columns["DtNgayThanhToan"].HeaderText = "Ngày TT";
                dgvHoaDon.Columns["DTongTienPhong"].HeaderText = "Tiền Phòng";
                dgvHoaDon.Columns["DTongTienDV"].HeaderText = "Tiền DV";
                dgvHoaDon.Columns["DTongTienThanhToan"].HeaderText = "Tổng Cộng";

                // Định dạng số cho cột tiền (thêm dấu phẩy phân cách hàng nghìn)
                dgvHoaDon.Columns["DTongTienThanhToan"].DefaultCellStyle.Format = "N0";
            }
        }


    }
    
}