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
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnKiemTra = new Button();
            txtMaThiSinh = new TextBox();
            lblMaThiSinh = new Label();
            groupBox2 = new GroupBox();
            cbTruongHopDacBiet = new CheckBox();
            lblTruongHopDacBiet = new Label();
            lblThoiGianGiaHan = new Label();
            lblSoLanGiaHan = new Label();
            lblHopLe = new Label();
            cbMaDanhGia = new ComboBox();
            lblMaDanhGia = new Label();
            btnGiaHan = new Button();
            btnQuayLai = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(338, 7);
            lblTitle.Name = "lblTitle";
            // Fixing the assignment of lblTitle.Size
            lblTitle.Size = new Size(233, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "KIỂM TRA GIA HẠN";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnKiemTra);
            groupBox1.Controls.Add(txtMaThiSinh);
            groupBox1.Controls.Add(lblMaThiSinh);
            groupBox1.Location = new Point(10, 38);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(820, 54);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // btnKiemTra
            // 
            btnKiemTra.Location = new Point(429, 20);
            btnKiemTra.Margin = new Padding(3, 2, 3, 2);
            btnKiemTra.Name = "btnKiemTra";
            btnKiemTra.Size = new Size(82, 22);
            btnKiemTra.TabIndex = 2;
            btnKiemTra.Text = "Kiểm tra";
            btnKiemTra.UseVisualStyleBackColor = true;
            btnKiemTra.Click += btnKiemTra_Click;
            // 
            // txtMaThiSinh
            // 
            txtMaThiSinh.Location = new Point(145, 20);
            txtMaThiSinh.Margin = new Padding(3, 2, 3, 2);
            txtMaThiSinh.Name = "txtMaThiSinh";
            txtMaThiSinh.Size = new Size(260, 23);
            txtMaThiSinh.TabIndex = 1;
            // 
            // lblMaThiSinh
            // 
            lblMaThiSinh.AutoSize = true;
            lblMaThiSinh.Location = new Point(20, 22);
            lblMaThiSinh.Name = "lblMaThiSinh";
            lblMaThiSinh.Size = new Size(70, 15);
            lblMaThiSinh.TabIndex = 0;
            lblMaThiSinh.Text = "Mã thí sinh:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbTruongHopDacBiet);
            groupBox2.Controls.Add(lblTruongHopDacBiet);
            groupBox2.Controls.Add(lblThoiGianGiaHan);
            groupBox2.Controls.Add(lblSoLanGiaHan);
            groupBox2.Controls.Add(lblHopLe);
            groupBox2.Controls.Add(cbMaDanhGia);
            groupBox2.Controls.Add(lblMaDanhGia);
            groupBox2.Location = new Point(10, 97);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(820, 146);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin gia hạn";
            // 
            // cbTruongHopDacBiet
            // 
            cbTruongHopDacBiet.AutoSize = true;
            cbTruongHopDacBiet.Location = new Point(163, 104);
            cbTruongHopDacBiet.Name = "cbTruongHopDacBiet";
            cbTruongHopDacBiet.Size = new Size(15, 14);
            cbTruongHopDacBiet.TabIndex = 9;
            cbTruongHopDacBiet.UseVisualStyleBackColor = true;
            // 
            // lblTruongHopDacBiet
            // 
            lblTruongHopDacBiet.AutoSize = true;
            lblTruongHopDacBiet.Location = new Point(43, 104);
            lblTruongHopDacBiet.Name = "lblTruongHopDacBiet";
            lblTruongHopDacBiet.Size = new Size(114, 15);
            lblTruongHopDacBiet.TabIndex = 8;
            lblTruongHopDacBiet.Text = "Trường hợp đặc biệt:";
            // 
            // lblThoiGianGiaHan
            // 
            lblThoiGianGiaHan.AutoSize = true;
            lblThoiGianGiaHan.Location = new Point(43, 82);
            lblThoiGianGiaHan.Name = "lblThoiGianGiaHan";
            lblThoiGianGiaHan.Size = new Size(99, 15);
            lblThoiGianGiaHan.TabIndex = 7;
            lblThoiGianGiaHan.Text = "Thời gian gia hạn:";
            // 
            // lblSoLanGiaHan
            // 
            lblSoLanGiaHan.AutoSize = true;
            lblSoLanGiaHan.Location = new Point(43, 57);
            lblSoLanGiaHan.Name = "lblSoLanGiaHan";
            lblSoLanGiaHan.Size = new Size(118, 15);
            lblSoLanGiaHan.TabIndex = 6;
            lblSoLanGiaHan.Text = "Số lần gia hạn còn lại:";
            // 
            // lblHopLe
            // 
            lblHopLe.AutoSize = true;
            lblHopLe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblHopLe.ForeColor = System.Drawing.Color.Green;
            lblHopLe.Location = new Point(43, 126);
            lblHopLe.Name = "lblHopLe";
            lblHopLe.Size = new Size(0, 15);
            lblHopLe.TabIndex = 10;
            // 
            // cbMaDanhGia
            // 
            cbMaDanhGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMaDanhGia.FormattingEnabled = true;
            cbMaDanhGia.Location = new Point(119, 26);
            cbMaDanhGia.Margin = new Padding(3, 2, 3, 2);
            cbMaDanhGia.Name = "cbMaDanhGia";
            cbMaDanhGia.Size = new Size(180, 23);
            cbMaDanhGia.TabIndex = 4;
            // 
            // lblMaDanhGia
            // 
            lblMaDanhGia.AutoSize = true;
            lblMaDanhGia.Location = new Point(43, 29);
            lblMaDanhGia.Name = "lblMaDanhGia";
            lblMaDanhGia.Size = new Size(72, 15);
            lblMaDanhGia.TabIndex = 3;
            lblMaDanhGia.Text = "Mã đánh giá:";
            // 
            // btnGiaHan
            // 
            btnGiaHan.Location = new Point(650, 250);
            btnGiaHan.Margin = new Padding(3, 2, 3, 2);
            btnGiaHan.Name = "btnGiaHan";
            btnGiaHan.Size = new Size(82, 25);
            btnGiaHan.TabIndex = 11;
            btnGiaHan.Text = "Gia hạn";
            btnGiaHan.UseVisualStyleBackColor = true;
            btnGiaHan.Visible = false;
            btnGiaHan.Click += btnGiaHan_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(740, 250);
            btnQuayLai.Margin = new Padding(3, 2, 3, 2);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(82, 25);
            btnQuayLai.TabIndex = 7;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click); // Thêm dòng này
            // 
            // KiemTraGiaHanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 290);
            Controls.Add(btnQuayLai);
            Controls.Add(btnGiaHan);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KiemTraGiaHanForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kiểm Tra Gia Hạn";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupBox1;
        private Button btnKiemTra;
        private TextBox txtMaThiSinh;
        private Label lblMaThiSinh;
        private GroupBox groupBox2;
        private Label lblMaDanhGia;
        private ComboBox cbMaDanhGia;
        private Label lblSoLanGiaHan;
        private Label lblThoiGianGiaHan;
        private Label lblTruongHopDacBiet;
        private CheckBox cbTruongHopDacBiet;
        private Label lblHopLe;
        private Button btnGiaHan;
        private Button btnQuayLai;
    }
}
