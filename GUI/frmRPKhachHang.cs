using Microsoft.Reporting.WinForms;
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

namespace GUI
{
    public partial class frmRPKhachHang : Form
    {
        public frmRPKhachHang()
        {
            InitializeComponent();
        }

        private void frmRPKhachHang_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=TenCSDL;Integrated Security=True"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaKH, HoTen, CCCD, SDT, DiaChi, QuocTich FROM KhachHang", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ReportDataSource rds = new ReportDataSource("DataSetKhachHang", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = "ReportKhachHang.rdlc";
                reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
