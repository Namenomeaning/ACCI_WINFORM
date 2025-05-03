using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ACCI_WINFORM.Forms
{
    public partial class GiaHanThoiGianThiForm : Form
    {
        private readonly string maPhieuDK;
        private readonly string maLichThiCu;
        private readonly bool truongHopDacBiet;

        private readonly ThiSinhBUS thiSinhDAO = new ThiSinhBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKDAO = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiDAO = new LichThiBUS();
        private readonly DanhGiaBUS danhGiaDAO = new DanhGiaBUS();

        private ChiTietPhieuDK chiTietPhieuDK;
        private LichThi lichThiCu;
        private string maDanhGia;

        public GiaHanThoiGianThiForm(string maPhieuDK, string maLichThiCu, bool truongHopDacBiet)
        {
            InitializeComponent();
            this.maPhieuDK = maPhieuDK;
            this.maLichThiCu = maLichThiCu;
            this.truongHopDacBiet = truongHopDacBiet;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Get ChiTietPhieuDK for the given MaPhieuDK
                var chiTietList = chiTietPhieuDKDAO.LayDSChiTietPhieuDK(maPhieuDK);
                chiTietPhieuDK = chiTietList.FirstOrDefault(ct => ct.MaLichThi == maLichThiCu);
                if (chiTietPhieuDK == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Get ThiSinh
                var thiSinh = thiSinhDAO.LayThiSinh(chiTietPhieuDK.MaThiSinh);
                if (thiSinh == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Get old LichThi
                lichThiCu = lichThiDAO.LayLichThi(maLichThiCu);
                if (lichThiCu == null)
                {
                    MessageBox.Show("Không tìm thấy lịch thi cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Get DanhGia
                maDanhGia = lichThiCu.MaDanhGia;
                var danhGia = danhGiaDAO.LayDanhGia(maDanhGia);
                if (danhGia == null)
                {
                    MessageBox.Show("Không tìm thấy mã đánh giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate DataGridView
                dgvThongTin.Rows.Clear();
                dgvThongTin.Rows.Add(
                    1,
                    thiSinh.MaThiSinh,
                    thiSinh.HoTen,
                    thiSinh.NgaySinh?.ToString("dd/MM/yyyy") ?? "",
                    danhGia.MaDanhGia,
                    $"{lichThiCu.GioThi.Hours:D2}:{lichThiCu.GioThi.Minutes:D2} {lichThiCu.NgayThi:dd/MM/yyyy}"
                );

                // Load available LichThi for the same MaDanhGia
                LoadLichThiMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadLichThiMoi()
        {
            try
            {
                var lichThiList = lichThiDAO.LayDSLichThiMoDangKyTheoDanhGia(maDanhGia)
                    .Where(lt => lt.MaLichThi != maLichThiCu &&
                                 (lt.NgayThi.Date > DateTime.Now.Date ||
                                  (lt.NgayThi.Date == DateTime.Now.Date && lt.GioThi > DateTime.Now.TimeOfDay)) &&
                                 lt.SoLuongDK < lt.SoLuongMax)
                    .ToList();

                if (lichThiList.Count == 0)
                {
                    MessageBox.Show("Không có lịch thi mới hợp lệ để gia hạn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Bind the list to ComboBox and format the display text
                cbLichThiMoi.DataSource = lichThiList;
                cbLichThiMoi.DisplayMember = "MaLichThi";
                cbLichThiMoi.ValueMember = "MaLichThi";

                // Format the ComboBox items
                cbLichThiMoi.Format += (s, e) =>
                {
                    if (e.ListItem is LichThi lt)
                    {
                        e.Value = $"{lt.GioThi.Hours:D2}:{lt.GioThi.Minutes:D2} {lt.NgayThi:dd/MM/yyyy}";
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch thi mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLichThiMoi.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lịch thi mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maLichThiMoi = cbLichThiMoi.SelectedValue.ToString();

                // 1. Insert into PhieuGiaHan
                string lyDo = truongHopDacBiet ? "Đặc biệt" : "Không đặc biệt";
                string queryPhieuGiaHan = @"
                    INSERT INTO PhieuGiaHan (MaPhieuDK, ThuTu_CT, MaLichThi_Cu, MaLichThi_Moi, LyDo, NgayYC, MaNV_XuLy, TrangThai, MaPhiGiaHan)
                    VALUES (@MaPhieuDK, @ThuTu_CT, @MaLichThi_Cu, @MaLichThi_Moi, @LyDo, @NgayYC, @MaNV_XuLy, @TrangThai, @MaPhiGiaHan)";
                var parametersPhieuGiaHan = new[]
                {
                    new MySqlParameter("@MaPhieuDK", maPhieuDK),
                    new MySqlParameter("@ThuTu_CT", chiTietPhieuDK.ThuTu),
                    new MySqlParameter("@MaLichThi_Cu", maLichThiCu),
                    new MySqlParameter("@MaLichThi_Moi", maLichThiMoi),
                    new MySqlParameter("@LyDo", lyDo),
                    new MySqlParameter("@NgayYC", DateTime.Now),
                    new MySqlParameter("@MaNV_XuLy", "NV1"), // Placeholder
                    new MySqlParameter("@TrangThai", "ChoThanhToan"),
                    new MySqlParameter("@MaPhiGiaHan", truongHopDacBiet ? null : "PHG1")
                };
                DatabaseHelper.ExecuteQuery(queryPhieuGiaHan, parametersPhieuGiaHan);

                // 2. Update PhieuDK (increment SoLanGiaHan)
                string queryPhieuDK = "UPDATE PhieuDK SET SoLanGiaHan = SoLanGiaHan - 1 WHERE MaPhieuDK = @MaPhieuDK";
                var parametersPhieuDK = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
                DatabaseHelper.ExecuteQuery(queryPhieuDK, parametersPhieuDK);

                // 3. Update ChiTietPhieuDK (update MaLichThi)
                string queryChiTietPhieuDK = "UPDATE ChiTietPhieuDK SET MaLichThi = @MaLichThi WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
                var parametersChiTietPhieuDK = new[]
                {
                    new MySqlParameter("@MaLichThi", maLichThiMoi),
                    new MySqlParameter("@MaPhieuDK", maPhieuDK),
                    new MySqlParameter("@ThuTu", chiTietPhieuDK.ThuTu)
                };
                DatabaseHelper.ExecuteQuery(queryChiTietPhieuDK, parametersChiTietPhieuDK);

                // 4. Update SoLuongDK for old and new LichThi
                lichThiDAO.TangSoLuongDK(maLichThiMoi); // Increment SoLuongDK for new LichThi
                string queryDecreaseSoLuongDK = "UPDATE LichThi SET SoLuongDK = SoLuongDK - 1 WHERE MaLichThi = @MaLichThi AND SoLuongDK > 0";
                var parametersDecrease = new[] { new MySqlParameter("@MaLichThi", maLichThiCu) };
                DatabaseHelper.ExecuteQuery(queryDecreaseSoLuongDK, parametersDecrease); // Decrement SoLuongDK for old LichThi

                // 5. Insert into HoaDon (only if not a special case)
                if (!truongHopDacBiet)
                {
                    decimal donGia = GetPhiGiaHanDonGia("PHG1");
                    string queryHoaDon = @"
                        INSERT INTO HoaDon (MaPhieuGiaHan, MaNV_KeToan, NgayLap, TongTienGoc, SoTienGiam, TongThu, TrangThaiTT)
                        VALUES (@MaPhieuGiaHan, @MaNV_KeToan, @NgayLap, @TongTienGoc, @SoTienGiam, @TongThu, @TrangThaiTT)";
                    var parametersHoaDon = new[]
                    {
                        new MySqlParameter("@MaPhieuGiaHan", $"PGH{GetLastPhieuGiaHanId()}"),
                        new MySqlParameter("@MaNV_KeToan", "NV2"),
                        new MySqlParameter("@NgayLap", DateTime.Now),
                        new MySqlParameter("@TongTienGoc", donGia),
                        new MySqlParameter("@SoTienGiam", "0"),
                        new MySqlParameter("@TongThu", donGia),
                        new MySqlParameter("@TrangThaiTT", "ChuaTT")
                    };
                    DatabaseHelper.ExecuteQuery(queryHoaDon, parametersHoaDon);
                }

                MessageBox.Show("Gia hạn thời gian thi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetPhiGiaHanDonGia(string maPhiGiaHan)
        {
            string query = "SELECT DonGia FROM PhiGiaHan WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhiGiaHan", maPhiGiaHan) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
            {
                throw new Exception($"Không tìm thấy phí gia hạn với mã {maPhiGiaHan}");
            }

            return Convert.ToDecimal(result.Rows[0]["DonGia"]);
        }

        private int GetLastPhieuGiaHanId()
        {
            string query = "SELECT MaPhieuGiaHan FROM PhieuGiaHan WHERE MaPhieuGiaHan LIKE 'PGH%' ORDER BY CAST(SUBSTRING(MaPhieuGiaHan, 4) AS UNSIGNED) DESC LIMIT 1";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            if (result.Rows.Count == 0)
            {
                return 1;
            }
            string lastMaPhieuGiaHan = result.Rows[0]["MaPhieuGiaHan"].ToString();
            return int.Parse(lastMaPhieuGiaHan.Substring(3));
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}