namespace GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnThanhBen = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMainContent = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDichVu = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnHoaDon = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnQuanlyp = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDatPhong = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.plnTieuDe = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTieuDe = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlNoiDungChinh = new System.Windows.Forms.Panel();
            this.pnThanhBen.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.plnTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnThanhBen
            // 
            this.pnThanhBen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnThanhBen.BorderRadius = 15;
            this.pnThanhBen.Controls.Add(this.pnlMainContent);
            this.pnThanhBen.Controls.Add(this.guna2Panel1);
            this.pnThanhBen.CustomizableEdges.BottomLeft = false;
            this.pnThanhBen.CustomizableEdges.BottomRight = false;
            this.pnThanhBen.CustomizableEdges.TopLeft = false;
            this.pnThanhBen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnThanhBen.Location = new System.Drawing.Point(0, 0);
            this.pnThanhBen.Name = "pnThanhBen";
            this.pnThanhBen.Size = new System.Drawing.Size(194, 609);
            this.pnThanhBen.TabIndex = 0;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.btnTaiKhoan);
            this.pnlMainContent.Controls.Add(this.btnDichVu);
            this.pnlMainContent.Controls.Add(this.btnHoaDon);
            this.pnlMainContent.Controls.Add(this.btnKhachHang);
            this.pnlMainContent.Controls.Add(this.btnQuanlyp);
            this.pnlMainContent.Controls.Add(this.btnDatPhong);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 93);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(194, 357);
            this.pnlMainContent.TabIndex = 7;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTaiKhoan.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiKhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnTaiKhoan.Image = global::GUI.Properties.Resources.TK_removebg_preview;
            this.btnTaiKhoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.ImageOffset = new System.Drawing.Point(3, 19);
            this.btnTaiKhoan.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 262);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(194, 57);
            this.btnTaiKhoan.TabIndex = 11;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(0, -15);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDichVu.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDichVu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDichVu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDichVu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDichVu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDichVu.FillColor = System.Drawing.Color.Transparent;
            this.btnDichVu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnDichVu.Image = global::GUI.Properties.Resources.dv_removebg_preview;
            this.btnDichVu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDichVu.ImageOffset = new System.Drawing.Point(3, 19);
            this.btnDichVu.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDichVu.Location = new System.Drawing.Point(0, 211);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(194, 51);
            this.btnDichVu.TabIndex = 9;
            this.btnDichVu.Text = "Dịch vụ";
            this.btnDichVu.TextOffset = new System.Drawing.Point(0, -15);
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHoaDon.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDon.FillColor = System.Drawing.Color.Transparent;
            this.btnHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnHoaDon.Image = global::GUI.Properties.Resources.hd_removebg_preview;
            this.btnHoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHoaDon.ImageOffset = new System.Drawing.Point(3, 21);
            this.btnHoaDon.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHoaDon.Location = new System.Drawing.Point(0, 159);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(194, 52);
            this.btnHoaDon.TabIndex = 8;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.TextOffset = new System.Drawing.Point(0, -17);
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhachHang.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachHang.FillColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnKhachHang.Image = global::GUI.Properties.Resources.tk2_removebg_preview;
            this.btnKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.ImageOffset = new System.Drawing.Point(3, 19);
            this.btnKhachHang.ImageSize = new System.Drawing.Size(30, 30);
            this.btnKhachHang.Location = new System.Drawing.Point(0, 107);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(194, 52);
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.TextOffset = new System.Drawing.Point(0, -15);
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnQuanlyp
            // 
            this.btnQuanlyp.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnQuanlyp.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnQuanlyp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanlyp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanlyp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuanlyp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuanlyp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanlyp.FillColor = System.Drawing.Color.Transparent;
            this.btnQuanlyp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanlyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnQuanlyp.Image = global::GUI.Properties.Resources.pg;
            this.btnQuanlyp.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanlyp.ImageOffset = new System.Drawing.Point(3, 15);
            this.btnQuanlyp.ImageSize = new System.Drawing.Size(24, 24);
            this.btnQuanlyp.Location = new System.Drawing.Point(0, 55);
            this.btnQuanlyp.Name = "btnQuanlyp";
            this.btnQuanlyp.Size = new System.Drawing.Size(194, 52);
            this.btnQuanlyp.TabIndex = 6;
            this.btnQuanlyp.Text = "Quản lý phòng";
            this.btnQuanlyp.TextOffset = new System.Drawing.Point(0, -15);
            this.btnQuanlyp.Click += new System.EventHandler(this.btnQuanLyPhong_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDatPhong.CheckedState.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDatPhong.CheckedState.Image = global::GUI.Properties.Resources.tongquan;
            this.btnDatPhong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDatPhong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDatPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDatPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDatPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatPhong.FillColor = System.Drawing.Color.Transparent;
            this.btnDatPhong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.btnDatPhong.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDatPhong.Image = global::GUI.Properties.Resources.tq;
            this.btnDatPhong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDatPhong.ImageOffset = new System.Drawing.Point(10, 15);
            this.btnDatPhong.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDatPhong.Location = new System.Drawing.Point(0, 0);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(194, 55);
            this.btnDatPhong.TabIndex = 2;
            this.btnDatPhong.Text = "Đặt phòng";
            this.btnDatPhong.TextOffset = new System.Drawing.Point(0, -15);
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.LightBlue;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(194, 93);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(109, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hotel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(80, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phượng Hoàng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.logoph_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(-11, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // plnTieuDe
            // 
            this.plnTieuDe.BackColor = System.Drawing.Color.LightCyan;
            this.plnTieuDe.BorderThickness = 1;
            this.plnTieuDe.Controls.Add(this.btnDangXuat);
            this.plnTieuDe.Controls.Add(this.lblHoTen);
            this.plnTieuDe.Controls.Add(this.guna2PictureBox1);
            this.plnTieuDe.Controls.Add(this.lblTieuDe);
            this.plnTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.plnTieuDe.Location = new System.Drawing.Point(194, 0);
            this.plnTieuDe.Name = "plnTieuDe";
            this.plnTieuDe.Size = new System.Drawing.Size(875, 71);
            this.plnTieuDe.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BorderColor = System.Drawing.Color.Gray;
            this.btnDangXuat.BorderRadius = 8;
            this.btnDangXuat.BorderThickness = 1;
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.Gainsboro;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangXuat.ForeColor = System.Drawing.Color.Black;
            this.btnDangXuat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.btnDangXuat.Image = global::GUI.Properties.Resources.THOAT_removebg_preview;
            this.btnDangXuat.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDangXuat.Location = new System.Drawing.Point(724, 19);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(98, 40);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Logout";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(505, 33);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(123, 19);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Xin chào: Admin";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.QTV_removebg_preview;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(644, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(74, 66);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(22, 31);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(188, 21);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TỔNG QUAN HÔM NAY";
            // 
            // pnlNoiDungChinh
            // 
            this.pnlNoiDungChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDungChinh.Location = new System.Drawing.Point(194, 71);
            this.pnlNoiDungChinh.Name = "pnlNoiDungChinh";
            this.pnlNoiDungChinh.Padding = new System.Windows.Forms.Padding(10);
            this.pnlNoiDungChinh.Size = new System.Drawing.Size(875, 538);
            this.pnlNoiDungChinh.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 609);
            this.Controls.Add(this.pnlNoiDungChinh);
            this.Controls.Add(this.plnTieuDe);
            this.Controls.Add(this.pnThanhBen);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOTEL PHƯỢNG HOÀNG";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnThanhBen.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.plnTieuDe.ResumeLayout(false);
            this.plnTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnThanhBen;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel pnlMainContent;
        private Guna.UI2.WinForms.Guna2TileButton btnDichVu;
        private Guna.UI2.WinForms.Guna2TileButton btnHoaDon;
        private Guna.UI2.WinForms.Guna2TileButton btnKhachHang;
        private Guna.UI2.WinForms.Guna2TileButton btnQuanlyp;
        private Guna.UI2.WinForms.Guna2TileButton btnDatPhong;
        private Guna.UI2.WinForms.Guna2Panel plnTieuDe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTieuDe;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblHoTen;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private System.Windows.Forms.Panel pnlNoiDungChinh;
        private Guna.UI2.WinForms.Guna2TileButton btnTaiKhoan;
    }
}

