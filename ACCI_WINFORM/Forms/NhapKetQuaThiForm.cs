using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;
using ACCI_WINFORM.DataAccess;
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;

namespace ACCI_WINFORM.Forms
{
    public partial class NhapKetQuaThiForm : Form
    {
        private readonly NhanVien _nhanVien;
        private readonly LichThiDAO lichThiDAO = new LichThiDAO();
        private readonly ThiSinhDAO thiSinhDAO = new ThiSinhDAO();
        private readonly ChiTietPhieuDKDAO chiTietPhieuDKDAO = new ChiTietPhieuDKDAO();
        private readonly DanhGiaDAO danhGiaDAO = new DanhGiaDAO();
        private readonly ChungChiDAO chungChiDAO = new ChungChiDAO();
        public NhapKetQuaThiForm()
        {
            InitializeComponent();
            _nhanVien = Session.CurrentUser;
            KhoiTaoForm();
        }

        private void KhoiTaoForm()
        {
            this.Text = "Nhập Kết Quả Thi";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configure DataGridView
            dgvDanhSachThiSinh.AutoGenerateColumns = false;
            dgvDanhSachThiSinh.AllowUserToAddRows = false;
            dgvDanhSachThiSinh.ReadOnly = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maLichThi = txtMaLichThi.Text.Trim();
            if (string.IsNullOrEmpty(maLichThi))
            {
                lblTrangThai.Text = "Vui lòng nhập mã lịch thi.";
                lblTrangThai.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Lấy danh sách MaThiSinh từ ChiTietPhieuDK theo MaLichThi
            string queryMaThiSinh = @"SELECT DISTINCT MaThiSinh 
                                     FROM ChiTietPhieuDK 
                                     WHERE MaLichThi = @MaLichThi";
            var parametersMa = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            DataTable dtMaThiSinh = DatabaseHelper.ExecuteQuery(queryMaThiSinh, parametersMa);
            var maThiSinhList = dtMaThiSinh.AsEnumerable().Select(row => row["MaThiSinh"].ToString()).ToList();

            // Lấy thông tin thí sinh từ ThiSinhDAO
            DataTable thiSinhData = thiSinhDAO.LayDanhSachThiSinhTheoMa(maThiSinhList);

            // Gọi ChiTietPhieuDKDAO với thiSinhData
            DataTable dt = chiTietPhieuDKDAO.LayDanhSachThiSinhTheoLichThi(maLichThi, thiSinhData);
            if (dt.Rows.Count == 0)
            {
                lblTrangThai.Text = "Không tìm thấy thí sinh cho mã lịch thi này.";
                lblTrangThai.ForeColor = System.Drawing.Color.Red;
                txtTenDanhGia.Text = "";
                return;
            }

            // Log DataTable column names
            string dtColumnNames = string.Join(", ", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            System.Diagnostics.Debug.WriteLine($"DataTable columns: {dtColumnNames}");

            // Clear existing columns to avoid conflicts
            dgvDanhSachThiSinh.Columns.Clear();
            // Re-add columns
            var colMaThiSinh = new DataGridViewTextBoxColumn { HeaderText = "Mã thí sinh", DataPropertyName = "MaThiSinh" };
            var colHoTen = new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen" };
            var colSoBaoDanh = new DataGridViewTextBoxColumn { HeaderText = "Số báo danh", DataPropertyName = "SoBaoDanh" };
            var colDiem = new DataGridViewTextBoxColumn { HeaderText = "Điểm", DataPropertyName = "Diem" };
            dgvDanhSachThiSinh.Columns.AddRange(colMaThiSinh, colHoTen, colSoBaoDanh, colDiem);

            // Bind data
            dgvDanhSachThiSinh.DataSource = dt;

            // Log DataGridView column names
            string gridColumnNames = string.Join(", ", dgvDanhSachThiSinh.Columns.Cast<DataGridViewColumn>().Select(c => c.DataPropertyName));
            System.Diagnostics.Debug.WriteLine($"DataGridView columns: {gridColumnNames}");

            // Load evaluation name
            LichThi lichThi = lichThiDAO.LayLichThi(maLichThi);
            if (lichThi != null)
            {
                var danhGia = danhGiaDAO.LayDanhGia(lichThi.MaDanhGia);
                txtTenDanhGia.Text = danhGia != null ? danhGia.TenDanhGia : "Không tìm thấy đánh giá";
            }
            else
            {
                txtTenDanhGia.Text = "Không tìm thấy lịch thi";
            }

            lblTrangThai.Text = "Tải danh sách thí sinh thành công.";
            lblTrangThai.ForeColor = System.Drawing.Color.Green;
        }

        private void dgvDanhSachThiSinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachThiSinh.SelectedRows.Count > 0 && dgvDanhSachThiSinh.DataSource != null)
            {
                DataGridViewRow row = dgvDanhSachThiSinh.SelectedRows[0];
                try
                {
                    txtMaThiSinh.Text = row.Cells[0].Value?.ToString() ?? "";
                    txtHoTen.Text = row.Cells[1].Value?.ToString() ?? "";
                    txtSoBaoDanh.Text = row.Cells[2].Value?.ToString() ?? "";

                    string maLichThi = txtMaLichThi.Text.Trim();
                    LichThi lichThi = lichThiDAO.LayLichThi(maLichThi);
                    if (lichThi != null)
                    {
                        txtNgayThi.Text = lichThi.NgayThi.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtNgayThi.Text = "";
                    }

                    object diem = row.Cells[3].Value;
                    txtDiem.Text = diem != DBNull.Value ? diem.ToString() : "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi truy cập dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachThiSinh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView rowView = dgvDanhSachThiSinh.SelectedRows[0].DataBoundItem as DataRowView;
            string maPhieuDK = rowView.Row["MaPhieuDK"].ToString();
            int thuTu = Convert.ToInt32(rowView.Row["ThuTu"]);
            string maThiSinh = rowView.Row["MaThiSinh"].ToString();

            if (!double.TryParse(txtDiem.Text, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm số không hợp lệ! Vui lòng nhập số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác định kết quả (giả sử điểm >= 5.0 là "Đạt")
            string ketQua = (diem >= 5.0) ? "Dat" : "KhongDat";

            // Cập nhật điểm và kết quả vào cơ sở dữ liệu
            bool success = chiTietPhieuDKDAO.CapNhatDiemThi(maPhieuDK, thuTu, diem, _nhanVien.MaNhanVien);
            if (success)
            {
                MessageBox.Show("Lưu điểm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTimKiem_Click(sender, e); // Làm mới danh sách

                // Nếu kết quả là "Đạt", tạo chứng chỉ mới
                if (ketQua == "Dat")
                {
                    string soHieu = TaoSoHieuChungChi();
                    DateTime ngayCap = DateTime.Now;

                    // Tạo đối tượng ChungChi
                    ChungChi chungChi = new ChungChi
                    {
                        SoHieu = soHieu,
                        MaPhieuDK = maPhieuDK,
                        ThuTu = thuTu,
                        MaThiSinh = maThiSinh,
                        NgayCap = ngayCap,
                        NgayHetHan = null,
                        PhuongThucNhan = "TaiTT",
                        DiaChiNhan = null,
                        NgayNhan = null,
                        TrangThaiNhan = "ChuaNhan",
                        MaNV_CapNhat = null
                    };

                    // Thêm chứng chỉ vào cơ sở dữ liệu
                    try
                    {
                        chungChiDAO.ThemChungChi(chungChi);
                        MessageBox.Show("Tạo chứng chỉ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tạo chứng chỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lưu điểm thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string TaoSoHieuChungChi()
        {
            // Lấy năm hiện tại
            int namHienTai = DateTime.Now.Year;
            string prefix = $"CC{namHienTai}"; // Ví dụ: "CC2025"

            // Truy vấn SQL để tìm số thứ tự lớn nhất trong năm hiện tại
            string query = "SELECT MAX(CAST(SUBSTRING(SoHieu, 8) AS UNSIGNED)) FROM ChungChi WHERE SoHieu LIKE @Prefix";
            var parameters = new[] { new MySqlParameter("@Prefix", prefix + "%") };
            DataTable resultTable = DatabaseHelper.ExecuteQuery(query, parameters);

            // Kiểm tra và lấy giá trị số thứ tự lớn nhất
            int soThuTu = 1; // Giá trị mặc định nếu không có chứng chỉ nào
            if (resultTable.Rows.Count > 0 && resultTable.Rows[0][0] != DBNull.Value)
            {
                soThuTu = Convert.ToInt32(resultTable.Rows[0][0]) + 1;
            }

            // Tạo số hiệu với 4 chữ số cho số thứ tự (ví dụ: "0001", "0002")
            return prefix + soThuTu.ToString("D4");
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }

        private void NhapKetQuaThiForm_Load(object sender, EventArgs e)
        {

        }
    }
}