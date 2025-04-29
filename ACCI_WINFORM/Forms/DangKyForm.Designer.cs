namespace ACCI_WINFORM.Forms
{
    partial class DangKyForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtHoTen = new TextBox();
            txtDiaChi = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtTenDonVi = new TextBox();
            cbLoaiKhachHang = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            dgvDanhSachThiSinh = new DataGridView();
            btnThemThiSinh = new Button();
            btnXoaThiSinh = new Button();
            btnDangKy = new Button();
            btnHuy = new Button();
            cbLoaiDanhGia = new ComboBox();
            cbLichThi = new ComboBox();
            txtLichThiMongMuon = new TextBox();
            txtTenThiSinh = new TextBox();
            cbGioiTinhThiSinh = new ComboBox();
            txtNgaySinhThiSinh = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 68);
            label1.Name = "label1";
            label1.Size = new Size(312, 32);
            label1.TabIndex = 0;
            label1.Text = "Thông Tin Người Đăng Ký";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 132);
            label2.Name = "label2";
            label2.Size = new Size(90, 32);
            label2.TabIndex = 1;
            label2.Text = "Họ Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 238);
            label4.Name = "label4";
            label4.Size = new Size(57, 32);
            label4.TabIndex = 3;
            label4.Text = "SĐT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 294);
            label5.Name = "label5";
            label5.Size = new Size(71, 32);
            label5.TabIndex = 4;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(65, 486);
            label6.Name = "label6";
            label6.Size = new Size(215, 32);
            label6.TabIndex = 5;
            label6.Text = "Thông Tin Đơn Vị";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(65, 518);
            label7.Name = "label7";
            label7.Size = new Size(156, 25);
            label7.TabIndex = 6;
            label7.Text = "*Dành cho đơn vị";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(65, 557);
            label8.Name = "label8";
            label8.Size = new Size(132, 32);
            label8.TabIndex = 7;
            label8.Text = "Tên Đơn Vị";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(65, 191);
            label9.Name = "label9";
            label9.Size = new Size(91, 32);
            label9.TabIndex = 8;
            label9.Text = "Địa Chỉ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(65, 737);
            label10.Name = "label10";
            label10.Size = new Size(0, 32);
            label10.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(64, 349);
            label11.Name = "label11";
            label11.Size = new Size(193, 32);
            label11.TabIndex = 10;
            label11.Text = "Loại Khách Hàng";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(285, 134);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 39);
            txtHoTen.TabIndex = 11;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(285, 188);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(200, 39);
            txtDiaChi.TabIndex = 12;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(285, 238);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(200, 39);
            txtSoDienThoai.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(285, 294);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 39);
            txtEmail.TabIndex = 14;
            // 
            // txtTenDonVi
            // 
            txtTenDonVi.Location = new Point(285, 554);
            txtTenDonVi.Name = "txtTenDonVi";
            txtTenDonVi.Size = new Size(200, 39);
            txtTenDonVi.TabIndex = 15;
            // 
            // cbLoaiKhachHang
            // 
            cbLoaiKhachHang.FormattingEnabled = true;
            cbLoaiKhachHang.Location = new Point(285, 349);
            cbLoaiKhachHang.Name = "cbLoaiKhachHang";
            cbLoaiKhachHang.Size = new Size(200, 40);
            cbLoaiKhachHang.TabIndex = 17;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(733, 132);
            label12.Name = "label12";
            label12.Size = new Size(270, 32);
            label12.TabIndex = 18;
            label12.Text = "Loại Đánh Giá Năng Lực";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(733, 188);
            label13.Name = "label13";
            label13.Size = new Size(160, 32);
            label13.TabIndex = 19;
            label13.Text = "Chọn Lịch Thi";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(733, 267);
            label14.Name = "label14";
            label14.Size = new Size(165, 32);
            label14.TabIndex = 20;
            label14.Text = "Lịch thi đơn vị";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(733, 349);
            label15.Name = "label15";
            label15.Size = new Size(231, 32);
            label15.TabIndex = 21;
            label15.Text = "Danh Sách Thí Sinh";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label16.ForeColor = Color.Red;
            label16.Location = new Point(733, 220);
            label16.Name = "label16";
            label16.Size = new Size(214, 25);
            label16.TabIndex = 22;
            label16.Text = "*Dành cho thí sinh tự do";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            label17.ForeColor = Color.Red;
            label17.Location = new Point(733, 299);
            label17.Name = "label17";
            label17.Size = new Size(429, 25);
            label17.TabIndex = 23;
            label17.Text = "*Dành cho đơn vị, nhập theo format (dd/mm/yyyy)";
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(733, 384);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.RowHeadersWidth = 82;
            dgvDanhSachThiSinh.Size = new Size(646, 300);
            dgvDanhSachThiSinh.TabIndex = 24;
            // 
            // btnThemThiSinh
            // 
            btnThemThiSinh.Location = new Point(733, 761);
            btnThemThiSinh.Name = "btnThemThiSinh";
            btnThemThiSinh.Size = new Size(188, 46);
            btnThemThiSinh.TabIndex = 25;
            btnThemThiSinh.Text = "Thêm Thí Sinh";
            btnThemThiSinh.UseVisualStyleBackColor = true;
            btnThemThiSinh.Click += btnThemThiSinh_Click_1;
            // 
            // btnXoaThiSinh
            // 
            btnXoaThiSinh.Location = new Point(1229, 761);
            btnXoaThiSinh.Name = "btnXoaThiSinh";
            btnXoaThiSinh.Size = new Size(150, 46);
            btnXoaThiSinh.TabIndex = 26;
            btnXoaThiSinh.Text = "Xoá";
            btnXoaThiSinh.UseVisualStyleBackColor = true;
            btnXoaThiSinh.Click += btnXoaThiSinh_Click_1;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(733, 888);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 46);
            btnDangKy.TabIndex = 27;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(946, 888);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(150, 46);
            btnHuy.TabIndex = 28;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click_1;
            // 
            // cbLoaiDanhGia
            // 
            cbLoaiDanhGia.FormattingEnabled = true;
            cbLoaiDanhGia.Location = new Point(1033, 129);
            cbLoaiDanhGia.Name = "cbLoaiDanhGia";
            cbLoaiDanhGia.Size = new Size(200, 40);
            cbLoaiDanhGia.TabIndex = 29;
            // 
            // cbLichThi
            // 
            cbLichThi.FormattingEnabled = true;
            cbLichThi.Location = new Point(1033, 188);
            cbLichThi.Name = "cbLichThi";
            cbLichThi.Size = new Size(200, 40);
            cbLichThi.TabIndex = 30;
            // 
            // txtLichThiMongMuon
            // 
            txtLichThiMongMuon.Location = new Point(1033, 257);
            txtLichThiMongMuon.Name = "txtLichThiMongMuon";
            txtLichThiMongMuon.Size = new Size(200, 39);
            txtLichThiMongMuon.TabIndex = 31;
            // 
            // txtTenThiSinh
            // 
            txtTenThiSinh.Location = new Point(733, 706);
            txtTenThiSinh.Name = "txtTenThiSinh";
            txtTenThiSinh.Size = new Size(200, 39);
            txtTenThiSinh.TabIndex = 32;
            // 
            // cbGioiTinhThiSinh
            // 
            cbGioiTinhThiSinh.FormattingEnabled = true;
            cbGioiTinhThiSinh.Location = new Point(1179, 705);
            cbGioiTinhThiSinh.Name = "cbGioiTinhThiSinh";
            cbGioiTinhThiSinh.Size = new Size(200, 40);
            cbGioiTinhThiSinh.TabIndex = 34;
            // 
            // txtNgaySinhThiSinh
            // 
            txtNgaySinhThiSinh.Location = new Point(962, 706);
            txtNgaySinhThiSinh.Name = "txtNgaySinhThiSinh";
            txtNgaySinhThiSinh.Size = new Size(200, 39);
            txtNgaySinhThiSinh.TabIndex = 35;
            // 
            // DangKyForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1550, 982);
            Controls.Add(txtNgaySinhThiSinh);
            Controls.Add(cbGioiTinhThiSinh);
            Controls.Add(txtTenThiSinh);
            Controls.Add(txtLichThiMongMuon);
            Controls.Add(cbLichThi);
            Controls.Add(cbLoaiDanhGia);
            Controls.Add(btnHuy);
            Controls.Add(btnDangKy);
            Controls.Add(btnXoaThiSinh);
            Controls.Add(btnThemThiSinh);
            Controls.Add(dgvDanhSachThiSinh);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(cbLoaiKhachHang);
            Controls.Add(txtTenDonVi);
            Controls.Add(txtEmail);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtDiaChi);
            Controls.Add(txtHoTen);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DangKyForm";
            Text = "DangKyForm";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtTenDonVi;
        private TextBox txtDiaChi;
        private ComboBox cbLoaiKhachHang;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private DataGridView dgvDanhSachThiSinh;
        private Button btnThemThiSinh;
        private Button btnXoaThiSinh;
        private Button btnDangKy;
        private Button btnHuy;
        private ComboBox cbLoaiDanhGia;
        private ComboBox cbLichThi;
        private TextBox txtLichThiMongMuon;
        private TextBox txtTenThiSinh;
        private ComboBox cbGioiTinhThiSinh;
        private TextBox txtNgaySinhThiSinh;
    }
}