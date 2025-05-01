namespace ACCI_WINFORM.Forms
{
    partial class KiemTraGiaHanForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaThiSinh = new System.Windows.Forms.Label();
            this.txtMaThiSinh = new System.Windows.Forms.TextBox();
            this.lblMaDanhGia = new System.Windows.Forms.Label();
            this.cbMaDanhGia = new System.Windows.Forms.ComboBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.lblSoLanGiaHan = new System.Windows.Forms.Label();
            this.lblThoiGianGiaHan = new System.Windows.Forms.Label();
            this.lblTruongHopDacBiet = new System.Windows.Forms.Label();
            this.cbTruongHopDacBiet = new System.Windows.Forms.CheckBox();
            this.lblHopLe = new System.Windows.Forms.Label();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "KIỂM TRA GIA HẠN";
            // 
            // lblMaThiSinh
            // 
            this.lblMaThiSinh.AutoSize = true;
            this.lblMaThiSinh.Location = new System.Drawing.Point(12, 50);
            this.lblMaThiSinh.Name = "lblMaThiSinh";
            this.lblMaThiSinh.Size = new System.Drawing.Size(81, 13);
            this.lblMaThiSinh.TabIndex = 1;
            this.lblMaThiSinh.Text = "Mã Thí Sinh:";
            // 
            // txtMaThiSinh
            // 
            this.txtMaThiSinh.Location = new System.Drawing.Point(99, 47);
            this.txtMaThiSinh.Name = "txtMaThiSinh";
            this.txtMaThiSinh.Size = new System.Drawing.Size(200, 20);
            this.txtMaThiSinh.TabIndex = 2;
            // 
            // lblMaDanhGia
            // 
            this.lblMaDanhGia.AutoSize = true;
            this.lblMaDanhGia.Location = new System.Drawing.Point(12, 80);
            this.lblMaDanhGia.Name = "lblMaDanhGia";
            this.lblMaDanhGia.Size = new System.Drawing.Size(81, 13);
            this.lblMaDanhGia.TabIndex = 3;
            this.lblMaDanhGia.Text = "Mã Đánh Giá:";
            // 
            // cbMaDanhGia
            // 
            this.cbMaDanhGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaDanhGia.FormattingEnabled = true;
            this.cbMaDanhGia.Location = new System.Drawing.Point(99, 77);
            this.cbMaDanhGia.Name = "cbMaDanhGia";
            this.cbMaDanhGia.Size = new System.Drawing.Size(200, 21);
            this.cbMaDanhGia.TabIndex = 4;
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.Black;
            this.btnKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnKiemTra.Location = new System.Drawing.Point(305, 77);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(75, 23);
            this.btnKiemTra.TabIndex = 5;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // lblSoLanGiaHan
            // 
            this.lblSoLanGiaHan.AutoSize = true;
            this.lblSoLanGiaHan.Location = new System.Drawing.Point(12, 110);
            this.lblSoLanGiaHan.Name = "lblSoLanGiaHan";
            this.lblSoLanGiaHan.Size = new System.Drawing.Size(121, 13);
            this.lblSoLanGiaHan.TabIndex = 6;
            this.lblSoLanGiaHan.Text = "Số lần gia hạn còn lại: ";
            // 
            // lblThoiGianGiaHan
            // 
            this.lblThoiGianGiaHan.AutoSize = true;
            this.lblThoiGianGiaHan.Location = new System.Drawing.Point(12, 130);
            this.lblThoiGianGiaHan.Name = "lblThoiGianGiaHan";
            this.lblThoiGianGiaHan.Size = new System.Drawing.Size(121, 13);
            this.lblThoiGianGiaHan.TabIndex = 7;
            this.lblThoiGianGiaHan.Text = "Thời gian gia hạn: ";
            // 
            // lblTruongHopDacBiet
            // 
            this.lblTruongHopDacBiet.AutoSize = true;
            this.lblTruongHopDacBiet.Location = new System.Drawing.Point(12, 150);
            this.lblTruongHopDacBiet.Name = "lblTruongHopDacBiet";
            this.lblTruongHopDacBiet.Size = new System.Drawing.Size(121, 13);
            this.lblTruongHopDacBiet.TabIndex = 8;
            this.lblTruongHopDacBiet.Text = "Trường hợp đặc biệt: ";
            // 
            // cbTruongHopDacBiet
            // 
            this.cbTruongHopDacBiet.AutoSize = true;
            this.cbTruongHopDacBiet.Location = new System.Drawing.Point(139, 148);
            this.cbTruongHopDacBiet.Name = "cbTruongHopDacBiet";
            this.cbTruongHopDacBiet.Size = new System.Drawing.Size(15, 14);
            this.cbTruongHopDacBiet.TabIndex = 9;
            this.cbTruongHopDacBiet.UseVisualStyleBackColor = true;
            // 
            // lblHopLe
            // 
            this.lblHopLe.AutoSize = true;
            this.lblHopLe.ForeColor = System.Drawing.Color.Green;
            this.lblHopLe.Location = new System.Drawing.Point(12, 170);
            this.lblHopLe.Name = "lblHopLe";
            this.lblHopLe.Size = new System.Drawing.Size(0, 13);
            this.lblHopLe.TabIndex = 10;
            this.lblHopLe.Text = "";
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.Color.Black;
            this.btnGiaHan.ForeColor = System.Drawing.Color.White;
            this.btnGiaHan.Location = new System.Drawing.Point(305, 170);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(75, 23);
            this.btnGiaHan.TabIndex = 11;
            this.btnGiaHan.Text = "Gia Hạn";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Visible = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // KiemTraGiaHanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.lblHopLe);
            this.Controls.Add(this.cbTruongHopDacBiet);
            this.Controls.Add(this.lblTruongHopDacBiet);
            this.Controls.Add(this.lblThoiGianGiaHan);
            this.Controls.Add(this.lblSoLanGiaHan);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.cbMaDanhGia);
            this.Controls.Add(this.lblMaDanhGia);
            this.Controls.Add(this.txtMaThiSinh);
            this.Controls.Add(this.lblMaThiSinh);
            this.Controls.Add(this.lblTitle);
            this.Name = "KiemTraGiaHanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm Tra Gia Hạn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaThiSinh;
        private System.Windows.Forms.TextBox txtMaThiSinh;
        private System.Windows.Forms.Label lblMaDanhGia;
        private System.Windows.Forms.ComboBox cbMaDanhGia;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblSoLanGiaHan;
        private System.Windows.Forms.Label lblThoiGianGiaHan;
        private System.Windows.Forms.Label lblTruongHopDacBiet;
        private System.Windows.Forms.CheckBox cbTruongHopDacBiet;
        private System.Windows.Forms.Label lblHopLe;
        private System.Windows.Forms.Button btnGiaHan;
    }
}