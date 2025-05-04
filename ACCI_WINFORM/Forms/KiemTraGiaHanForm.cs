using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System;
using System.Windows.Forms;
using ACCI_WINFORM; // Để tham chiếu MainForm

namespace ACCI_WINFORM.Forms
{
    public partial class KiemTraGiaHanForm : Form
    {
        private readonly ThiSinhBUS thiSinhBus = new ThiSinhBUS();
        private readonly PhieuDKBUS phieuDKBus = new PhieuDKBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKBus = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiBus = new LichThiBUS();
        private readonly DanhGiaBUS danhGiaBus = new DanhGiaBUS();

        private string maPhieuDK;
        private string maLichThiCu;
        private int soLanGiaHanConLai;
        private DateTime thoiGianThi;
        private readonly string maNV;

        public KiemTraGiaHanForm(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            LoadDanhGia();
        }

        private void LoadDanhGia()
        {
            try
            {
                var danhSachDanhGia = danhGiaBus.LayDSDanhGia();
                if (danhSachDanhGia == null || danhSachDanhGia.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy danh sách đánh giá!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cbMaDanhGia.DataSource = danhSachDanhGia;
                cbMaDanhGia.DisplayMember = "TenDanhGia";
                cbMaDanhGia.ValueMember = "MaDanhGia";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đánh giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                // Reset UI
                lblSoLanGiaHan.Text = "Số lần gia hạn còn lại: ";
                lblThoiGianGiaHan.Text = "Thời gian gia hạn: ";
                lblHopLe.Text = "";
                btnGiaHan.Visible = false;

                // Validate input
                string maThiSinh = txtMaThiSinh.Text.Trim();
                if (string.IsNullOrWhiteSpace(maThiSinh))
                {
                    MessageBox.Show("Vui lòng nhập Mã Thí Sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maDanhGia = cbMaDanhGia.SelectedValue?.ToString();
                if (string.IsNullOrWhiteSpace(maDanhGia))
                {
                    MessageBox.Show("Vui lòng chọn Mã Đánh Giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if candidate exists using MaThiSinh
                var thiSinh = thiSinhBus.LayThiSinh(maThiSinh);
                if (thiSinh == null)
                {
                    MessageBox.Show("Không tìm thấy thí sinh với Mã Thí Sinh này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get PhieuDK and ChiTietPhieuDK
                var chiTietPhieuDK = chiTietPhieuDKBus.LayChiTietPhieuDKDangKyTheoMaThiSinh(thiSinh.MaThiSinh);
                if (chiTietPhieuDK == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu đăng ký cho thí sinh này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                maPhieuDK = chiTietPhieuDK.MaPhieuDK;
                maLichThiCu = chiTietPhieuDK.MaLichThi;

                // Get LichThi
                var lichThi = lichThiBus.LayLichThi(maLichThiCu);
                if (lichThi == null || lichThi.MaDanhGia != maDanhGia)
                {
                    MessageBox.Show("Không tìm thấy lịch thi phù hợp với mã đánh giá này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get PhieuDK to check remaining extensions
                var phieuDK = phieuDKBus.LayPhieuDK(maPhieuDK);
                if (phieuDK == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                soLanGiaHanConLai = phieuDK.SoLanGiaHan;
                thoiGianThi = lichThi.NgayThi.Date + lichThi.GioThi;

                // Display results
                lblSoLanGiaHan.Text = $"Số lần gia hạn còn lại: {soLanGiaHanConLai}";
                lblThoiGianGiaHan.Text = $"Thời gian gia hạn: {thoiGianThi:HH:mm dd/MM/yyyy}";

                // Check eligibility
                DateTime now = DateTime.Now;
                TimeSpan timeDifference = thoiGianThi.Date - now.Date;
                bool isEligible = soLanGiaHanConLai > 0 && timeDifference.TotalDays >= 1;

                if (isEligible)
                {
                    lblHopLe.Text = "Hợp Lệ";
                    btnGiaHan.Visible = true;
                }
                else
                {
                    lblHopLe.Text = "Không Hợp Lệ";
                    if (soLanGiaHanConLai <= 0)
                        MessageBox.Show("Đã hết số lần gia hạn cho phép!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show("Đã hết thời gian gia hạn (trước lịch thi ít nhất 1 ngày)!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            bool truongHopDacBiet = cbTruongHopDacBiet.Checked;
            using (var giaHanForm = new GiaHanThoiGianThiForm(maPhieuDK, maLichThiCu, truongHopDacBiet, maNV))
            {
                var result = giaHanForm.ShowDialog();
                if (result == DialogResult.OK) // Chỉ đóng nếu gia hạn thành công
                {
                    this.Close();
                }
            }
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }
    }
}