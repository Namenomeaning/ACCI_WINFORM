namespace ACCI_WINFORM.Forms
{
    partial class GiaHanThoiGianThiForm
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
            lblThongTin = new Label();
            dgvThongTin = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            MaThiSinh = new DataGridViewTextBoxColumn();
            HoTen = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            MaDanhGia = new DataGridViewTextBoxColumn();
            GioDanhGiaCu = new DataGridViewTextBoxColumn();
            lblLichThiMoi = new Label();
            cbLichThiMoi = new ComboBox();
            btnCapNhat = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvThongTin).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 17);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(348, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GIA HẠN THỜI GIAN THI";
            // 
            // lblThongTin
            // 
            lblThongTin.AutoSize = true;
            lblThongTin.Location = new Point(20, 77);
            lblThongTin.Margin = new Padding(5, 0, 5, 0);
            lblThongTin.Name = "lblThongTin";
            lblThongTin.Size = new Size(157, 25);
            lblThongTin.TabIndex = 1;
            lblThongTin.Text = "Thông tin đăng ký";
            // 
            // dgvThongTin
            // 
            dgvThongTin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTin.Columns.AddRange(new DataGridViewColumn[] { STT, MaThiSinh, HoTen, NgaySinh, MaDanhGia, GioDanhGiaCu });
            dgvThongTin.Location = new Point(20, 108);
            dgvThongTin.Margin = new Padding(5, 6, 5, 6);
            dgvThongTin.Name = "dgvThongTin";
            dgvThongTin.RowHeadersWidth = 62;
            dgvThongTin.Size = new Size(939, 150);
            dgvThongTin.TabIndex = 2;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 8;
            STT.Name = "STT";
            STT.Width = 40;
            // 
            // MaThiSinh
            // 
            MaThiSinh.HeaderText = "Mã Thí Sinh";
            MaThiSinh.MinimumWidth = 8;
            MaThiSinh.Name = "MaThiSinh";
            MaThiSinh.Width = 90;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ tên";
            HoTen.MinimumWidth = 8;
            HoTen.Name = "HoTen";
            HoTen.Width = 120;
            // 
            // NgaySinh
            // 
            NgaySinh.HeaderText = "Ngày sinh";
            NgaySinh.MinimumWidth = 8;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.Width = 80;
            // 
            // MaDanhGia
            // 
            MaDanhGia.HeaderText = "Mã đánh giá";
            MaDanhGia.MinimumWidth = 8;
            MaDanhGia.Name = "MaDanhGia";
            MaDanhGia.Width = 90;
            // 
            // GioDanhGiaCu
            // 
            GioDanhGiaCu.HeaderText = "Giờ đánh giá cũ";
            GioDanhGiaCu.MinimumWidth = 8;
            GioDanhGiaCu.Name = "GioDanhGiaCu";
            GioDanhGiaCu.Width = 120;
            // 
            // lblLichThiMoi
            // 
            lblLichThiMoi.AutoSize = true;
            lblLichThiMoi.Location = new Point(20, 264);
            lblLichThiMoi.Margin = new Padding(5, 0, 5, 0);
            lblLichThiMoi.Name = "lblLichThiMoi";
            lblLichThiMoi.Size = new Size(150, 25);
            lblLichThiMoi.TabIndex = 3;
            lblLichThiMoi.Text = "Chọn lịch thi mới:";
            // 
            // cbLichThiMoi
            // 
            cbLichThiMoi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLichThiMoi.FormattingEnabled = true;
            cbLichThiMoi.Location = new Point(199, 261);
            cbLichThiMoi.Margin = new Padding(5, 6, 5, 6);
            cbLichThiMoi.Name = "cbLichThiMoi";
            cbLichThiMoi.Size = new Size(331, 33);
            cbLichThiMoi.TabIndex = 4;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Black;
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(20, 295);
            btnCapNhat.Margin = new Padding(5, 6, 5, 6);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(125, 44);
            btnCapNhat.TabIndex = 5;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Black;
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(155, 295);
            btnHuy.Margin = new Padding(5, 6, 5, 6);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(125, 44);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // GiaHanThoiGianThiForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 365);
            Controls.Add(btnHuy);
            Controls.Add(btnCapNhat);
            Controls.Add(cbLichThiMoi);
            Controls.Add(lblLichThiMoi);
            Controls.Add(dgvThongTin);
            Controls.Add(lblThongTin);
            Controls.Add(lblTitle);
            Margin = new Padding(5, 6, 5, 6);
            Name = "GiaHanThoiGianThiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gia Hạn Thời Gian Thi";
            ((System.ComponentModel.ISupportInitialize)dgvThongTin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.DataGridView dgvThongTin;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDanhGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioDanhGiaCu;
        private System.Windows.Forms.Label lblLichThiMoi;
        private System.Windows.Forms.ComboBox cbLichThiMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnHuy;
    }
}