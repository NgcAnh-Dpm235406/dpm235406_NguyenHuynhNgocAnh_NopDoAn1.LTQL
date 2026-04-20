using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace GUI
{
    public partial class frmReportHoaDon : Form
    {
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void frmReportHoaDon_Load(object sender, EventArgs e)
        {
            // Khi form load, chưa hiển thị gì
            reportViewer1.RefreshReport();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLKS3;Integrated Security=True"))
            {
                string input = txtMaPhieu.Text.Trim();
                string sql;

                // Tạo lệnh SQL linh hoạt
                if (string.IsNullOrEmpty(input))
                {
                    // Nếu để trống TextBox -> Xem tất cả hóa đơn
                    sql = "SELECT MaHD, MaPhieu, NgayThanhToan, TongTienPhong, TongTienDV, TongTienThanhToan FROM HoaDon";
                }
                else
                {
                    // Nếu nhập "1, 2, 3" -> Lấy các hóa đơn có mã nằm trong danh sách đó
                    // Lưu ý: SQL toán tử IN cần định dạng: MaPhieu IN (1, 2, 3)
                    sql = "SELECT MaHD, MaPhieu, NgayThanhToan, TongTienPhong, TongTienDV, TongTienThanhToan FROM HoaDon WHERE MaPhieu IN (" + input + ")";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);

                    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.LocalReport.ReportPath = "ReportHoaDon.rdlc";

                    // XỬ LÝ PARAMETER: 
                    // Khi xem nhiều, ta đổi chữ hiển thị trên báo cáo cho phù hợp
                    string hiểnThịMã = string.IsNullOrEmpty(input) ? "Tất cả" : input;
                    ReportParameter[] parameters = new ReportParameter[]
                    {
                new ReportParameter("MaPhieu", hiểnThịMã)
                    };

                    reportViewer1.LocalReport.SetParameters(parameters);

                    // Tự động phóng to cho đẹp
                    reportViewer1.ZoomMode = ZoomMode.PageWidth;
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập liệu: Hãy đảm bảo các mã cách nhau bằng dấu phẩy (vd: 1,2,3)\nChi tiết: " + ex.Message);
                }
            }
        }
    }
}
