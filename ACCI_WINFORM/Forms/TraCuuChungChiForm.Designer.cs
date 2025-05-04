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
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnTimKiem = new Button();
            txtSoBaoDanh = new TextBox();
            lblSoBaoDanh = new Label();
            groupBox2 = new GroupBox();
            dgvDanhSachThiSinh = new DataGridView();
            label1 = new Label();
            groupBox3 = new GroupBox();
            btnCapNhatTrangThai = new Button();
            cmbTrangThaiNhan = new ComboBox();
            lblTrangThaiNhan = new Label();
            btnBack = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(338, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(251, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TRA CỨU CHỨNG CHỈ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtSoBaoDanh);
            groupBox1.Controls.Add(lblSoBaoDanh);
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
            btnTimKiem.Text = "Tìm thí sinh";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtSoBaoDanh
            // 
            txtSoBaoDanh.Location = new Point(145, 20);
            txtSoBaoDanh.Margin = new Padding(3, 2, 3, 2);
            txtSoBaoDanh.Name = "txtSoBaoDanh";
            txtSoBaoDanh.Size = new Size(260, 23);
            txtSoBaoDanh.TabIndex = 1;
            // 
            // lblSoBaoDanh
            // 
            lblSoBaoDanh.AutoSize = true;
            lblSoBaoDanh.Location = new Point(20, 22);
            lblSoBaoDanh.Name = "lblSoBaoDanh";
            lblSoBaoDanh.Size = new Size(77, 15);
            lblSoBaoDanh.TabIndex = 0;
            lblSoBaoDanh.Text = "Số báo danh:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDanhSachThiSinh);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(10, 97);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(820, 230);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách thí sinh";
            // 
            // dgvDanhSachThiSinh
            // 
            dgvDanhSachThiSinh.AllowUserToAddRows = false;
            dgvDanhSachThiSinh.AllowUserToDeleteRows = false;
            dgvDanhSachThiSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachThiSinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachThiSinh.Location = new Point(6, 45);
            dgvDanhSachThiSinh.Margin = new Padding(3, 2, 3, 2);
            dgvDanhSachThiSinh.Name = "dgvDanhSachThiSinh";
            dgvDanhSachThiSinh.ReadOnly = true;
            dgvDanhSachThiSinh.RowHeadersWidth = 30;
            dgvDanhSachThiSinh.Size = new Size(808, 180);
            dgvDanhSachThiSinh.TabIndex = 0;
            dgvDanhSachThiSinh.SelectionChanged += dgvDanhSachThiSinh_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 21;
            label1.Text = "Danh sách tra cứu";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnCapNhatTrangThai);
            groupBox3.Controls.Add(cmbTrangThaiNhan);
            groupBox3.Controls.Add(lblTrangThaiNhan);
            groupBox3.Location = new Point(10, 330);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(820, 60);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cập nhật trạng thái";
            // 
            // btnCapNhatTrangThai
            // 
            btnCapNhatTrangThai.Location = new Point(370, 22);
            btnCapNhatTrangThai.Margin = new Padding(3, 2, 3, 2);
            btnCapNhatTrangThai.Name = "btnCapNhatTrangThai";
            btnCapNhatTrangThai.Size = new Size(133, 25);
            btnCapNhatTrangThai.TabIndex = 12;
            btnCapNhatTrangThai.Text = "Cập nhật tình trạng";
            btnCapNhatTrangThai.UseVisualStyleBackColor = true;
            btnCapNhatTrangThai.Click += btnCapNhatTrangThai_Click;
            // 
            // cmbTrangThaiNhan
            // 
            cmbTrangThaiNhan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrangThaiNhan.FormattingEnabled = true;
            cmbTrangThaiNhan.Location = new Point(145, 22);
            cmbTrangThaiNhan.Margin = new Padding(3, 2, 3, 2);
            cmbTrangThaiNhan.Name = "cmbTrangThaiNhan";
            cmbTrangThaiNhan.Size = new Size(200, 23);
            cmbTrangThaiNhan.TabIndex = 11;
            // 
            // lblTrangThaiNhan
            // 
            lblTrangThaiNhan.AutoSize = true;
            lblTrangThaiNhan.Location = new Point(20, 24);
            lblTrangThaiNhan.Name = "lblTrangThaiNhan";
            lblTrangThaiNhan.Size = new Size(92, 15);
            lblTrangThaiNhan.TabIndex = 10;
            lblTrangThaiNhan.Text = "Trạng thái nhận:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(740, 400);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(82, 25);
            btnBack.TabIndex = 7;
            btnBack.Text = "Quay lại";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BtnBack_Click;
            // 
            // TraCuuChungChiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 435);
            Controls.Add(btnBack);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TraCuuChungChiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu chứng chỉ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachThiSinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupBox1;
        private Button btnTimKiem;
        private TextBox txtSoBaoDanh;
        private Label lblSoBaoDanh;
        private GroupBox groupBox2;
        private DataGridView dgvDanhSachThiSinh;
        private Label label1;
        private GroupBox groupBox3;
        private Button btnCapNhatTrangThai;
        private ComboBox cmbTrangThaiNhan;
        private Label lblTrangThaiNhan;
        private Button btnBack;
    }
}
