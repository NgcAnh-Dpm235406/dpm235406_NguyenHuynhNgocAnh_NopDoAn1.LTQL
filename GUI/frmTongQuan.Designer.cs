namespace GUI
{
    partial class frmTongQuan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPhongTrong = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPhongTrong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlPhongCoKhach = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCoKhach = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.plnPhongDaDat = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDaDat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.prpDanhSach = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgvDanhSach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCheckOutDuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPhongTrong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnlPhongCoKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.plnPhongDaDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            this.prpDanhSach.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPhongTrong
            // 
            this.pnlPhongTrong.BorderRadius = 10;
            this.pnlPhongTrong.BorderThickness = 2;
            this.pnlPhongTrong.Controls.Add(this.lblPhongTrong);
            this.pnlPhongTrong.Controls.Add(this.label1);
            this.pnlPhongTrong.Controls.Add(this.guna2PictureBox1);
            this.pnlPhongTrong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlPhongTrong.Location = new System.Drawing.Point(35, 53);
            this.pnlPhongTrong.Name = "pnlPhongTrong";
            this.pnlPhongTrong.Size = new System.Drawing.Size(167, 104);
            this.pnlPhongTrong.TabIndex = 0;
            // 
            // lblPhongTrong
            // 
            this.lblPhongTrong.AutoSize = true;
            this.lblPhongTrong.BackColor = System.Drawing.Color.Transparent;
            this.lblPhongTrong.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhongTrong.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPhongTrong.Location = new System.Drawing.Point(121, 83);
            this.lblPhongTrong.Name = "lblPhongTrong";
            this.lblPhongTrong.Size = new System.Drawing.Size(27, 19);
            this.lblPhongTrong.TabIndex = 2;
            this.lblPhongTrong.Text = "28";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phòng trống:";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 25;
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.giuong_removebg_preview;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(56, 7);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(66, 64);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // pnlPhongCoKhach
            // 
            this.pnlPhongCoKhach.BorderRadius = 10;
            this.pnlPhongCoKhach.BorderThickness = 2;
            this.pnlPhongCoKhach.Controls.Add(this.lblCoKhach);
            this.pnlPhongCoKhach.Controls.Add(this.label3);
            this.pnlPhongCoKhach.Controls.Add(this.guna2PictureBox2);
            this.pnlPhongCoKhach.FillColor = System.Drawing.Color.Red;
            this.pnlPhongCoKhach.Location = new System.Drawing.Point(241, 53);
            this.pnlPhongCoKhach.Name = "pnlPhongCoKhach";
            this.pnlPhongCoKhach.Size = new System.Drawing.Size(167, 104);
            this.pnlPhongCoKhach.TabIndex = 3;
            // 
            // lblCoKhach
            // 
            this.lblCoKhach.AutoSize = true;
            this.lblCoKhach.BackColor = System.Drawing.Color.Transparent;
            this.lblCoKhach.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoKhach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCoKhach.Location = new System.Drawing.Point(105, 81);
            this.lblCoKhach.Name = "lblCoKhach";
            this.lblCoKhach.Size = new System.Drawing.Size(18, 19);
            this.lblCoKhach.TabIndex = 2;
            this.lblCoKhach.Text = "6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Có khách:";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.BorderRadius = 25;
            this.guna2PictureBox2.Image = global::GUI.Properties.Resources.ck_removebg_preview;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(44, 0);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(75, 78);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 0;
            this.guna2PictureBox2.TabStop = false;
            // 
            // plnPhongDaDat
            // 
            this.plnPhongDaDat.BorderRadius = 10;
            this.plnPhongDaDat.BorderThickness = 2;
            this.plnPhongDaDat.Controls.Add(this.lblDaDat);
            this.plnPhongDaDat.Controls.Add(this.label4);
            this.plnPhongDaDat.Controls.Add(this.guna2PictureBox3);
            this.plnPhongDaDat.FillColor = System.Drawing.Color.Yellow;
            this.plnPhongDaDat.Location = new System.Drawing.Point(448, 56);
            this.plnPhongDaDat.Name = "plnPhongDaDat";
            this.plnPhongDaDat.Size = new System.Drawing.Size(167, 104);
            this.plnPhongDaDat.TabIndex = 4;
            // 
            // lblDaDat
            // 
            this.lblDaDat.AutoSize = true;
            this.lblDaDat.BackColor = System.Drawing.Color.Transparent;
            this.lblDaDat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaDat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDaDat.Location = new System.Drawing.Point(110, 82);
            this.lblDaDat.Name = "lblDaDat";
            this.lblDaDat.Size = new System.Drawing.Size(18, 19);
            this.lblDaDat.TabIndex = 2;
            this.lblDaDat.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(42, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Đã đặt:";
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.BorderRadius = 25;
            this.guna2PictureBox3.Image = global::GUI.Properties.Resources.dd_removebg_preview;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(53, 6);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(61, 62);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 0;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.lblDoanhThu);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox4);
            this.guna2Panel1.FillColor = System.Drawing.Color.SkyBlue;
            this.guna2Panel1.Location = new System.Drawing.Point(652, 53);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(168, 104);
            this.guna2Panel1.TabIndex = 5;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDoanhThu.Location = new System.Drawing.Point(89, 83);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(80, 19);
            this.lblDoanhThu.TabIndex = 2;
            this.lblDoanhThu.Text = "1,250,000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Doanh thu:";
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.BorderRadius = 25;
            this.guna2PictureBox4.Image = global::GUI.Properties.Resources.dt_removebg_preview;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(56, 3);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(63, 68);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox4.TabIndex = 0;
            this.guna2PictureBox4.TabStop = false;
            // 
            // prpDanhSach
            // 
            this.prpDanhSach.Controls.Add(this.guna2Panel1);
            this.prpDanhSach.Controls.Add(this.pnlPhongTrong);
            this.prpDanhSach.Controls.Add(this.plnPhongDaDat);
            this.prpDanhSach.Controls.Add(this.pnlPhongCoKhach);
            this.prpDanhSach.CustomBorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.prpDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.prpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.prpDanhSach.ForeColor = System.Drawing.Color.DarkBlue;
            this.prpDanhSach.Location = new System.Drawing.Point(0, 0);
            this.prpDanhSach.Name = "prpDanhSach";
            this.prpDanhSach.Size = new System.Drawing.Size(857, 163);
            this.prpDanhSach.TabIndex = 6;
            this.prpDanhSach.Text = "Danh sách";
            this.prpDanhSach.Click += new System.EventHandler(this.prpDanhSach_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.dgvDanhSach);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.guna2GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Navy;
            this.guna2GroupBox2.Location = new System.Drawing.Point(0, 163);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(857, 328);
            this.guna2GroupBox2.TabIndex = 7;
            this.guna2GroupBox2.Text = "Thông tin chi tiết";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDanhSach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.ColumnHeadersHeight = 22;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.TenPhong,
            this.TenLoai,
            this.HoTen,
            this.NgayCheckOutDuKien,
            this.TrangThai});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 40);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(857, 288);
            this.dgvDanhSach.TabIndex = 0;
            this.dgvDanhSach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDanhSach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDanhSach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDanhSach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDanhSach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDanhSach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDanhSach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDanhSach.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvDanhSach.ThemeStyle.ReadOnly = true;
            this.dgvDanhSach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDanhSach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDanhSach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvDanhSach.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDanhSach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhSach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.MinimumWidth = 6;
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Tên loại";
            this.TenLoai.MinimumWidth = 6;
            this.TenLoai.Name = "TenLoai";
            this.TenLoai.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách hàng";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // NgayCheckOutDuKien
            // 
            this.NgayCheckOutDuKien.DataPropertyName = "NgayCheckOutDuKien";
            this.NgayCheckOutDuKien.HeaderText = "Ngày trả";
            this.NgayCheckOutDuKien.MinimumWidth = 6;
            this.NgayCheckOutDuKien.Name = "NgayCheckOutDuKien";
            this.NgayCheckOutDuKien.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // frmTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(857, 491);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.prpDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTongQuan";
            this.Text = "frmTongQuan";
            this.pnlPhongTrong.ResumeLayout(false);
            this.pnlPhongTrong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnlPhongCoKhach.ResumeLayout(false);
            this.pnlPhongCoKhach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.plnPhongDaDat.ResumeLayout(false);
            this.plnPhongDaDat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            this.prpDanhSach.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }



        private Guna.UI2.WinForms.Guna2Panel pnlPhongTrong;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblPhongTrong;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlPhongCoKhach;
        private System.Windows.Forms.Label lblCoKhach;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Panel plnPhongDaDat;
        private System.Windows.Forms.Label lblDaDat;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Guna.UI2.WinForms.Guna2GroupBox prpDanhSach;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCheckOutDuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}