using ACCI_WINFORM.BUS;
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ACCI_WINFORM.Forms
{
    public partial class GiaHanThoiGianThiForm : Form
    {
        private readonly string maPhieuDK;
        private readonly string maLichThiCu;
        private readonly bool truongHopDacBiet;
        private readonly string maNV;

        private readonly ThiSinhBUS thiSinhBus = new ThiSinhBUS();
        private readonly ChiTietPhieuDKBUS chiTietPhieuDKBus = new ChiTietPhieuDKBUS();
        private readonly LichThiBUS lichThiBus = new LichThiBUS();
        private readonly DanhGiaBUS danhGiaBus = new DanhGiaBUS();
        private readonly PhieuDKBUS phieuDKBus = new PhieuDKBUS();
        private readonly PhieuGiaHanBUS phieuGiaHanBus = new PhieuGiaHanBUS();
        private readonly HoaDonBUS hoaDonBus = new HoaDonBUS();

        private ChiTietPhieuDK chiTietPhieuDK;
        private LichThi lichThiCu;
        private string maDanhGia;

        public GiaHanThoiGianThiForm(string maPhieuDK, string maLichThiCu, bool truongHopDacBiet, string maNV)
        {
            InitializeComponent();
            this.maPhieuDK = maPhieuDK;
            this.maLichThiCu = maLichThiCu;
            this.truongHopDacBiet = truongHopDacBiet;
            this.maNV = maNV;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var chiTietList = chiTietPhieuDKBus.LayDSChiTietPhieuDK(maPhieuDK);
                chiTietPhieuDK = chiTietList.FirstOrDefault(ct => ct.MaLichThi == maLichThiCu);
                if (chiTietPhieuDK == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu đăng ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var thiSinh = thiSinhBus.LayThiSinh(chiTietPhieuDK.MaThiSinh);
                if (thiSinh == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin thí sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lichThiCu = lichThiBus.LayLichThi(maLichThiCu);
                if (lichThiCu == null)
                {
                    MessageBox.Show("Không tìm thấy lịch thi cũ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                maDanhGia = lichThiCu.MaDanhGia;
                var danhGia = danhGiaBus.LayDanhGia(maDanhGia);
                if (danhGia == null)
                {
                    MessageBox.Show("Không tìm thấy mã đánh giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                dgvThongTin.Rows.Clear();
                dgvThongTin.Rows.Add(
                    1,
                    thiSinh.MaThiSinh,
                    thiSinh.HoTen,
                    thiSinh.NgaySinh?.ToString("dd/MM/yyyy") ?? "",
                    danhGia.MaDanhGia,
                    $"{lichThiCu.GioThi.Hours:D2}:{lichThiCu.GioThi.Minutes:D2} {lichThiCu.NgayThi:dd/MM/yyyy}"
                );

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
                var lichThiList = lichThiBus.LayDSLichThiMoDangKyTheoDanhGia(maDanhGia)
                    .Where(lt => lt != null && lt.MaLichThi != maLichThiCu &&
                                 (lt.NgayThi.Date > DateTime.Now.Date ||
                                  (lt.NgayThi.Date == DateTime.Now.Date && lt.GioThi > DateTime.Now.TimeOfDay)) &&
                                 lt.SoLuongDK < lt.SoLuongMax)
                    .ToList();

                if (lichThiList.Count == 0)
                {
                    MessageBox.Show("Không có lịch thi mới hợp lệ để gia hạn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cbLichThiMoi.DataSource = lichThiList;
                cbLichThiMoi.DisplayMember = "MaLichThi";
                cbLichThiMoi.ValueMember = "MaLichThi";

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
                PhieuGiaHan phieuGiaHan = new PhieuGiaHan
                {
                    MaPhieuDK = maPhieuDK,
                    ThuTu_CT = chiTietPhieuDK.ThuTu,
                    MaLichThi_Cu = maLichThiCu,
                    MaLichThi_Moi = maLichThiMoi,
                    LyDo = lyDo,
                    NgayYC = DateTime.Now,
                    MaNV_XuLy = maNV,
                    TrangThai = "ChoThanhToan",
                    MaPhiGiaHan = truongHopDacBiet ? null : "PHG1"
                };
                bool phieuGiaHanInserted = phieuGiaHanBus.ThemPhieuGiaHan(phieuGiaHan);
                if (!phieuGiaHanInserted)
                {
                    throw new Exception("Không thể tạo phiếu gia hạn!");
                }

                // Fetch the newly inserted MaPhieuGiaHan
                PhieuGiaHan newPhieuGiaHan = phieuGiaHanBus.LayPhieuGiaHanTheoMaPhieuDKVaLichThi(maPhieuDK, maLichThiCu, maLichThiMoi);
                if (newPhieuGiaHan == null)
                {
                    throw new Exception("Không thể lấy mã phiếu gia hạn vừa tạo!");
                }
                string newMaPhieuGiaHan = newPhieuGiaHan.MaPhieuGiaHan;

                // 2. Update PhieuDK (increment SoLanGiaHan)
                var phieuDK = phieuDKBus.LayPhieuDK(maPhieuDK);
                if (phieuDK == null)
                {
                    throw new Exception("Không tìm thấy phiếu đăng ký!");
                }
                phieuDK.SoLanGiaHan -= 1;
                if (!phieuDKBus.CapNhatPhieuDK(phieuDK))
                {
                    throw new Exception("Không thể cập nhật số lần gia hạn!");
                }

                // 3. Update ChiTietPhieuDK (update MaLichThi)
                chiTietPhieuDK.MaLichThi = maLichThiMoi;
                if (!chiTietPhieuDKBus.CapNhatChiTietPhieuDK(chiTietPhieuDK))
                {
                    throw new Exception("Không thể cập nhật chi tiết phiếu đăng ký!");
                }

                // 4. Update SoLuongDK for old LichThi
                var lichThiCuData = lichThiBus.LayLichThi(maLichThiCu);
                if (lichThiCuData == null)
                {
                    throw new Exception("Không tìm thấy lịch thi cũ để giảm số lượng đăng ký!");
                }
                if (lichThiCuData.SoLuongDK <= 0)
                {
                    throw new Exception($"Không thể giảm số lượng đăng ký cho lịch thi cũ ({maLichThiCu}) vì số lượng đăng ký hiện tại là {lichThiCuData.SoLuongDK}!");
                }
                if (!lichThiBus.GiamSoLuongDK(maLichThiCu))
                {
                    throw new Exception($"Không thể giảm số lượng đăng ký cho lịch thi cũ ({maLichThiCu})! Số lượng đăng ký hiện tại: {lichThiCuData.SoLuongDK}.");
                }

                // 5. Update SoLuongDK for new LichThi
                var lichThiMoiData = lichThiBus.LayLichThi(maLichThiMoi);
                if (lichThiMoiData == null)
                {
                    throw new Exception($"Không tìm thấy lịch thi mới ({maLichThiMoi}) để tăng số lượng đăng ký!");
                }
                if (lichThiMoiData.SoLuongDK >= lichThiMoiData.SoLuongMax)
                {
                    throw new Exception($"Không thể tăng số lượng đăng ký cho lịch thi mới ({maLichThiMoi}) vì đã đạt tối đa ({lichThiMoiData.SoLuongMax})!");
                }
                if (!lichThiBus.TangSoLuongDK(maLichThiMoi))
                {
                    throw new Exception($"Không thể tăng số lượng đăng ký cho lịch thi mới ({maLichThiMoi})! Số lượng hiện tại: {lichThiMoiData.SoLuongDK}.");
                }

                // 6. Insert into HoaDon (only if not a special case)
                if (!truongHopDacBiet)
                {
                    decimal donGia = phieuGiaHanBus.LayDonGiaPhiGiaHan("PHG1");
                    HoaDon hoaDon = new HoaDon
                    {
                        MaPhieuGiaHan = newMaPhieuGiaHan,
                        MaNV_KeToan = "NV2",
                        NgayLap = DateTime.Now,
                        TongTienGoc = donGia,
                        SoTienGiam = 0m,
                        TongThu = donGia,
                        TrangThaiTT = "ChuaTT"
                    };
                    Console.WriteLine($"Thêm hóa đơn: MaPhieuGiaHan={hoaDon.MaPhieuGiaHan}, MaNV_KeToan={hoaDon.MaNV_KeToan}, TongTienGoc={hoaDon.TongTienGoc}, SoTienGiam={hoaDon.SoTienGiam}, TongThu={hoaDon.TongThu}, TrangThaiTT={hoaDon.TrangThaiTT}");
                    string maHoaDon = hoaDonBus.ThemHoaDonTheoPhieuGiaHan(hoaDon);
                    if (string.IsNullOrEmpty(maHoaDon))
                    {
                        throw new Exception("Không thể tạo hóa đơn!");
                    }
                }

                MessageBox.Show("Gia hạn thời gian thi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}