using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System;
using System.Data;
using System.Windows.Forms;
using ACCI_WINFORM.Utils;


namespace ACCI_WINFORM.Forms
{
    public partial class TraCuuChungChiForm : Form
    {
        private readonly NhanVien _nhanVien;
        private readonly ThiSinhBUS thiSinhDAO = new ThiSinhBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKDAO = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiDAO = new LichThiBUS();
        private readonly ChungChiBUS chungChiDAO = new ChungChiBUS();

        public TraCuuChungChiForm()
        {
            InitializeComponent();
            _nhanVien = Session.CurrentUser;
            KhoiTaoForm();
        }

        private void KhoiTaoForm()
        {
            this.Text = "Tra cứu chứng chỉ";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Cấu hình DataGridView
            dgvDanhSachThiSinh.AutoGenerateColumns = false;
            dgvDanhSachThiSinh.AllowUserToAddRows = false;
            dgvDanhSachThiSinh.ReadOnly = true;

            // Thêm các cột vào DataGridView, đặt Name rõ ràng
            var colMaThiSinh = new DataGridViewTextBoxColumn { Name = "MaThiSinh", HeaderText = "Mã thí sinh", DataPropertyName = "MaThiSinh" };
            var colHoTen = new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ tên", DataPropertyName = "HoTen" };
            var colNgayThi = new DataGridViewTextBoxColumn { Name = "NgayThi", HeaderText = "Ngày thi", DataPropertyName = "NgayThi" };
            var colDiemSo = new DataGridViewTextBoxColumn { Name = "DiemSo", HeaderText = "Điểm số", DataPropertyName = "DiemSo" };
            var colKetQuaChamThi = new DataGridViewTextBoxColumn { Name = "KetQuaChamThi", HeaderText = "Kết quả chấm thi", DataPropertyName = "KetQuaChamThi" };
            var colMaChungChi = new DataGridViewTextBoxColumn { Name = "MaChungChi", HeaderText = "Mã chứng chỉ", DataPropertyName = "MaChungChi" };
            var colNgayCap = new DataGridViewTextBoxColumn { Name = "NgayCap", HeaderText = "Ngày cấp", DataPropertyName = "NgayCap" };
            var colNgayNhan = new DataGridViewTextBoxColumn { Name = "NgayNhan", HeaderText = "Ngày nhận", DataPropertyName = "NgayNhan" };
            var colTrangThaiNhan = new DataGridViewTextBoxColumn { Name = "TrangThaiNhan", HeaderText = "Trạng thái nhận", DataPropertyName = "TrangThaiNhan" };
            dgvDanhSachThiSinh.Columns.AddRange(colMaThiSinh, colHoTen, colNgayThi, colDiemSo, colKetQuaChamThi, colMaChungChi, colNgayCap, colNgayNhan, colTrangThaiNhan);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maThiSinh = txtMaThiSinh.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngayThi = txtNgayThi.Text.Trim();
            string soBaoDanh = txtSoBaoDanh.Text.Trim();

            // Kiểm tra định dạng ngày nếu có
            DateTime? dtNgayThi = null;
            if (!string.IsNullOrEmpty(ngayThi))
            {
                if (!DateTime.TryParse(ngayThi, out DateTime parsedDate))
                {
                    MessageBox.Show("Ngày thi không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dtNgayThi = parsedDate;
            }

            // 1. Lấy danh sách thí sinh từ ThiSinhDAO
            DataTable dtThiSinh = thiSinhDAO.LayThiSinhTheoTieuChi(maThiSinh, hoTen);
            if (dtThiSinh.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thí sinh phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Tạo DataTable kết quả
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("MaThiSinh", typeof(string));
            dtResult.Columns.Add("HoTen", typeof(string));
            dtResult.Columns.Add("NgayThi", typeof(DateTime));
            dtResult.Columns.Add("DiemSo", typeof(decimal));
            dtResult.Columns.Add("KetQuaChamThi", typeof(string));
            dtResult.Columns.Add("MaChungChi", typeof(string));
            dtResult.Columns.Add("NgayCap", typeof(DateTime));
            dtResult.Columns.Add("NgayNhan", typeof(DateTime));
            dtResult.Columns.Add("TrangThaiNhan", typeof(string));

            // 3. Duyệt qua từng thí sinh để lấy dữ liệu liên quan
            foreach (DataRow rowThiSinh in dtThiSinh.Rows)
            {
                string currentMaThiSinh = rowThiSinh["MaThiSinh"].ToString();

                // Lấy chi tiết phiếu đăng ký từ ChiTietPhieuDKDAO
                DataTable dtChiTiet = chiTietPhieuDKDAO.LayChiTietTheoThiSinhVaSoBaoDanh(currentMaThiSinh, soBaoDanh);
                foreach (DataRow rowChiTiet in dtChiTiet.Rows)
                {
                    string maLichThi = rowChiTiet["MaLichThi"].ToString();

                    // Lấy lịch thi từ LichThiDAO
                    DateTime? ngThi = lichThiDAO.LayNgayThi(maLichThi);
                    if (ngThi.HasValue)
                    {
                        DateTime lichThiNgayThi = ngThi.Value;
                        if (dtNgayThi == null || lichThiNgayThi.Date == dtNgayThi.Value.Date)
                        {
                            // Lấy chứng chỉ từ ChungChiDAO
                            string maPhieuDK = rowChiTiet["MaPhieuDK"].ToString();
                            int thuTu = Convert.ToInt32(rowChiTiet["ThuTu"]);
                            ChungChi rowChungChi = chungChiDAO.LayChungChi(maPhieuDK, thuTu);


                            // Thêm dòng vào dtResult
                            DataRow newRow = dtResult.NewRow();
                            newRow["MaThiSinh"] = currentMaThiSinh;
                            newRow["HoTen"] = rowThiSinh["HoTen"];
                            newRow["NgayThi"] = lichThiNgayThi;
                            newRow["DiemSo"] = rowChiTiet["Diem"] == DBNull.Value ? (object)DBNull.Value : Convert.ToDecimal(rowChiTiet["Diem"]);
                            newRow["KetQuaChamThi"] = rowChiTiet["KetQua"] == DBNull.Value ? (object)DBNull.Value : rowChiTiet["KetQua"];
                            if (rowChungChi != null)
                            {
                                newRow["MaChungChi"] = rowChungChi.SoHieu;
                                newRow["NgayCap"] = rowChungChi.NgayCap;
                                newRow["NgayNhan"] = rowChungChi.NgayNhan == null ? (object)DBNull.Value : rowChungChi.NgayNhan;
                                newRow["TrangThaiNhan"] = rowChungChi.TrangThaiNhan;
                            }
                            else
                            {
                                newRow["MaChungChi"] = DBNull.Value;
                                newRow["NgayCap"] = DBNull.Value;
                                newRow["NgayNhan"] = DBNull.Value;
                                newRow["TrangThaiNhan"] = DBNull.Value;
                            }
                            dtResult.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (dtResult.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thí sinh phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvDanhSachThiSinh.DataSource = dtResult;
            MessageBox.Show("Tải danh sách thí sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCapNhatTrangThai_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachThiSinh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRowView rowView = dgvDanhSachThiSinh.SelectedRows[0].DataBoundItem as DataRowView;
            string soHieu = rowView.Row["MaChungChi"].ToString();
            string trangThaiNhan = txtTrangThaiNhan.Text.Trim();

            if (string.IsNullOrEmpty(soHieu))
            {
                MessageBox.Show("Thí sinh này chưa có chứng chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(trangThaiNhan))
            {
                MessageBox.Show("Vui lòng nhập trạng thái nhận!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = chungChiDAO.CapNhatTrangThaiNhanTaiQuay(soHieu, _nhanVien.MaNhanVien);
            if (success)
            {
                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTimKiem_Click(sender, e); // Làm mới danh sách
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachThiSinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachThiSinh.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvDanhSachThiSinh.SelectedRows[0];
                // Sử dụng chỉ số cột thay vì tên để tránh lỗi
                int trangThaiNhanIndex = dgvDanhSachThiSinh.Columns["TrangThaiNhan"].Index;
                txtTrangThaiNhan.Text = row.Cells[trangThaiNhanIndex].Value?.ToString() ?? "";
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Hiển thị MainForm và đóng NhapKetQuaThiForm
            new MainForm().Show();
            this.Close();
        }
    }
}