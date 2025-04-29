using System;
using System.Windows.Forms;

namespace ACCI_WINFORM.Forms
{
    public partial class TemplateForm : Form
    {
        private Button btnBack;

        public TemplateForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Tạo nút "Quay Lại"
            btnBack = new Button
            {
                Text = "Quay Lại",
                Font = new System.Drawing.Font("Arial", 12F),
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(10, 10) // Vị trí góc trên bên trái
            };

            // Gắn sự kiện Click cho nút
            btnBack.Click += BtnBack_Click;

            // Thêm nút vào Form
            this.Controls.Add(btnBack);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Hiển thị MainForm và đóng TemplateForm
            new MainForm().Show();
            this.Close();
        }
    }
}
