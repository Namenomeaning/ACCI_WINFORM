namespace ACCI_WINFORM.Forms
{
    partial class TraCuuPhieuDangKyForm
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
            groupBox1 = new GroupBox();
            btnTimKiem = new Button();
            txtMaPhieuDK = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtNgayTao = new TextBox();
            label3 = new Label();
            txtMaKhachHang = new TextBox();
            label5 = new Label();
            txtTenKhachHang = new TextBox();
            label6 = new Label();
            txtLoaiKhach = new TextBox();
            label7 = new Label();
            txtDienThoai = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label9 = new Label();
            txtDiaChi = new TextBox();
            label10 = new Label();
            txtTenDonVi = new TextBox();
            label11 = new Label();
            label2 = new Label();
            groupBox3 = new GroupBox();
            dgvChiTietPhieu = new DataGridView();
            btnTaoHoaDon = new Button();
            btnQuayLai = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(338, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(311, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TRA CỨU PHIẾU ĐĂNG KÝ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtMaPhieuDK);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 38);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(820, 54);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(429, 20);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(82, 22);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtMaPhieuDK
            // 
            txtMaPhieuDK.Location = new Point(145, 20);
            txtMaPhieuDK.Margin = new Padding(3, 2, 3, 2);
            txtMaPhieuDK.Name = "txtMaPhieuDK";
            txtMaPhieuDK.Size = new Size(260, 23);
            txtMaPhieuDK.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 22);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã phiếu đăng ký:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNgayTao);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtMaKhachHang);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtTenKhachHang);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtLoaiKhach);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtDienThoai);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtDiaChi);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtTenDonVi);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(10, 97);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(820, 146);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin phiếu đăng ký";
            // 
            // txtNgayTao
            // 
            txtNgayTao.Location = new Point(686, 59);
            txtNgayTao.Margin = new Padding(3, 2, 3, 2);
            txtNgayTao.Name = "txtNgayTao";
            txtNgayTao.ReadOnly = true;
            txtNgayTao.Size = new Size(120, 23);
            txtNgayTao.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(622, 62);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 1;
            label3.Text = "Ngày tạo:";
            label3.Click += label3_Click;
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Location = new Point(119, 55);
            txtMaKhachHang.Margin = new Padding(3, 2, 3, 2);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.ReadOnly = true;
            txtMaKhachHang.Size = new Size(180, 23);
            txtMaKhachHang.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(43, 57);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 5;
            label5.Text = "Mã khách:";
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Location = new Point(119, 80);
            txtTenKhachHang.Margin = new Padding(3, 2, 3, 2);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.ReadOnly = true;
            txtTenKhachHang.Size = new Size(180, 23);
            txtTenKhachHang.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 82);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 7;
            label6.Text = "Tên khách:";
            // 
            // txtLoaiKhach
            // 
            txtLoaiKhach.Location = new Point(119, 104);
            txtLoaiKhach.Margin = new Padding(3, 2, 3, 2);
            txtLoaiKhach.Name = "txtLoaiKhach";
            txtLoaiKhach.ReadOnly = true;
            txtLoaiKhach.Size = new Size(180, 23);
            txtLoaiKhach.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 106);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 9;
            label7.Text = "Loại khách:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(421, 55);
            txtDienThoai.Margin = new Padding(3, 2, 3, 2);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.ReadOnly = true;
            txtDienThoai.Size = new Size(180, 23);
            txtDienThoai.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(345, 57);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 11;
            label8.Text = "Điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(421, 80);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(180, 23);
            txtEmail.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(345, 82);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 13;
            label9.Text = "Email:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(421, 104);
            txtDiaChi.Margin = new Padding(3, 2, 3, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.Size = new Size(180, 23);
            txtDiaChi.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(345, 106);
            label10.Name = "label10";
            label10.Size = new Size(46, 15);
            label10.TabIndex = 15;
            label10.Text = "Địa chỉ:";
            // 
            // txtTenDonVi
            // 
            txtTenDonVi.Location = new Point(686, 98);
            txtTenDonVi.Margin = new Padding(3, 2, 3, 2);
            txtTenDonVi.Name = "txtTenDonVi";
            txtTenDonVi.ReadOnly = true;
            txtTenDonVi.Size = new Size(120, 23);
            txtTenDonVi.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(622, 101);
            label11.Name = "label11";
            label11.Size = new Size(64, 15);
            label11.TabIndex = 17;
            label11.Text = "Tên đơn vị:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(43, 30);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 0;
            label2.Text = "Thông tin khách hàng:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvChiTietPhieu);
            groupBox3.Location = new Point(10, 248);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(820, 194);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chi tiết phiếu đăng ký";
            // 
            // dgvChiTietPhieu
            // 
            dgvChiTietPhieu.AllowUserToAddRows = false;
            dgvChiTietPhieu.AllowUserToDeleteRows = false;
            dgvChiTietPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieu.Location = new Point(6, 20);
            dgvChiTietPhieu.Margin = new Padding(3, 2, 3, 2);
            dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            dgvChiTietPhieu.ReadOnly = true;
            dgvChiTietPhieu.RowHeadersWidth = 30;
            dgvChiTietPhieu.RowTemplate.Height = 25;
            dgvChiTietPhieu.Size = new Size(808, 170);
            dgvChiTietPhieu.TabIndex = 0;
            // 
            // btnTaoHoaDon
            // 
            btnTaoHoaDon.Enabled = false;
            btnTaoHoaDon.Location = new Point(645, 454);
            btnTaoHoaDon.Margin = new Padding(3, 2, 3, 2);
            btnTaoHoaDon.Name = "btnTaoHoaDon";
            btnTaoHoaDon.Size = new Size(92, 25);
            btnTaoHoaDon.TabIndex = 5;
            btnTaoHoaDon.Text = "Tạo hóa đơn";
            btnTaoHoaDon.UseVisualStyleBackColor = true;
            btnTaoHoaDon.Click += btnTaoHoaDon_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(740, 454);
            btnQuayLai.Margin = new Padding(3, 2, 3, 2);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(82, 25);
            btnQuayLai.TabIndex = 7;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // TraCuuPhieuDangKyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 490);
            Controls.Add(btnQuayLai);
            Controls.Add(btnTaoHoaDon);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TraCuuPhieuDangKyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra Cứu Phiếu Đăng Ký";
            FormClosed += MH_TraCuuPhieuDangKy_FormClosed;
            Load += MH_TraCuuPhieuDangKy_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtMaPhieuDK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenDonVi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLoaiKhach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgayTao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnQuayLai;
    }
}
