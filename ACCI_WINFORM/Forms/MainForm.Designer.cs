namespace ACCI_WINFORM
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            lblNhanVien = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            btnDangXuat = new Button();
            SuspendLayout();
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblNhanVien.Location = new Point(26, 22);
            lblNhanVien.Margin = new Padding(6, 0, 6, 0);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(225, 45);
            lblNhanVien.TabIndex = 1;
            lblNhanVien.Text = "Nhân viên: ";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(26, 123);
            flowLayoutPanel.Margin = new Padding(6, 7, 6, 7);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(1647, 862);
            flowLayoutPanel.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Font = new Font("Arial", 12F);
            btnDangXuat.Location = new Point(1408, 1009);
            btnDangXuat.Margin = new Padding(6, 7, 6, 7);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(260, 98);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1699, 1135);
            Controls.Add(btnDangXuat);
            Controls.Add(flowLayoutPanel);
            Controls.Add(lblNhanVien);
            Margin = new Padding(6, 7, 6, 7);
            Name = "MainForm";
            Text = "Hệ Thống Quản Lý ACCI";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnDangXuat;
    }
}