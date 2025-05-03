using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System.Data;

namespace ACCI_WINFORM.Forms
{
    public partial class MH_TraCuuPhieuDangKy : Form
    {
        private readonly PhieuDKBUS phieuDKBus = new PhieuDKBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKBus = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiBus = new LichThiBUS();
        private readonly HoaDonBUS hoaDonBus = new HoaDonBUS();

        private PhieuDK currentPhieuDK = null;
        private KhachHang currentKhachHang = null;
        private List<ChiTietPhieuDK> currentChiTietList = null;

        public MH_TraCuuPhieuDangKy()
        {
            InitializeComponent();
        }

        private void MH_TraCuuPhieuDangKy_Load(object sender, EventArgs e)
        {
            // Initialize controls
            SetupDataGridView();
            ClearFields();
        }

        private void SetupDataGridView()
        {
            // Configure the DataGridView for ChiTietPhieuDK
            dgvChiTietPhieu.AutoGenerateColumns = false;

            // Add columns
            if (dgvChiTietPhieu.Columns.Count == 0)
            {
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThuTu",
                    HeaderText = "Thứ tự",
                    DataPropertyName = "ThuTu"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaThiSinh",
                    HeaderText = "Mã thí sinh",
                    DataPropertyName = "MaThiSinh"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "HoTen",
                    HeaderText = "Họ tên",
                    DataPropertyName = "HoTen"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NgayThi",
                    HeaderText = "Ngày thi",
                    DataPropertyName = "NgayThi"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "GioThi",
                    HeaderText = "Giờ thi",
                    DataPropertyName = "GioThi"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoBaoDanh",
                    HeaderText = "Số báo danh",
                    DataPropertyName = "SoBaoDanh"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TrangThaiCT",
                    HeaderText = "Trạng thái",
                    DataPropertyName = "TrangThaiCT"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Diem",
                    HeaderText = "Điểm",
                    DataPropertyName = "Diem"
                });
                dgvChiTietPhieu.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "KetQua",
                    HeaderText = "Kết quả",
                    DataPropertyName = "KetQua"
                });
            }
        }

        private void ClearFields()
        {
            // Clear all fields
            txtMaPhieuDK.Clear();
            txtNgayTao.Clear();
            txtTrangThai.Clear();
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            txtLoaiKhach.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTenDonVi.Clear();

            // Clear DataGridView
            dgvChiTietPhieu.DataSource = null;

            // Disable buttons
            btnCapNhatTrangThai.Enabled = false;
            btnTaoHoaDon.Enabled = false;
            btnInPhieu.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maPhieuDK = txtMaPhieuDK.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPhieuDK))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fetch PhieuDK
            currentPhieuDK = phieuDKBus.LayPhieuDK(maPhieuDK);
            if (currentPhieuDK == null)
            {
                MessageBox.Show("Không tìm thấy phiếu đăng ký với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                return;
            }

            // Fetch KhachHang
            currentKhachHang = khachHangBus.LayKhachHang(currentPhieuDK.MaKhachHang);

            // Fetch ChiTietPhieuDK
            currentChiTietList = chiTietPhieuDKBus.LayDSChiTietPhieuDK(maPhieuDK);

            // Display data
            DisplayPhieuDKData();
            DisplayChiTietPhieuData();

            // Enable buttons
            btnCapNhatTrangThai.Enabled = true;
            btnInPhieu.Enabled = true;

            // Check if HoaDon exists
            bool existsHoaDon = hoaDonBus.KiemTraPhieuDKDaCoHoaDon(maPhieuDK);

            if (existsHoaDon)
            {
                btnTaoHoaDon.Text = "Xem hóa đơn";
                btnTaoHoaDon.Enabled = true;
            }
            else if (currentPhieuDK.TrangThai == "Moi")
            {
                btnTaoHoaDon.Text = "Tạo hóa đơn";
                btnTaoHoaDon.Enabled = true;
            }
            else
            {
                btnTaoHoaDon.Enabled = false;
            }
        }

        private void DisplayPhieuDKData()
        {
            if (currentPhieuDK == null || currentKhachHang == null) return;

            txtMaPhieuDK.Text = currentPhieuDK.MaPhieuDK;
            txtNgayTao.Text = currentPhieuDK.NgayTao.ToString("dd/MM/yyyy HH:mm");
            txtTrangThai.Text = currentPhieuDK.TrangThai;
            txtMaKhachHang.Text = currentKhachHang.MaKhachHang;
            txtTenKhachHang.Text = currentKhachHang.HoTen;
            txtLoaiKhach.Text = currentKhachHang.LoaiKhach == "TuDo" ? "Khách tự do" : "Khách đơn vị";
            txtDienThoai.Text = currentKhachHang.DienThoai;
            txtEmail.Text = currentKhachHang.Email;
            txtDiaChi.Text = currentKhachHang.DiaChi;
            txtTenDonVi.Text = currentKhachHang.TenDonVi;
        }

        private void DisplayChiTietPhieuData()
        {
            if (currentChiTietList == null || currentChiTietList.Count == 0) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("ThuTu", typeof(int));
            dt.Columns.Add("MaThiSinh", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("NgayThi", typeof(string));
            dt.Columns.Add("GioThi", typeof(string));
            dt.Columns.Add("SoBaoDanh", typeof(string));
            dt.Columns.Add("TrangThaiCT", typeof(string));
            dt.Columns.Add("Diem", typeof(decimal));
            dt.Columns.Add("KetQua", typeof(string));

            foreach (var chiTiet in currentChiTietList)
            {
                // Get ThiSinh info using a dedicated ThiSinhBUS instance
                var thiSinhBus = new ThiSinhBUS();
                var thiSinh = thiSinhBus.LayThiSinh(chiTiet.MaThiSinh);

                // Get LichThi info
                var lichThi = lichThiBus.LayLichThi(chiTiet.MaLichThi);

                string hoTen = thiSinh?.HoTen ?? "";
                string ngayThi = lichThi != null ? lichThi.NgayThi.ToString("dd/MM/yyyy") : "";
                string gioThi = lichThi != null ? lichThi.GioThi.ToString(@"hh\:mm") : "";

                dt.Rows.Add(
                    chiTiet.ThuTu,
                    chiTiet.MaThiSinh,
                    hoTen,
                    ngayThi,
                    gioThi,
                    chiTiet.SoBaoDanh,
                    chiTiet.TrangThaiCT,
                    chiTiet.Diem,
                    chiTiet.KetQua
                );
            }

            dgvChiTietPhieu.DataSource = dt;
        }

        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (currentPhieuDK == null) return;

            if (currentPhieuDK.TrangThai == "Huy")
            {
                MessageBox.Show("Phiếu đã bị hủy, không thể cập nhật trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a simple form to select new status
            using (Form frmStatus = new Form())
            {
                frmStatus.Text = "Cập nhật trạng thái";
                frmStatus.Size = new System.Drawing.Size(300, 200);
                frmStatus.StartPosition = FormStartPosition.CenterParent;
                frmStatus.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmStatus.MaximizeBox = false;
                frmStatus.MinimizeBox = false;

                ComboBox cboStatus = new ComboBox();
                cboStatus.Location = new System.Drawing.Point(20, 20);
                cboStatus.Size = new System.Drawing.Size(240, 30);
                cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cboStatus.Items.AddRange(new string[] { "Moi", "DaThanhToan", "Huy" });
                cboStatus.SelectedItem = currentPhieuDK.TrangThai;

                Button btnOK = new Button();
                btnOK.Text = "Cập nhật";
                btnOK.Location = new System.Drawing.Point(100, 80);
                btnOK.DialogResult = DialogResult.OK;

                frmStatus.Controls.Add(cboStatus);
                frmStatus.Controls.Add(btnOK);

                if (frmStatus.ShowDialog() == DialogResult.OK)
                {
                    string newStatus = cboStatus.SelectedItem.ToString();
                    if (newStatus != currentPhieuDK.TrangThai)
                    {
                        currentPhieuDK.TrangThai = newStatus;
                        if (phieuDKBus.CapNhatPhieuDK(currentPhieuDK))
                        {
                            MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisplayPhieuDKData();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            if (currentPhieuDK == null) return;

            // Kiểm tra nếu phiếu đã có hóa đơn
            bool existsHoaDon = hoaDonBus.KiemTraPhieuDKDaCoHoaDon(currentPhieuDK.MaPhieuDK);

            if (existsHoaDon)
            {
                // Xem hóa đơn
                HoaDon hoaDon = hoaDonBus.LayHoaDonTheoPhieuDK(currentPhieuDK.MaPhieuDK);
                if (hoaDon != null)
                {
                    // Mở form xem hóa đơn
                    //var hoaDonForm = new HoaDonForm(hoaDon.MaHoaDon);
                    //hoaDonForm.ShowDialog();
                    MessageBox.Show("Đã mở trang xem hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Không thể tải thông tin hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Tạo hóa đơn mới
                if (currentPhieuDK.TrangThai != "Moi")
                {
                    MessageBox.Show("Chỉ có thể tạo hóa đơn cho phiếu đăng ký có trạng thái 'Moi'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string maNhanVien = Utils.Session.CurrentUser?.MaNhanVien ?? "NV001";
                    string maHoaDon = hoaDonBus.ThemHoaDon(currentPhieuDK.MaPhieuDK, maNhanVien);

                    if (!string.IsNullOrEmpty(maHoaDon))
                    {
                        MessageBox.Show($"Đã tạo hóa đơn thành công với mã: {maHoaDon}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật UI để hiển thị "Xem hóa đơn"
                        btnTaoHoaDon.Text = "Xem hóa đơn";

                        // Hỏi người dùng có muốn mở hóa đơn ngay không
                        if (MessageBox.Show("Bạn có muốn xem hóa đơn vừa tạo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //var hoaDonForm = new HoaDonForm(maHoaDon);
                            //hoaDonForm.ShowDialog();
                            MessageBox.Show("Đã mở trang xem hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tạo hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (currentPhieuDK == null) return;

            MessageBox.Show("Tính năng in phiếu đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
            // Remove this line to prevent creating duplicate MainForm
            // new MainForm().Show();
        }

        private void MH_TraCuuPhieuDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Application.OpenForms.OfType<MainForm>().Any())
            {
                new MainForm().Show();
            }
        }
    }
}
