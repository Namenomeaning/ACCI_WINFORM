namespace ACCI_WINFORM.Forms
{
    partial class TraCuuChungChiForm
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
            lblMaThiSinh = new Label();
            txtMaThiSinh = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgayThi = new Label();
            txtNgayThi = new TextBox();
            lblSoBaoDanh = new Label();
            txtSoBaoDanh = new TextBox();
            btnTimKiem = new Button();
            dgvDanhSachThiSinh = new DataGridView();
            lblTrangThaiNhan = new Label();
            txtTrangThaiNhan = new TextBox();
            btnCapNhatTrangThai = new Button();
            btnBack = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
            // 
            // lblMaThiSinh
            // 
            lblMaThiSinh.AutoSize = true;
            lblMaThiSinh.Location = new Point(33, 38);
            lblMaThiSinh.Name = "lblMaThiSinh";
            lblMaThiSinh.Size = new Size(99, 25);
            lblMaThiSinh.TabIndex = 0;
            lblMaThiSinh.Text = "Mã thí sinh";
            // 
            // txtMaThiSinh
            // 
            txtMaThiSinh.Location = new Point(167, 38);
            txtMaThiSinh.Margin = new Padding(3, 4, 3, 4);
            txtMaThiSinh.Name = "txtMaThiSinh";
            txtMaThiSinh.Size = new Size(222, 31);
            txtMaThiSinh.TabIndex = 1;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(33, 88);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(66, 25);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(167, 88);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(222, 31);
            txtHoTen.TabIndex = 3;
            // 
            // lblNgayThi
            // 
            lblNgayThi.AutoSize = true;
            lblNgayThi.Location = new Point(425, 94);
            lblNgayThi.Name = "lblNgayThi";
            lblNgayThi.Size = new Size(79, 25);
            lblNgayThi.TabIndex = 4;
            lblNgayThi.Text = "Ngày thi";
            // 
            // txtNgayThi
            // 
            txtNgayThi.Location = new Point(559, 94);
            txtNgayThi.Margin = new Padding(3, 4, 3, 4);
            txtNgayThi.Name = "txtNgayThi";
            txtNgayThi.Size = new Size(222, 31);
            txtNgayThi.TabIndex = 5;
            // 
            // lblSoBaoDanh
            // 
            lblSoBaoDanh.AutoSize = true;
            lblSoBaoDanh.Location = new Point(425, 33);
            lblSoBaoDanh.Name = "lblSoBaoDanh";
            lblSoBaoDanh.Size = new Size(114, 25);
            lblSoBaoDanh.TabIndex = 6;
            lblSoBaoDanh.Text = "Số báo danh";
            // 
            // txtSoBaoDanh
            // 
            txtSoBaoDanh.Location = new Point(559, 33);
            txtSoBaoDanh.Margin = new Padding(3, 4, 3, 4);
            txtSoBaoDanh.Name = "txtSoBaoDanh";
            txtSoBaoDanh.Size = new Size(222, 31);
            txtSoBaoDanh.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(818, 54);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(111, 38);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm thí sinh";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(43, 158);
            dgvDanhSachThiSinh.Margin = new Padding(3, 4, 3, 4);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.RowHeadersWidth = 62;
            dgvDanhSachThiSinh.Size = new Size(906, 375);
            dgvDanhSachThiSinh.TabIndex = 9;
            dgvDanhSachThiSinh.SelectionChanged += dgvDanhSachThiSinh_SelectionChanged;
            // 
            // lblTrangThaiNhan
            // 
            lblTrangThaiNhan.AutoSize = true;
            lblTrangThaiNhan.Location = new Point(91, 558);
            lblTrangThaiNhan.Name = "lblTrangThaiNhan";
            lblTrangThaiNhan.Size = new Size(133, 25);
            lblTrangThaiNhan.TabIndex = 10;
            lblTrangThaiNhan.Text = "Trạng thái nhận";
            // 
            // txtTrangThaiNhan
            // 
            txtTrangThaiNhan.Location = new Point(243, 558);
            txtTrangThaiNhan.Margin = new Padding(3, 4, 3, 4);
            txtTrangThaiNhan.Name = "txtTrangThaiNhan";
            txtTrangThaiNhan.Size = new Size(222, 31);
            txtTrangThaiNhan.TabIndex = 11;
            // 
            // btnCapNhatTrangThai
            // 
            btnCapNhatTrangThai.Location = new Point(521, 554);
            btnCapNhatTrangThai.Margin = new Padding(3, 4, 3, 4);
            btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            btnCapNhatTrangThai.Size = new Size(214, 38);
            btnCapNhatTrangThai.TabIndex = 12;
            btnCapNhatTrangThai.Text = "Cập nhật tình trạng";
            btnCapNhatTrangThai.UseVisualStyleBackColor = true;
            btnCapNhatTrangThai.Click += btnCapNhatTrangThai_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.Location = new Point(818, 554);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(170, 40);
            btnBack.TabIndex = 20;
            btnBack.Text = "Quay Lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(43, 129);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 21;
            label1.Text = "Danh sách tra cứu";
            // 
            // TraCuuChungChiForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 617);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnCapNhatTrangThai);
            Controls.Add(txtTrangThaiNhan);
            Controls.Add(lblTrangThaiNhan);
            Controls.Add(dgvDanhSachThiSinh);
            Controls.Add(btnTimKiem);
            Controls.Add(txtSoBaoDanh);
            Controls.Add(lblSoBaoDanh);
            Controls.Add(txtNgayThi);
            Controls.Add(lblNgayThi);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtMaThiSinh);
            Controls.Add(lblMaThiSinh);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TraCuuChungChiForm";
            Text = "Tra cứu chứng chỉ";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaThiSinh;
        private TextBox txtMaThiSinh;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgayThi;
        private TextBox txtNgayThi;
        private Label lblSoBaoDanh;
        private TextBox txtSoBaoDanh;
        private Button btnTimKiem;
        private DataGridView dgvDanhSachThiSinh;
        private Label lblTrangThaiNhan;
        private TextBox txtTrangThaiNhan;
        private Button btnCapNhatTrangThai;
        private Button btnBack;
        private Label label1;
    }
}