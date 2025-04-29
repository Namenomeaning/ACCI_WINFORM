using ACCI_WINFORM.Services;
using ACCI_WINFORM.Utils;
using ACCI_WINFORM.Forms;

namespace ACCI_WINFORM
{
    public partial class LoginForm : Form
    {
        private readonly LoginService _loginService;

        public LoginForm()
        {
            InitializeComponent();
            _loginService = new LoginService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _loginService.Authenticate(tenDangNhap, matKhau);
            if (user != null)
            {
                Session.CurrentUser = user;
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản không hoạt động.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}