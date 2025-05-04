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
            lblSoBaoDanh = new Label();
            txtSoBaoDanh = new TextBox();
            btnTimKiem = new Button();
            dgvDanhSachThiSinh = new DataGridView();
            lblTrangThaiNhan = new Label();
            cmbTrangThaiNhan = new ComboBox();
            btnCapNhatTrangThai = new Button();
            btnBack = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
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
            // cmbTrangThaiNhan
            // 
            cmbTrangThaiNhan.FormattingEnabled = true;
            cmbTrangThaiNhan.Location = new Point(243, 558);
            cmbTrangThaiNhan.Name = "cmbTrangThaiNhan";
            cmbTrangThaiNhan.Size = new Size(222, 33);
            cmbTrangThaiNhan.TabIndex = 11;
            cmbTrangThaiNhan.DropDownStyle = ComboBoxStyle.DropDownList;
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
            Controls.Add(cmbTrangThaiNhan);
            Controls.Add(lblTrangThaiNhan);
            Controls.Add(dgvDanhSachThiSinh);
            Controls.Add(btnTimKiem);
            Controls.Add(txtSoBaoDanh);
            Controls.Add(lblSoBaoDanh);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TraCuuChungChiForm";
            Text = "Tra cứu chứng chỉ";
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSoBaoDanh;
        private TextBox txtSoBaoDanh;
        private Button btnTimKiem;
        private DataGridView dgvDanhSachThiSinh;
        private Label lblTrangThaiNhan;
        private ComboBox cmbTrangThaiNhan;
        private Button btnCapNhatTrangThai;
        private Button btnBack;
        private Label label1;
    }
}