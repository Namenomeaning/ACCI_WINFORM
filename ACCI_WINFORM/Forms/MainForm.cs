using ACCI_WINFORM.Forms;
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using System;
using System.Windows.Forms;

namespace ACCI_WINFORM
{
    public partial class MainForm : Form
    {
        private readonly NhanVien _nhanVien;
 
        public MainForm()
        {
            InitializeComponent();
            _nhanVien = Session.CurrentUser;
            SetupMainForm();
        }

        private void SetupMainForm()
        {
            lblNhanVien.Text = $"Nhân viên: {_nhanVien.HoTen} ({_nhanVien.VaiTro})";
            flowLayoutPanel.Controls.Clear();

            switch (_nhanVien.VaiTro)
            {
                case "TiepNhan":
                    AddButton("Lập Phiếu Đăng Ký", () => new DangKyForm().Show());
                    AddButton("Tra Cứu Chứng Chỉ", () => new TraCuuChungChiForm().Show());
                    AddButton("Gia Hạn Thời Gian Thi", () => new KiemTraGiaHanForm(_nhanVien.MaNhanVien).Show());
                    break;
                case "KeToan":
                    AddButton("Tra Cứu Phiếu Đăng Ký", () => new TraCuuPhieuDangKyForm().Show());
                    break;
                case "NhapLieu":
                    AddButton("Nhập Kết Quả Thi", () => new NhapKetQuaThiForm().Show());
                    break;
            }
        }

        private void AddButton(string text, Action onClick)
        {
            var button = new Button
            {
                Text = text,
                Size = new System.Drawing.Size(200, 50),
                Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular)
            };
            button.Click += (s, e) =>
            {
                onClick();
                this.Close();
            };
            flowLayoutPanel.Controls.Add(button);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}