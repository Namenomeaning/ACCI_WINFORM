namespace ACCI_WINFORM.Forms
{
    partial class MH_TraCuuPhieuDangKy
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
            this.lblMaPhieuDK = new System.Windows.Forms.Label();
            this.txtMaPhieuDK = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbKetQuaTraCuu = new System.Windows.Forms.GroupBox();
            this.lblMaPhieuHienThi = new System.Windows.Forms.Label();
            this.txtMaPhieuHienThi = new System.Windows.Forms.TextBox();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtNgayTao = new System.Windows.Forms.TextBox();
            this.lblTenKhachHang = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.lblTrangThaiPhieu = new System.Windows.Forms.Label();
            this.txtTrangThaiPhieu = new System.Windows.Forms.TextBox();
            this.lblSoLanGiaHan = new System.Windows.Forms.Label();
            this.txtSoLanGiaHan = new System.Windows.Forms.TextBox();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.dgvChiTietPhieuDK = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaThiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenThiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLichThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.gbKetQuaTraCuu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuDK)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaPhieuDK
            // 
            this.lblMaPhieuDK.AutoSize = true;
            this.lblMaPhieuDK.Location = new System.Drawing.Point(12, 20);
            this.lblMaPhieuDK.Name = "lblMaPhieuDK";
            this.lblMaPhieuDK.Size = new System.Drawing.Size(86, 16);
            this.lblMaPhieuDK.TabIndex = 0;
            this.lblMaPhieuDK.Text = "Mã Phiếu ĐK:";
            // 
            // txtMaPhieuDK
            // 
            this.txtMaPhieuDK.Location = new System.Drawing.Point(104, 17);
            this.txtMaPhieuDK.Name = "txtMaPhieuDK";
            this.txtMaPhieuDK.Size = new System.Drawing.Size(180, 22);
            this.txtMaPhieuDK.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(294, 16);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // gbKetQuaTraCuu
            // 
            this.gbKetQuaTraCuu.Controls.Add(this.lblMaPhieuHienThi);
            this.gbKetQuaTraCuu.Controls.Add(this.txtMaPhieuHienThi);
            this.gbKetQuaTraCuu.Controls.Add(this.lblNgayTao);
            this.gbKetQuaTraCuu.Controls.Add(this.txtNgayTao);
            this.gbKetQuaTraCuu.Controls.Add(this.lblTenKhachHang);
            this.gbKetQuaTraCuu.Controls.Add(this.txtTenKhachHang);
            this.gbKetQuaTraCuu.Controls.Add(this.lblTrangThaiPhieu);
            this.gbKetQuaTraCuu.Controls.Add(this.txtTrangThaiPhieu);
            this.gbKetQuaTraCuu.Controls.Add(this.lblSoLanGiaHan);
            this.gbKetQuaTraCuu.Controls.Add(this.txtSoLanGiaHan);
            this.gbKetQuaTraCuu.Controls.Add(this.lblChiTiet);
            this.gbKetQuaTraCuu.Controls.Add(this.dgvChiTietPhieuDK);
            this.gbKetQuaTraCuu.Controls.Add(this.btnTaoHoaDon);
            this.gbKetQuaTraCuu.Controls.Add(this.btnXemHoaDon);
            this.gbKetQuaTraCuu.Location = new System.Drawing.Point(12, 57);
            this.gbKetQuaTraCuu.Name = "gbKetQuaTraCuu";
            this.gbKetQuaTraCuu.Size = new System.Drawing.Size(776, 470);
            this.gbKetQuaTraCuu.TabIndex = 3;
            this.gbKetQuaTraCuu.TabStop = false;
            this.gbKetQuaTraCuu.Text = "Kết Quả Tra Cứu";
            this.gbKetQuaTraCuu.Visible = false;
            // 
            // lblMaPhieuHienThi
            // 
            this.lblMaPhieuHienThi.AutoSize = true;
            this.lblMaPhieuHienThi.Location = new System.Drawing.Point(16, 35);
            this.lblMaPhieuHienThi.Name = "lblMaPhieuHienThi";
            this.lblMaPhieuHienThi.Size = new System.Drawing.Size(66, 16);
            this.lblMaPhieuHienThi.TabIndex = 0;
            this.lblMaPhieuHienThi.Text = "Mã Phiếu:";
            // 
            // txtMaPhieuHienThi
            // 
            this.txtMaPhieuHienThi.Location = new System.Drawing.Point(108, 32);
            this.txtMaPhieuHienThi.Name = "txtMaPhieuHienThi";
            this.txtMaPhieuHienThi.ReadOnly = true;
            this.txtMaPhieuHienThi.Size = new System.Drawing.Size(183, 22);
            this.txtMaPhieuHienThi.TabIndex = 1;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(16, 63);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(68, 16);
            this.lblNgayTao.TabIndex = 2;
            this.lblNgayTao.Text = "Ngày Tạo:";
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.Location = new System.Drawing.Point(108, 60);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.ReadOnly = true;
            this.txtNgayTao.Size = new System.Drawing.Size(183, 22);
            this.txtNgayTao.TabIndex = 3;
            // 
            // lblTenKhachHang
            // 
            this.lblTenKhachHang.AutoSize = true;
            this.lblTenKhachHang.Location = new System.Drawing.Point(16, 91);
            this.lblTenKhachHang.Name = "lblTenKhachHang";
            this.lblTenKhachHang.Size = new System.Drawing.Size(76, 16);
            this.lblTenKhachHang.TabIndex = 4;
            this.lblTenKhachHang.Text = "Khách hàng:";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(108, 88);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.ReadOnly = true;
            this.txtTenKhachHang.Size = new System.Drawing.Size(183, 22);
            this.txtTenKhachHang.TabIndex = 5;
            // 
            // lblTrangThaiPhieu
            // 
            this.lblTrangThaiPhieu.AutoSize = true;
            this.lblTrangThaiPhieu.Location = new System.Drawing.Point(365, 35);
            this.lblTrangThaiPhieu.Name = "lblTrangThaiPhieu";
            this.lblTrangThaiPhieu.Size = new System.Drawing.Size(76, 16);
            this.lblTrangThaiPhieu.TabIndex = 6;
            this.lblTrangThaiPhieu.Text = "Trạng thái:";
            // 
            // txtTrangThaiPhieu
            // 
            this.txtTrangThaiPhieu.Location = new System.Drawing.Point(447, 32);
            this.txtTrangThaiPhieu.Name = "txtTrangThaiPhieu";
            this.txtTrangThaiPhieu.ReadOnly = true;
            this.txtTrangThaiPhieu.Size = new System.Drawing.Size(183, 22);
            this.txtTrangThaiPhieu.TabIndex = 7;
            // 
            // lblSoLanGiaHan
            // 
            this.lblSoLanGiaHan.AutoSize = true;
            this.lblSoLanGiaHan.Location = new System.Drawing.Point(365, 63);
            this.lblSoLanGiaHan.Name = "lblSoLanGiaHan";
            this.lblSoLanGiaHan.Size = new System.Drawing.Size(76, 16);
            this.lblSoLanGiaHan.TabIndex = 8;
            this.lblSoLanGiaHan.Text = "Số lần GH:";
            // 
            // txtSoLanGiaHan
            // 
            this.txtSoLanGiaHan.Location = new System.Drawing.Point(447, 60);
            this.txtSoLanGiaHan.Name = "txtSoLanGiaHan";
            this.txtSoLanGiaHan.ReadOnly = true;
            this.txtSoLanGiaHan.Size = new System.Drawing.Size(183, 22);
            this.txtSoLanGiaHan.TabIndex = 9;
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.Location = new System.Drawing.Point(16, 130);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(100, 16);
            this.lblChiTiet.TabIndex = 10;
            this.lblChiTiet.Text = "Chi tiết đăng ký:";
            // 
            // dgvChiTietPhieuDK
            // 
            this.dgvChiTietPhieuDK.AllowUserToAddRows = false;
            this.dgvChiTietPhieuDK.AllowUserToDeleteRows = false;
            this.dgvChiTietPhieuDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuDK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaThiSinh,
            this.colTenThiSinh,
            this.colMaLichThi,
            this.colNgayThi,
            this.colGioThi,
            this.colTenDanhGia,
            this.colTrangThaiCT});
            this.dgvChiTietPhieuDK.Location = new System.Drawing.Point(19, 149);
            this.dgvChiTietPhieuDK.Name = "dgvChiTietPhieuDK";
            this.dgvChiTietPhieuDK.ReadOnly = true;
            this.dgvChiTietPhieuDK.RowHeadersWidth = 51;
            this.dgvChiTietPhieuDK.RowTemplate.Height = 24;
            this.dgvChiTietPhieuDK.Size = new System.Drawing.Size(737, 263);
            this.dgvChiTietPhieuDK.TabIndex = 11;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colMaThiSinh
            // 
            this.colMaThiSinh.HeaderText = "Mã Thí Sinh";
            this.colMaThiSinh.MinimumWidth = 6;
            this.colMaThiSinh.Name = "colMaThiSinh";
            this.colMaThiSinh.ReadOnly = true;
            this.colMaThiSinh.Width = 80;
            // 
            // colTenThiSinh
            // 
            this.colTenThiSinh.HeaderText = "Tên Thí Sinh";
            this.colTenThiSinh.MinimumWidth = 6;
            this.colTenThiSinh.Name = "colTenThiSinh";
            this.colTenThiSinh.ReadOnly = true;
            this.colTenThiSinh.Width = 125;
            // 
            // colMaLichThi
            // 
            this.colMaLichThi.HeaderText = "Mã Lịch Thi";
            this.colMaLichThi.MinimumWidth = 6;
            this.colMaLichThi.Name = "colMaLichThi";
            this.colMaLichThi.ReadOnly = true;
            this.colMaLichThi.Width = 80;
            // 
            // colNgayThi
            // 
            this.colNgayThi.HeaderText = "Ngày Thi";
            this.colNgayThi.MinimumWidth = 6;
            this.colNgayThi.Name = "colNgayThi";
            this.colNgayThi.ReadOnly = true;
            this.colNgayThi.Width = 85;
            // 
            // colGioThi
            // 
            this.colGioThi.HeaderText = "Giờ Thi";
            this.colGioThi.MinimumWidth = 6;
            this.colGioThi.Name = "colGioThi";
            this.colGioThi.ReadOnly = true;
            this.colGioThi.Width = 75;
            // 
            // colTenDanhGia
            // 
            this.colTenDanhGia.HeaderText = "Đánh Giá";
            this.colTenDanhGia.MinimumWidth = 6;
            this.colTenDanhGia.Name = "colTenDanhGia";
            this.colTenDanhGia.ReadOnly = true;
            this.colTenDanhGia.Width = 125;
            // 
            // colTrangThaiCT
            // 
            this.colTrangThaiCT.HeaderText = "Trạng Thái";
            this.colTrangThaiCT.MinimumWidth = 6;
            this.colTrangThaiCT.Name = "colTrangThaiCT";
            this.colTrangThaiCT.ReadOnly = true;
            this.colTrangThaiCT.Width = 90;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Enabled = false;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(447, 429);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(120, 30);
            this.btnTaoHoaDon.TabIndex = 12;
            this.btnTaoHoaDon.Text = "Tạo Hóa Đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnXemHoaDon
            // 
            this.btnXemHoaDon.Enabled = false;
            this.btnXemHoaDon.Location = new System.Drawing.Point(584, 429);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(120, 30);
            this.btnXemHoaDon.TabIndex = 13;
            this.btnXemHoaDon.Text = "Xem Hóa Đơn";
            this.btnXemHoaDon.UseVisualStyleBackColor = true;
            // 
            // MH_TraCuuPhieuDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.lblMaPhieuDK);
            this.Controls.Add(this.txtMaPhieuDK);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.gbKetQuaTraCuu);
            this.Name = "MH_TraCuuPhieuDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra Cứu Phiếu Đăng Ký";
            this.gbKetQuaTraCuu.ResumeLayout(false);
            this.gbKetQuaTraCuu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaPhieuDK;
        private System.Windows.Forms.TextBox txtMaPhieuDK;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox gbKetQuaTraCuu;
        private System.Windows.Forms.Label lblMaPhieuHienThi;
        private System.Windows.Forms.TextBox txtMaPhieuHienThi;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.TextBox txtNgayTao;
        private System.Windows.Forms.Label lblTenKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label lblTrangThaiPhieu;
        private System.Windows.Forms.TextBox txtTrangThaiPhieu;
        private System.Windows.Forms.Label lblSoLanGiaHan;
        private System.Windows.Forms.TextBox txtSoLanGiaHan;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuDK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLichThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanhGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThaiCT;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.Button btnXemHoaDon;
    }
}
