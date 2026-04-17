using BUS;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoaDon : Form
    {
        HoaDon_BUS busHD = new HoaDon_BUS();

        private void LoadData()
        {
            try
            {
                DateTime tu = dtpTuNgay.Value;
                DateTime den = dtpDenNgay.Value;
                string ten = txtTimKiem.Text.Trim();

                // Bây giờ hàm này sẽ hết lỗi đỏ
                DataTable dt = busHD.LayDSHoaDon(tu, den, ten);

                if (dt != null)
                {
                    dgvHoaDon.DataSource = dt;
                    TinhTongTien(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void TinhTongTien(DataTable dt)
        {
            decimal sumPhong = 0, sumDV = 0, sumTong = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumPhong += Convert.ToDecimal(dr["TongTienPhong"]);
                sumDV += Convert.ToDecimal(dr["TongTienDV"]);
                sumTong += Convert.ToDecimal(dr["TongTienThanhToan"]);
            }

            // Gán vào các Label trên giao diện (kiểm tra lại tên Label trong Designer)
            lblTongCong.Text = sumPhong.ToString("N0") + " VNĐ";
            lblTongTienDV.Text = sumDV.ToString("N0") + " VNĐ";
            lblTongThanhToan.Text = sumTong.ToString("N0") + " VNĐ";
        }

        // Các sự kiện nút bấm giữ nguyên như code cũ bạn đã viết
    }
}