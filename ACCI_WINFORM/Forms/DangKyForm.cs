using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ACCI_WINFORM.Forms
{
    public partial class DangKyForm : Form
    {
        private readonly KhachHangBUS khachHangDAO = new KhachHangBUS();
        private readonly ThiSinhBUS thiSinhDAO = new ThiSinhBUS();
        private readonly PhieuDKBUS phieuDKDAO = new PhieuDKBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKDAO = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiDAO = new LichThiBUS();
        private readonly DanhGiaBUS danhGiaDAO = new DanhGiaBUS();

        private List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();
        private string maNV_TiepNhan = "NV001"; // Giả định mã nhân viên tiếp nhận

        public DangKyForm()
        {
            InitializeComponent();
            KhoiTaoForm();
            DangKyForm_Load();
        }

        private void KhoiTaoForm()
        {
            this.Text = "Đăng Ký Thi";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DangKyForm_Load()
        {
            // Tải danh sách loại khách hàng
            cbLoaiKhachHang.Items.AddRange(new string[] { "Khách tự do", "Khách đơn vị" });
            cbLoaiKhachHang.SelectedIndex = 0;

            // Tải danh sách loại đánh giá
            var danhSachDanhGia = danhGiaDAO.LayDSDanhGia();
            cbLoaiDanhGia.DataSource = danhSachDanhGia;
            cbLoaiDanhGia.DisplayMember = "TenDanhGia";
            cbLoaiDanhGia.ValueMember = "MaDanhGia";

            // Tải danh sách lịch thi dựa trên loại đánh giá
            if (cbLoaiDanhGia.SelectedValue != null)
            {
                string maDanhGia = cbLoaiDanhGia.SelectedValue.ToString();
                var danhSachLichThi = lichThiDAO.LayDSLichThiMoDangKyTheoDanhGia(maDanhGia);
                cbLichThi.DataSource = danhSachLichThi;
                cbLichThi.DisplayMember = "NgayThi";
                cbLichThi.ValueMember = "MaLichThi";
            }

            // Tải danh sách giới tính
            cbGioiTinhThiSinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cbGioiTinhThiSinh.SelectedIndex = 0;

            // Cấu hình DataGridView
            dgvDanhSachThiSinh.Columns.Clear();
            dgvDanhSachThiSinh.Columns.Add("HoTen", "Họ Tên");
            dgvDanhSachThiSinh.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvDanhSachThiSinh.Columns.Add("GioiTinh", "Giới Tính");
        }

        private void CbLoaiKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isKhachTuDo = cbLoaiKhachHang.SelectedItem.ToString() == "Khách tự do";
            txtHoTen.Visible = isKhachTuDo;
            txtTenDonVi.Visible = !isKhachTuDo;
            txtDiaChi.Visible = !isKhachTuDo;
            cbLichThi.Visible = isKhachTuDo;
            txtLichThiMongMuon.Visible = !isKhachTuDo;
        }

        private void CbLoaiDanhGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiDanhGia.SelectedValue != null)
            {
                string maDanhGia = cbLoaiDanhGia.SelectedValue.ToString();
                var danhSachLichThi = lichThiDAO.LayDSLichThiMoDangKyTheoDanhGia(maDanhGia);
                cbLichThi.DataSource = danhSachLichThi;
                cbLichThi.DisplayMember = "NgayThi";
                cbLichThi.ValueMember = "MaLichThi";
            }
        }





        private void CapNhatDanhSachThiSinh()
        {
            dgvDanhSachThiSinh.Rows.Clear();
            foreach (var thiSinh in danhSachThiSinh)
            {
                string ns = thiSinh.NgaySinh?.ToString("dd/MM/yyyy") ?? "";
                dgvDanhSachThiSinh.Rows.Add(thiSinh.HoTen, thiSinh.GioiTinh, ns);
            }
        }




        private void btnThemThiSinh_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtTenThiSinh.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ tên thí sinh!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 2. Kiểm tra và parse ngày sinh (nếu có nhập)
            DateTime? ngaySinh = null;
            if (!string.IsNullOrWhiteSpace(txtNgaySinhThiSinh.Text))
            {
                try
                {
                    ngaySinh = DateTime.ParseExact(
                        txtNgaySinhThiSinh.Text.Trim(),
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    MessageBox.Show(
                        "Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            // 3. Tạo đối tượng ThiSinh và gán NgàySinh
            var thiSinh = new ThiSinh
            {
                HoTen = txtTenThiSinh.Text.Trim(),
                GioiTinh = cbGioiTinhThiSinh.SelectedItem?.ToString(),
                NgaySinh = ngaySinh
            };

            // 4. Thêm vào danh sách, cập nhật DataGridView
            danhSachThiSinh.Add(thiSinh);
            CapNhatDanhSachThiSinh();

            // 5. Reset lại input
            txtTenThiSinh.Clear();
            txtNgaySinhThiSinh.Clear();
        }

        private void btnXoaThiSinh_Click_1(object sender, EventArgs e)
        {
            if (dgvDanhSachThiSinh.SelectedRows.Count > 0)
            {
                int index = dgvDanhSachThiSinh.SelectedRows[0].Index;
                danhSachThiSinh.RemoveAt(index);
                CapNhatDanhSachThiSinh();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thí sinh để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin khách hàng
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Email và số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                var khachHang = new KhachHang
                {
                    LoaiKhach = cbLoaiKhachHang.SelectedItem.ToString() == "Khách tự do" ? "TuDo" : "DonVi",
                    HoTen = txtHoTen.Text,
                    TenDonVi = txtTenDonVi.Text,
                    DiaChi = txtDiaChi.Text,
                    Email = txtEmail.Text,
                    DienThoai = txtSoDienThoai.Text
                };

                if (cbLoaiKhachHang.SelectedItem.ToString() == "Khách tự do")
                {
                    // Đăng ký khách tự do
                    if (danhSachThiSinh.Count != 1)
                    {
                        MessageBox.Show("Khách tự do chỉ được đăng ký cho 1 thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (cbLichThi.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn lịch thi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var thiSinh = danhSachThiSinh[0];
                    string maLichThi = cbLichThi.SelectedValue.ToString();

                    thiSinhDAO.ThemThiSinh(thiSinh);
                    khachHangDAO.ThemKhachHang(khachHang);

                    var phieuDK = new PhieuDK
                    {
                        MaKhachHang = khachHang.MaKhachHang,
                        MaNV_TiepNhan = maNV_TiepNhan,
                        NgayTao = DateTime.Now,
                        SoLanGiaHan = 0,
                        TrangThai = "Moi"
                    };
                    phieuDKDAO.ThemPhieuDK(phieuDK);

                    var chiTiet = new ChiTietPhieuDK
                    {
                        MaPhieuDK = phieuDK.MaPhieuDK,
                        ThuTu = 1,
                        MaThiSinh = thiSinh.MaThiSinh,
                        MaLichThi = maLichThi,
                        TrangThaiCT = "DK",
                        MaNV_NhapLieu = maNV_TiepNhan
                    };
                    chiTietPhieuDKDAO.ThemChiTietPhieuDK(chiTiet);

                    lichThiDAO.TangSoLuongDK(maLichThi);
                }
                else
                {
                    // Đăng ký khách đơn vị
                    if (danhSachThiSinh.Count < 10)
                    {
                        MessageBox.Show("Khách đơn vị phải đăng ký ít nhất 10 thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime ngayThi;
                    TimeSpan gioThi;
                    try
                    {
                        string[] parts = txtLichThiMongMuon.Text.Split(' ');
                        ngayThi = DateTime.ParseExact(parts[0], "dd/MM/yyyy", null);
                        gioThi = TimeSpan.Parse(parts[1]);
                    }
                    catch
                    {
                        MessageBox.Show("Định dạng lịch thi mong muốn không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy HH:mm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string maDanhGia = cbLoaiDanhGia.SelectedValue.ToString();
                    string maPhongThi = "PT001"; // Giả định phòng thi

                    khachHangDAO.ThemKhachHang(khachHang);
                    foreach (var thiSinh in danhSachThiSinh)
                    {
                        thiSinhDAO.ThemThiSinh(thiSinh);
                    }

                    var lichThi = new LichThi
                    {
                        MaDanhGia = maDanhGia,
                        MaPhongThi = maPhongThi,
                        NgayThi = ngayThi,
                        GioThi = gioThi,
                        SoLuongMax = danhSachThiSinh.Count + 10,
                        SoLuongDK = danhSachThiSinh.Count,
                        TrangThai = "MoDangKy"
                    };
                    lichThiDAO.ThemLichThi(lichThi);

                    var phieuDK = new PhieuDK
                    {
                        MaKhachHang = khachHang.MaKhachHang,
                        MaNV_TiepNhan = maNV_TiepNhan,
                        NgayTao = DateTime.Now,
                        SoLanGiaHan = 0,
                        TrangThai = "Moi"
                    };
                    phieuDKDAO.ThemPhieuDK(phieuDK);

                    int thuTu = 1;
                    foreach (var thiSinh in danhSachThiSinh)
                    {
                        var chiTiet = new ChiTietPhieuDK
                        {
                            MaPhieuDK = phieuDK.MaPhieuDK,
                            ThuTu = thuTu++,
                            MaThiSinh = thiSinh.MaThiSinh,
                            MaLichThi = lichThi.MaLichThi,
                            TrangThaiCT = "DK",
                            MaNV_NhapLieu = maNV_TiepNhan
                        };
                        chiTietPhieuDKDAO.ThemChiTietPhieuDK(chiTiet);
                    }
                }

                MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                new MainForm().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new MainForm().Show();
        }
    }
}