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
            lblTitle = new Label();
            groupBoxDangKy = new GroupBox();
            cbLoaiKhachHang = new ComboBox();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            txtDiaChi = new TextBox();
            txtHoTen = new TextBox();
            label11 = new Label();
            label5 = new Label();
            label4 = new Label();
            label9 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBoxDonVi = new GroupBox();
            txtTenDonVi = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            groupBoxDanhGia = new GroupBox();
            txtLichThiMongMuon = new TextBox();
            cbLichThi = new ComboBox();
            cbLoaiDanhGia = new ComboBox();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            groupBoxThiSinh = new GroupBox();
            dgvDanhSachThiSinh = new DataGridView();
            label15 = new Label();
            groupBoxThemThiSinh = new GroupBox();
            txtNgaySinhThiSinh = new TextBox();
            cbGioiTinhThiSinh = new ComboBox();
            txtTenThiSinh = new TextBox();
            btnXoaThiSinh = new Button();
            btnThemThiSinh = new Button();
            label19 = new Label();
            label18 = new Label();
            label3 = new Label();
            btnDangKy = new Button();
            btnHuy = new Button();
            groupBoxDangKy.SuspendLayout();
            groupBoxDonVi.SuspendLayout();
            groupBoxDanhGia.SuspendLayout();
            groupBoxThiSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            groupBoxThemThiSinh.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(338, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ";
            // 
            // groupBoxDangKy
            // 
            groupBoxDangKy.Controls.Add(cbLoaiKhachHang);
            groupBoxDangKy.Controls.Add(txtEmail);
            groupBoxDangKy.Controls.Add(txtSoDienThoai);
            groupBoxDangKy.Controls.Add(txtDiaChi);
            groupBoxDangKy.Controls.Add(txtHoTen);
            groupBoxDangKy.Controls.Add(label11);
            groupBoxDangKy.Controls.Add(label5);
            groupBoxDangKy.Controls.Add(label4);
            groupBoxDangKy.Controls.Add(label9);
            groupBoxDangKy.Controls.Add(label2);
            groupBoxDangKy.Controls.Add(label1);
            groupBoxDangKy.Location = new Point(10, 38);
            groupBoxDangKy.Margin = new Padding(3, 2, 3, 2);
            groupBoxDangKy.Name = "groupBoxDangKy";
            groupBoxDangKy.Padding = new Padding(3, 2, 3, 2);
            groupBoxDangKy.Size = new Size(400, 200);
            groupBoxDangKy.TabIndex = 1;
            groupBoxDangKy.TabStop = false;
            groupBoxDangKy.Text = "Đăng ký";
            // 
            // cbLoaiKhachHang
            // 
            cbLoaiKhachHang.FormattingEnabled = true;
            cbLoaiKhachHang.Location = new Point(145, 160);
            cbLoaiKhachHang.Margin = new Padding(3, 2, 3, 2);
            cbLoaiKhachHang.Name = "cbLoaiKhachHang";
            cbLoaiKhachHang.Size = new Size(230, 23);
            cbLoaiKhachHang.TabIndex = 17;
            cbLoaiKhachHang.SelectedIndexChanged += cbLoaiKhachHang_SelectedIndexChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 130);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 23);
            txtEmail.TabIndex = 14;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(145, 100);
            txtSoDienThoai.Margin = new Padding(3, 2, 3, 2);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(230, 23);
            txtSoDienThoai.TabIndex = 13;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(145, 70);
            txtDiaChi.Margin = new Padding(3, 2, 3, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(230, 23);
            txtDiaChi.TabIndex = 12;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(145, 40);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(230, 23);
            txtHoTen.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(20, 162);
            label11.Name = "label11";
            label11.Size = new Size(97, 15);
            label11.TabIndex = 10;
            label11.Text = "Loại khách hàng:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 132);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 4;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 102);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 3;
            label4.Text = "Số điện thoại:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 72);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 8;
            label9.Text = "Địa chỉ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 42);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ tên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 0;
            label1.Text = "Thông tin người đăng ký:";
            // 
            // groupBoxDonVi
            // 
            groupBoxDonVi.Controls.Add(txtTenDonVi);
            groupBoxDonVi.Controls.Add(label8);
            groupBoxDonVi.Controls.Add(label7);
            groupBoxDonVi.Controls.Add(label6);
            groupBoxDonVi.Location = new Point(10, 242);
            groupBoxDonVi.Margin = new Padding(3, 2, 3, 2);
            groupBoxDonVi.Name = "groupBoxDonVi";
            groupBoxDonVi.Padding = new Padding(3, 2, 3, 2);
            groupBoxDonVi.Size = new Size(400, 100);
            groupBoxDonVi.TabIndex = 2;
            groupBoxDonVi.TabStop = false;
            groupBoxDonVi.Text = "Thông tin đơn vị";
            // 
            // txtTenDonVi
            // 
            txtTenDonVi.Location = new Point(145, 60);
            txtTenDonVi.Margin = new Padding(3, 2, 3, 2);
            txtTenDonVi.Name = "txtTenDonVi";
            txtTenDonVi.Size = new Size(230, 23);
            txtTenDonVi.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 62);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 7;
            label8.Text = "Tên đơn vị:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(145, 40);
            label7.Name = "label7";
            label7.Size = new Size(82, 12);
            label7.TabIndex = 6;
            label7.Text = "*Dành cho đơn vị";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(10, 20);
            label6.Name = "label6";
            label6.Size = new Size(102, 15);
            label6.TabIndex = 5;
            label6.Text = "Thông tin đơn vị:";
            // 
            // groupBoxDanhGia
            // 
            groupBoxDanhGia.Controls.Add(txtLichThiMongMuon);
            groupBoxDanhGia.Controls.Add(cbLichThi);
            groupBoxDanhGia.Controls.Add(cbLoaiDanhGia);
            groupBoxDanhGia.Controls.Add(label17);
            groupBoxDanhGia.Controls.Add(label16);
            groupBoxDanhGia.Controls.Add(label14);
            groupBoxDanhGia.Controls.Add(label13);
            groupBoxDanhGia.Controls.Add(label12);
            groupBoxDanhGia.Location = new Point(430, 38);
            groupBoxDanhGia.Margin = new Padding(3, 2, 3, 2);
            groupBoxDanhGia.Name = "groupBoxDanhGia";
            groupBoxDanhGia.Padding = new Padding(3, 2, 3, 2);
            groupBoxDanhGia.Size = new Size(408, 150);
            groupBoxDanhGia.TabIndex = 3;
            groupBoxDanhGia.TabStop = false;
            groupBoxDanhGia.Text = "Thông tin đánh giá";
            // 
            // txtLichThiMongMuon
            // 
            txtLichThiMongMuon.Location = new Point(145, 110);
            txtLichThiMongMuon.Margin = new Padding(3, 2, 3, 2);
            txtLichThiMongMuon.Name = "txtLichThiMongMuon";
            txtLichThiMongMuon.Size = new Size(230, 23);
            txtLichThiMongMuon.TabIndex = 31;
            // 
            // cbLichThi
            // 
            cbLichThi.FormattingEnabled = true;
            cbLichThi.Location = new Point(145, 70);
            cbLichThi.Margin = new Padding(3, 2, 3, 2);
            cbLichThi.Name = "cbLichThi";
            cbLichThi.Size = new Size(230, 23);
            cbLichThi.TabIndex = 30;
            // 
            // cbLoaiDanhGia
            // 
            cbLoaiDanhGia.FormattingEnabled = true;
            cbLoaiDanhGia.Location = new Point(145, 30);
            cbLoaiDanhGia.Margin = new Padding(3, 2, 3, 2);
            cbLoaiDanhGia.Name = "cbLoaiDanhGia";
            cbLoaiDanhGia.Size = new Size(230, 23);
            cbLoaiDanhGia.TabIndex = 29;
            cbLoaiDanhGia.SelectedIndexChanged += cbLoaiDanhGia_SelectedIndexChanged_1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label17.ForeColor = Color.Red;
            label17.Location = new Point(145, 95);
            label17.Name = "label17";
            label17.Size = new Size(263, 12);
            label17.TabIndex = 23;
            label17.Text = "*Dành cho đơn vị, nhập theo format (dd/mm/yyyy HH:MM)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label16.ForeColor = Color.Red;
            label16.Location = new Point(145, 55);
            label16.Name = "label16";
            label16.Size = new Size(113, 12);
            label16.TabIndex = 22;
            label16.Text = "*Dành cho thí sinh tự do";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 112);
            label14.Name = "label14";
            label14.Size = new Size(85, 15);
            label14.TabIndex = 20;
            label14.Text = "Lịch thi đơn vị:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(20, 72);
            label13.Name = "label13";
            label13.Size = new Size(78, 15);
            label13.TabIndex = 19;
            label13.Text = "Chọn lịch thi:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(20, 32);
            label12.Name = "label12";
            label12.Size = new Size(130, 15);
            label12.TabIndex = 18;
            label12.Text = "Loại đánh giá năng lực:";
            // 
            // groupBoxThiSinh
            // 
            groupBoxThiSinh.Controls.Add(dgvDanhSachThiSinh);
            groupBoxThiSinh.Controls.Add(label15);
            groupBoxThiSinh.Location = new Point(430, 192);
            groupBoxThiSinh.Margin = new Padding(3, 2, 3, 2);
            groupBoxThiSinh.Name = "groupBoxThiSinh";
            groupBoxThiSinh.Padding = new Padding(3, 2, 3, 2);
            groupBoxThiSinh.Size = new Size(408, 150);
            groupBoxThiSinh.TabIndex = 4;
            groupBoxThiSinh.TabStop = false;
            groupBoxThiSinh.Text = "Danh sách thí sinh";
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.AllowUserToAddRows = false;
            dgvDanhSachThiSinh.AllowUserToDeleteRows = false;
            dgvDanhSachThiSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(6, 40);
            dgvDanhSachThiSinh.Margin = new Padding(3, 2, 3, 2);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.ReadOnly = true;
            dgvDanhSachThiSinh.RowHeadersWidth = 30;
            dgvDanhSachThiSinh.Size = new Size(388, 105);
            dgvDanhSachThiSinh.TabIndex = 24;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(10, 20);
            label15.Name = "label15";
            label15.Size = new Size(109, 15);
            label15.TabIndex = 21;
            label15.Text = "Danh sách thí sinh:";
            // 
            // groupBoxThemThiSinh
            // 
            groupBoxThemThiSinh.Controls.Add(txtNgaySinhThiSinh);
            groupBoxThemThiSinh.Controls.Add(cbGioiTinhThiSinh);
            groupBoxThemThiSinh.Controls.Add(txtTenThiSinh);
            groupBoxThemThiSinh.Controls.Add(btnXoaThiSinh);
            groupBoxThemThiSinh.Controls.Add(btnThemThiSinh);
            groupBoxThemThiSinh.Controls.Add(label19);
            groupBoxThemThiSinh.Controls.Add(label18);
            groupBoxThemThiSinh.Controls.Add(label3);
            groupBoxThemThiSinh.Location = new Point(10, 346);
            groupBoxThemThiSinh.Margin = new Padding(3, 2, 3, 2);
            groupBoxThemThiSinh.Name = "groupBoxThemThiSinh";
            groupBoxThemThiSinh.Padding = new Padding(3, 2, 3, 2);
            groupBoxThemThiSinh.Size = new Size(820, 80);
            groupBoxThemThiSinh.TabIndex = 5;
            groupBoxThemThiSinh.TabStop = false;
            groupBoxThemThiSinh.Text = "Thêm thí sinh";
            // 
            // txtNgaySinhThiSinh
            // 
            txtNgaySinhThiSinh.Location = new Point(310, 40);
            txtNgaySinhThiSinh.Margin = new Padding(3, 2, 3, 2);
            txtNgaySinhThiSinh.Name = "txtNgaySinhThiSinh";
            txtNgaySinhThiSinh.Size = new Size(100, 23);
            txtNgaySinhThiSinh.TabIndex = 35;
            // 
            // cbGioiTinhThiSinh
            // 
            cbGioiTinhThiSinh.FormattingEnabled = true;
            cbGioiTinhThiSinh.Location = new Point(460, 40);
            cbGioiTinhThiSinh.Margin = new Padding(3, 2, 3, 2);
            cbGioiTinhThiSinh.Name = "cbGioiTinhThiSinh";
            cbGioiTinhThiSinh.Size = new Size(100, 23);
            cbGioiTinhThiSinh.TabIndex = 34;
            cbGioiTinhThiSinh.SelectedIndexChanged += cbGioiTinhThiSinh_SelectedIndexChanged;
            // 
            // txtTenThiSinh
            // 
            txtTenThiSinh.Location = new Point(80, 40);
            txtTenThiSinh.Margin = new Padding(3, 2, 3, 2);
            txtTenThiSinh.Name = "txtTenThiSinh";
            txtTenThiSinh.Size = new Size(180, 23);
            txtTenThiSinh.TabIndex = 32;
            // 
            // btnXoaThiSinh
            // 
            btnXoaThiSinh.Location = new Point(750, 40);
            btnXoaThiSinh.Margin = new Padding(3, 2, 3, 2);
            btnXoaThiSinh.Name = "btnXoaThiSinh";
            btnXoaThiSinh.Size = new Size(60, 22);
            btnXoaThiSinh.TabIndex = 26;
            btnXoaThiSinh.Text = "Xóa";
            btnXoaThiSinh.UseVisualStyleBackColor = true;
            btnXoaThiSinh.Click += btnXoaThiSinh_Click_1;
            // 
            // btnThemThiSinh
            // 
            btnThemThiSinh.Location = new Point(640, 40);
            btnThemThiSinh.Margin = new Padding(3, 2, 3, 2);
            btnThemThiSinh.Name = "btnThemThiSinh";
            btnThemThiSinh.Size = new Size(100, 22);
            btnThemThiSinh.TabIndex = 25;
            btnThemThiSinh.Text = "Thêm thí sinh";
            btnThemThiSinh.UseVisualStyleBackColor = true;
            btnThemThiSinh.Click += btnThemThiSinh_Click_1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(460, 20);
            label19.Name = "label19";
            label19.Size = new Size(55, 15);
            label19.TabIndex = 38;
            label19.Text = "Giới tính:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(310, 20);
            label18.Name = "label18";
            label18.Size = new Size(63, 15);
            label18.TabIndex = 37;
            label18.Text = "Ngày sinh:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 20);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 36;
            label3.Text = "Họ tên:";
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(650, 440);
            btnDangKy.Margin = new Padding(3, 2, 3, 2);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(82, 25);
            btnDangKy.TabIndex = 27;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(740, 440);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(82, 25);
            btnHuy.TabIndex = 28;
            btnHuy.Text = "Quay lại";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click_1;
            // 
            // DangKyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 480);
            Controls.Add(btnHuy);
            Controls.Add(btnDangKy);
            Controls.Add(groupBoxThemThiSinh);
            Controls.Add(groupBoxThiSinh);
            Controls.Add(groupBoxDanhGia);
            Controls.Add(groupBoxDonVi);
            Controls.Add(groupBoxDangKy);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DangKyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký";
            groupBoxDangKy.ResumeLayout(false);
            groupBoxDangKy.PerformLayout();
            groupBoxDonVi.ResumeLayout(false);
            groupBoxDonVi.PerformLayout();
            groupBoxDanhGia.ResumeLayout(false);
            groupBoxDanhGia.PerformLayout();
            groupBoxThiSinh.ResumeLayout(false);
            groupBoxThiSinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            groupBoxThemThiSinh.ResumeLayout(false);
            groupBoxThemThiSinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupBoxDangKy;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label9;
        private Label label11;
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private ComboBox cbLoaiKhachHang;
        private GroupBox groupBoxDonVi;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtTenDonVi;
        private GroupBox groupBoxDanhGia;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label17;
        private ComboBox cbLoaiDanhGia;
        private ComboBox cbLichThi;
        private TextBox txtLichThiMongMuon;
        private GroupBox groupBoxThiSinh;
        private Label label15;
        private DataGridView dgvDanhSachThiSinh;
        private GroupBox groupBoxThemThiSinh;
        private Button btnThemThiSinh;
        private Button btnXoaThiSinh;
        private TextBox txtTenThiSinh;
        private ComboBox cbGioiTinhThiSinh;
        private TextBox txtNgaySinhThiSinh;
        private Label label3;
        private Label label18;
        private Label label19;
        private Button btnDangKy;
        private Button btnHuy;
    }
}
