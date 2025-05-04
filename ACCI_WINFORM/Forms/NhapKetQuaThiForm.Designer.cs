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
            lblTitle = new Label();
            groupBoxTimKiem = new GroupBox();
            btnTimKiem = new Button();
            txtMaLichThi = new TextBox();
            label2 = new Label();
            groupBoxThongTin = new GroupBox();
            txtNgayThi = new TextBox();
            label6 = new Label();
            txtSoBaoDanh = new TextBox();
            label5 = new Label();
            txtHoTen = new TextBox();
            label4 = new Label();
            txtMaThiSinh = new TextBox();
            label3 = new Label();
            label1 = new Label();
            groupBoxKetQua = new GroupBox();
            btnLuuDiem = new Button();
            txtDiem = new TextBox();
            label7 = new Label();
            txtTenDanhGia = new TextBox();
            label8 = new Label();
            label9 = new Label();
            groupBoxDanhSach = new GroupBox();
            label10 = new Label();
            dgvDanhSachThiSinh = new DataGridView();
            lblTrangThai = new Label();
            btnBack = new Button();
            groupBoxTimKiem.SuspendLayout();
            groupBoxThongTin.SuspendLayout();
            groupBoxKetQua.SuspendLayout();
            groupBoxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(338, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(231, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NHẬP KẾT QUẢ THI";
            // 
            // groupBoxTimKiem
            // 
            groupBoxTimKiem.Controls.Add(btnTimKiem);
            groupBoxTimKiem.Controls.Add(txtMaLichThi);
            groupBoxTimKiem.Controls.Add(label2);
            groupBoxTimKiem.Location = new Point(10, 38);
            groupBoxTimKiem.Margin = new Padding(3, 2, 3, 2);
            groupBoxTimKiem.Name = "groupBoxTimKiem";
            groupBoxTimKiem.Padding = new Padding(3, 2, 3, 2);
            groupBoxTimKiem.Size = new Size(820, 54);
            groupBoxTimKiem.TabIndex = 1;
            groupBoxTimKiem.TabStop = false;
            groupBoxTimKiem.Text = "Tìm kiếm";
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
            // txtMaLichThi
            // 
            txtMaLichThi.Location = new Point(145, 20);
            txtMaLichThi.Margin = new Padding(3, 2, 3, 2);
            txtMaLichThi.Name = "txtMaLichThi";
            txtMaLichThi.Size = new Size(260, 23);
            txtMaLichThi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 22);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 0;
            label2.Text = "Mã lịch thi:";
            // 
            // groupBoxThongTin
            // 
            groupBoxThongTin.Controls.Add(txtNgayThi);
            groupBoxThongTin.Controls.Add(label6);
            groupBoxThongTin.Controls.Add(txtSoBaoDanh);
            groupBoxThongTin.Controls.Add(label5);
            groupBoxThongTin.Controls.Add(txtHoTen);
            groupBoxThongTin.Controls.Add(label4);
            groupBoxThongTin.Controls.Add(txtMaThiSinh);
            groupBoxThongTin.Controls.Add(label3);
            groupBoxThongTin.Controls.Add(label1);
            groupBoxThongTin.Location = new Point(10, 97);
            groupBoxThongTin.Margin = new Padding(3, 2, 3, 2);
            groupBoxThongTin.Name = "groupBoxThongTin";
            groupBoxThongTin.Padding = new Padding(3, 2, 3, 2);
            groupBoxThongTin.Size = new Size(350, 150);
            groupBoxThongTin.TabIndex = 2;
            groupBoxThongTin.TabStop = false;
            groupBoxThongTin.Text = "Thông tin thí sinh";
            // 
            // txtNgayThi
            // 
            txtNgayThi.Location = new Point(133, 116);
            txtNgayThi.Margin = new Padding(3, 2, 3, 2);
            txtNgayThi.Name = "txtNgayThi";
            txtNgayThi.ReadOnly = true;
            txtNgayThi.Size = new Size(180, 23);
            txtNgayThi.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 118);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 6;
            label6.Text = "Ngày thi:";
            // 
            // txtSoBaoDanh
            // 
            txtSoBaoDanh.Location = new Point(133, 89);
            txtSoBaoDanh.Margin = new Padding(3, 2, 3, 2);
            txtSoBaoDanh.Name = "txtSoBaoDanh";
            txtSoBaoDanh.ReadOnly = true;
            txtSoBaoDanh.Size = new Size(180, 23);
            txtSoBaoDanh.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 91);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 5;
            label5.Text = "Số báo danh:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(133, 62);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(180, 23);
            txtHoTen.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 64);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 4;
            label4.Text = "Họ tên:";
            // 
            // txtMaThiSinh
            // 
            txtMaThiSinh.Location = new Point(133, 35);
            txtMaThiSinh.Margin = new Padding(3, 2, 3, 2);
            txtMaThiSinh.Name = "txtMaThiSinh";
            txtMaThiSinh.ReadOnly = true;
            txtMaThiSinh.Size = new Size(180, 23);
            txtMaThiSinh.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 37);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 3;
            label3.Text = "Mã thí sinh:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(20, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // groupBoxKetQua
            // 
            groupBoxKetQua.Controls.Add(btnLuuDiem);
            groupBoxKetQua.Controls.Add(txtDiem);
            groupBoxKetQua.Controls.Add(label7);
            groupBoxKetQua.Controls.Add(txtTenDanhGia);
            groupBoxKetQua.Controls.Add(label8);
            groupBoxKetQua.Controls.Add(label9);
            groupBoxKetQua.Location = new Point(10, 252);
            groupBoxKetQua.Margin = new Padding(3, 2, 3, 2);
            groupBoxKetQua.Name = "groupBoxKetQua";
            groupBoxKetQua.Padding = new Padding(3, 2, 3, 2);
            groupBoxKetQua.Size = new Size(350, 130);
            groupBoxKetQua.TabIndex = 3;
            groupBoxKetQua.TabStop = false;
            groupBoxKetQua.Text = "Nhập kết quả";
            // 
            // btnLuuDiem
            // 
            btnLuuDiem.Location = new Point(231, 89);
            btnLuuDiem.Margin = new Padding(3, 2, 3, 2);
            btnLuuDiem.Name = "btnLuuDiem";
            btnLuuDiem.Size = new Size(82, 22);
            btnLuuDiem.TabIndex = 18;
            btnLuuDiem.Text = "Lưu điểm";
            btnLuuDiem.UseVisualStyleBackColor = true;
            btnLuuDiem.Click += btnLuuDiem_Click;
            // 
            // txtDiem
            // 
            txtDiem.Location = new Point(133, 62);
            txtDiem.Margin = new Padding(3, 2, 3, 2);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(180, 23);
            txtDiem.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 64);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 7;
            label7.Text = "Điểm số:";
            // 
            // txtTenDanhGia
            // 
            txtTenDanhGia.Location = new Point(133, 35);
            txtTenDanhGia.Margin = new Padding(3, 2, 3, 2);
            txtTenDanhGia.Name = "txtTenDanhGia";
            txtTenDanhGia.ReadOnly = true;
            txtTenDanhGia.Size = new Size(180, 23);
            txtTenDanhGia.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 37);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 8;
            label8.Text = "Tên đánh giá:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(20, 0);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 20;
            // 
            // groupBoxDanhSach
            // 
            groupBoxDanhSach.Controls.Add(label10);
            groupBoxDanhSach.Controls.Add(dgvDanhSachThiSinh);
            groupBoxDanhSach.Location = new Point(370, 97);
            groupBoxDanhSach.Margin = new Padding(3, 2, 3, 2);
            groupBoxDanhSach.Name = "groupBoxDanhSach";
            groupBoxDanhSach.Padding = new Padding(3, 2, 3, 2);
            groupBoxDanhSach.Size = new Size(460, 285);
            groupBoxDanhSach.TabIndex = 4;
            groupBoxDanhSach.TabStop = false;
            groupBoxDanhSach.Text = "Danh sách thí sinh";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(10, 19);
            label10.Name = "label10";
            label10.Size = new Size(172, 15);
            label10.TabIndex = 21;
            label10.Text = "Chọn thí sinh muốn nhập điểm";
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.AllowUserToAddRows = false;
            dgvDanhSachThiSinh.AllowUserToDeleteRows = false;
            dgvDanhSachThiSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(10, 37);
            dgvDanhSachThiSinh.Margin = new Padding(3, 2, 3, 2);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.ReadOnly = true;
            dgvDanhSachThiSinh.RowHeadersWidth = 30;
            dgvDanhSachThiSinh.Size = new Size(440, 240);
            dgvDanhSachThiSinh.TabIndex = 12;
            dgvDanhSachThiSinh.SelectionChanged += dgvDanhSachThiSinh_SelectionChanged;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(10, 390);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(0, 15);
            lblTrangThai.TabIndex = 19;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(740, 390);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(82, 25);
            btnBack.TabIndex = 20;
            btnBack.Text = "Quay lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // NhapKetQuaThiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 420);
            Controls.Add(btnBack);
            Controls.Add(lblTrangThai);
            Controls.Add(groupBoxDanhSach);
            Controls.Add(groupBoxKetQua);
            Controls.Add(groupBoxThongTin);
            Controls.Add(groupBoxTimKiem);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NhapKetQuaThiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập Kết Quả Thi";
            Load += NhapKetQuaThiForm_Load;
            groupBoxTimKiem.ResumeLayout(false);
            groupBoxTimKiem.PerformLayout();
            groupBoxThongTin.ResumeLayout(false);
            groupBoxThongTin.PerformLayout();
            groupBoxKetQua.ResumeLayout(false);
            groupBoxKetQua.PerformLayout();
            groupBoxDanhSach.ResumeLayout(false);
            groupBoxDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupBoxTimKiem;
        private Button btnTimKiem;
        private TextBox txtMaLichThi;
        private Label label2;
        private GroupBox groupBoxThongTin;
        private TextBox txtNgayThi;
        private Label label6;
        private TextBox txtSoBaoDanh;
        private Label label5;
        private TextBox txtHoTen;
        private Label label4;
        private TextBox txtMaThiSinh;
        private Label label3;
        private Label label1;
        private GroupBox groupBoxKetQua;
        private Button btnLuuDiem;
        private TextBox txtDiem;
        private Label label7;
        private TextBox txtTenDanhGia;
        private Label label8;
        private Label label9;
        private GroupBox groupBoxDanhSach;
        private Label label10;
        private DataGridView dgvDanhSachThiSinh;
        private Label lblTrangThai;
        private Button btnBack;
    }
}
