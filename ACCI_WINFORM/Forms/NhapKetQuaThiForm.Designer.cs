namespace ACCI_WINFORM.Forms
{
    partial class NhapKetQuaThiForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtMaLichThi = new TextBox();
            txtTenDanhGia = new TextBox();
            btnTimKiem = new Button();
            dgvDanhSachThiSinh = new DataGridView();
            txtMaThiSinh = new TextBox();
            txtHoTen = new TextBox();
            txtSoBaoDanh = new TextBox();
            txtNgayThi = new TextBox();
            txtDiem = new TextBox();
            btnLuuDiem = new Button();
            lblTrangThai = new Label();
            label9 = new Label();
            label10 = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(42, 32);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 0;
            label1.Text = "Thông tin thí sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 27);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 1;
            label2.Text = "Mã Lịch Thi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 81);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 3;
            label3.Text = "Mã Thí Sinh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 125);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(67, 25);
            label4.TabIndex = 4;
            label4.Text = "Họ Tên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 168);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(115, 25);
            label5.TabIndex = 5;
            label5.Text = "Số Báo Danh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 211);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(82, 25);
            label6.TabIndex = 6;
            label6.Text = "Ngày Thi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(104, 364);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 25);
            label7.TabIndex = 7;
            label7.Text = "Điểm Số";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 299);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(115, 25);
            label8.TabIndex = 8;
            label8.Text = "Tên Đánh Giá";
            // 
            // txtMaLichThi
            // 
            txtMaLichThi.Location = new Point(539, 24);
            txtMaLichThi.Margin = new Padding(2);
            txtMaLichThi.Name = "txtMaLichThi";
            txtMaLichThi.Size = new Size(155, 31);
            txtMaLichThi.TabIndex = 9;
            // 
            // txtTenDanhGia
            // 
            txtTenDanhGia.Location = new Point(211, 299);
            txtTenDanhGia.Margin = new Padding(2);
            txtTenDanhGia.Name = "txtTenDanhGia";
            txtTenDanhGia.ReadOnly = true;
            txtTenDanhGia.Size = new Size(155, 31);
            txtTenDanhGia.TabIndex = 10;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(776, 21);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(115, 36);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(411, 96);
            dgvDanhSachThiSinh.Margin = new Padding(2);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.RowHeadersWidth = 82;
            dgvDanhSachThiSinh.Size = new Size(586, 234);
            dgvDanhSachThiSinh.TabIndex = 12;
            dgvDanhSachThiSinh.SelectionChanged += dgvDanhSachThiSinh_SelectionChanged;
            // 
            // txtMaThiSinh
            // 
            txtMaThiSinh.Location = new Point(211, 81);
            txtMaThiSinh.Margin = new Padding(2);
            txtMaThiSinh.Name = "txtMaThiSinh";
            txtMaThiSinh.ReadOnly = true;
            txtMaThiSinh.Size = new Size(155, 31);
            txtMaThiSinh.TabIndex = 13;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(211, 125);
            txtHoTen.Margin = new Padding(2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(155, 31);
            txtHoTen.TabIndex = 14;
            // 
            // txtSoBaoDanh
            // 
            txtSoBaoDanh.Location = new Point(211, 168);
            txtSoBaoDanh.Margin = new Padding(2);
            txtSoBaoDanh.Name = "txtSoBaoDanh";
            txtSoBaoDanh.ReadOnly = true;
            txtSoBaoDanh.Size = new Size(155, 31);
            txtSoBaoDanh.TabIndex = 15;
            // 
            // txtNgayThi
            // 
            txtNgayThi.Location = new Point(211, 211);
            txtNgayThi.Margin = new Padding(2);
            txtNgayThi.Name = "txtNgayThi";
            txtNgayThi.ReadOnly = true;
            txtNgayThi.Size = new Size(155, 31);
            txtNgayThi.TabIndex = 16;
            // 
            // txtDiem
            // 
            txtDiem.Location = new Point(211, 358);
            txtDiem.Margin = new Padding(2);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(155, 31);
            txtDiem.TabIndex = 17;
            // 
            // btnLuuDiem
            // 
            btnLuuDiem.Location = new Point(436, 358);
            btnLuuDiem.Margin = new Padding(2);
            btnLuuDiem.Name = "btnLuuDiem";
            btnLuuDiem.Size = new Size(115, 36);
            btnLuuDiem.TabIndex = 18;
            btnLuuDiem.Text = "Lưu Điểm";
            btnLuuDiem.UseVisualStyleBackColor = true;
            btnLuuDiem.Click += btnLuuDiem_Click;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(50, 664);
            lblTrangThai.Margin = new Padding(2, 0, 2, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 25);
            lblTrangThai.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(31, 265);
            label9.Name = "label9";
            label9.Size = new Size(158, 25);
            label9.TabIndex = 20;
            label9.Text = "Thông tin lịch thi";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(409, 69);
            label10.Name = "label10";
            label10.Size = new Size(277, 25);
            label10.TabIndex = 21;
            label10.Text = "Chọn Thí sinh muốn nhập điểm";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(751, 381);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(170, 40);
            btnBack.TabIndex = 20;
            btnBack.Text = "Quay Lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // NhapKetQuaThiForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 442);
            Controls.Add(btnBack);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(lblTrangThai);
            Controls.Add(btnLuuDiem);
            Controls.Add(txtDiem);
            Controls.Add(txtNgayThi);
            Controls.Add(txtSoBaoDanh);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaThiSinh);
            Controls.Add(dgvDanhSachThiSinh);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTenDanhGia);
            Controls.Add(txtMaLichThi);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "NhapKetQuaThiForm";
            Text = "Nhập Kết Quả Thi";
            Load += NhapKetQuaThiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtMaLichThi;
        private TextBox txtTenDanhGia;
        private Button btnTimKiem;
        private DataGridView dgvDanhSachThiSinh;
        private TextBox txtMaThiSinh;
        private TextBox txtHoTen;
        private TextBox txtSoBaoDanh;
        private TextBox txtNgayThi;
        private TextBox txtDiem;
        private Button btnLuuDiem;
        private Label lblTrangThai;
        private Label label9;
        private Label label10;
        private Button btnBack;
    }
}