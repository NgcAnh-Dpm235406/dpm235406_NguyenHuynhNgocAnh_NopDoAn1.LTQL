using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmDichVu : Form
    {
        bool isMaValid = false;
        bool isTenValid = false;
        
        SqlConnection sqlCon = null;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();

           
        }

        private void LoadData()
        {
            dgvDichVu.DataSource = DichVu_BUS.LayDanhSachDichVu();
            dgvDichVu.Columns["IMaDV"].HeaderText = "Mã DV";
            dgvDichVu.Columns["STenDV"].HeaderText = "Tên DV";
            dgvDichVu.Columns["DGiaDV"].HeaderText = "Đơn giá";
            dgvDichVu.Columns["SDonViTinh"].HeaderText = "Đơn vị tính";
            dgvDichVu.Columns["IMaPhong"].HeaderText = "Mã phòng";
            dgvDichVu.Columns["STenPhong"].HeaderText = "Tên phòng";

            cboPhong.DataSource = Phong_BUS.LayDanhSachPhong();
            cboPhong.DisplayMember = "STenPhong";
            cboPhong.ValueMember = "IMaPhong";
            cboDonViTinh.DataSource = DichVu_BUS.LayDanhSachDonViTinh();
            cboDonViTinh.SelectedIndex = -1;

            // 3. Để trống khi mới load (tùy chọn)
            cboDonViTinh.SelectedIndex = -1;
        }
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["IMaDV"].Value.ToString();
                txtTenDV.Text = row.Cells["STenDV"].Value.ToString();
                txtDonGia.Text = row.Cells["DGiaDV"].Value.ToString();
                cboDonViTinh.Text = row.Cells["SDonViTinh"].Value.ToString();
                cboPhong.SelectedValue = row.Cells["IMaPhong"].Value;

                // Xử lý ComboBox Đơn vị tính
                // Gán Đơn vị tính
                if (row.Cells["SDonViTinh"].Value != null)
                {
                    // Vì DataSource của cbo là List<string> nên ta dùng .Text là nhanh nhất
                    cboDonViTinh.Text = row.Cells["SDonViTinh"].Value.ToString();
                }

                // Gán Phòng
                cboPhong.SelectedValue = row.Cells["IMaPhong"].Value;
            }

        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào cơ bản
            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá!");
                return;
            }
            if (string.IsNullOrWhiteSpace(cboDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính!");
                return;
            }

            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }
            // 2. Tạo DTO
            DichVu_DTO dv = new DichVu_DTO
            {
                STenDV = txtTenDV.Text.Trim(),
                DGiaDV = decimal.Parse(txtDonGia.Text),
                SDonViTinh = cboDonViTinh.Text.Trim()
            };

            // 3. Xử lý chọn phòng
            if (cboPhong.SelectedValue != null)
            {
                dv.IMaPhong = int.Parse(cboPhong.SelectedValue.ToString());
            }
            else
            {
                dv.IMaPhong = 0; // hoặc để NULL trong DB nếu là dịch vụ chung
            }

            // 4. Gọi BUS để thêm
            if (DichVu_BUS.ThemDichVu(dv))
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                LoadData(); // reload lại dgv
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!");
            }

            // Gọi sang form Hóa đơn để refresh tổng tiền DV
            frmHoaDon hoaDonForm = Application.OpenForms["frmHoaDon"] as frmHoaDon;
            if (hoaDonForm != null)
            {
                hoaDonForm.LoadDSHoaDon();
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!");
                return;
            }

            // Mở khóa các ô để người dùng nhập
            txtTenDV.ReadOnly = false;
            txtDonGia.ReadOnly = false;
            cboDonViTinh.Enabled = true;
            cboPhong.Enabled = true;

            MessageBox.Show("Bạn có thể sửa thông tin, sau đó nhấn LƯU để cập nhật.");
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maDV = int.Parse(txtMaDV.Text);
            if (MessageBox.Show("Xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (DichVu_BUS.XoaDichVu(maDV))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void KiemTraBatNutLuu()
        {
            bool isDonViValid = !string.IsNullOrWhiteSpace(cboDonViTinh.Text);
            //btnLuu.Enabled = isMaValid && isTenValid && isDonViValid;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            string sDonGia = txtDonGia.Text.Replace(",", "").Replace("VNĐ", "").Trim();
            decimal giaDV;
            if (!decimal.TryParse(sDonGia, out giaDV))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            DichVu_DTO dv = new DichVu_DTO
            {
                IMaDV = int.Parse(txtMaDV.Text),
                STenDV = txtTenDV.Text.Trim(),
                DGiaDV = giaDV,
                SDonViTinh = cboDonViTinh.Text.Trim(),
                IMaPhong = int.Parse(cboPhong.SelectedValue.ToString())
            };

            if (DichVu_BUS.SuaDichVu(dv))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();

                // Khóa lại các ô sau khi lưu
                txtTenDV.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                cboDonViTinh.Enabled = false;
                cboPhong.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }

            // Refresh hóa đơn
            frmHoaDon hoaDonForm = Application.OpenForms["frmHoaDon"] as frmHoaDon;
            if (hoaDonForm != null)
            {
                hoaDonForm.LoadDSHoaDon();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
