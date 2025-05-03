using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // For Sum()

namespace ACCI_WINFORM.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        private ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS(); // Dependency for details
        private DanhGiaBUS danhGiaBUS = new DanhGiaBUS();
        // Add dependencies for UuDaiBUS if needed for validation/calculation
        public string ThemHoaDon(string maPhieuDK, string maNhanVien)
        {
            // Lấy danh sách chi tiết phiếu đăng ký
            var chiTietPhieuDKBus = new ChiTietPhieuDKBUS();
            var danhSachChiTiet = chiTietPhieuDKBus.LayDSChiTietPhieuDK(maPhieuDK);

            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                return null; // Không có chi tiết để tạo hóa đơn
            }

            // Tính tổng tiền dựa trên thông tin đánh giá
            decimal tongTienGoc = 0;
            var chiTietHoaDonList = new List<ChiTietHoaDon>();

            foreach (var chiTiet in danhSachChiTiet)
            {
                var lichThiBus = new LichThiBUS();
                var lichThi = lichThiBus.LayLichThi(chiTiet.MaLichThi);

                if (lichThi != null)
                {
                    var danhGia = danhGiaBUS.LayDanhGia(lichThi.MaDanhGia);
                    if (danhGia != null)
                    {
                        var chiTietHoaDon = new ChiTietHoaDon
                        {
                            MaDanhGia = danhGia.MaDanhGia,
                            SoLuong = 1, // Mỗi chi tiết phiếu đăng ký tương ứng với 1 lượt đăng ký
                            DonGia = danhGia.DonGia
                        };
                        chiTietHoaDon.ThanhTien = chiTietHoaDon.SoLuong * chiTietHoaDon.DonGia;
                        tongTienGoc += chiTietHoaDon.ThanhTien;

                        chiTietHoaDonList.Add(chiTietHoaDon);
                    }
                }
            }

            // Tạo đối tượng hóa đơn
            var hoaDon = new HoaDon
            {
                MaPhieuDK = maPhieuDK,
                MaNV_KeToan = maNhanVien,
                NgayLap = DateTime.Now,
                TongTienGoc = tongTienGoc,
                SoTienGiam = 0, // Không áp dụng giảm giá
                TongThu = tongTienGoc,
                TrangThaiTT = "ChuaThanhToan"
            };

            // Gọi DAO để thêm hóa đơn
            if (hoaDonDAO.ThemHoaDon(hoaDon) > 0)
            {
                // Lấy mã hóa đơn vừa tạo
                var maHoaDon = hoaDon.MaHoaDon;

                // Thêm chi tiết hóa đơn
                foreach (var chiTietHoaDon in chiTietHoaDonList)
                {
                    chiTietHoaDon.MaHoaDon = maHoaDon;
                    chiTietHoaDonBUS.ThemChiTietHoaDon(chiTietHoaDon);
                }

                return maHoaDon; // Trả về mã hóa đơn
            }

            return null; // Thêm hóa đơn thất bại
        }

        public HoaDon LayHoaDon(string maHoaDon)
        {
            DataTable dt = hoaDonDAO.LayHoaDon(maHoaDon);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            // Optionally load details here as well
            // var hoaDon = MapDataRowToHoaDon(dt.Rows[0]);
            // hoaDon.ChiTietList = chiTietHoaDonBUS.LayDSChiTietHoaDon(maHoaDon); // Assuming HoaDon model has a list property
            return MapDataRowToHoaDon(dt.Rows[0]);
        }

        public List<HoaDon> LayDSHoaDon()
        {
            DataTable dt = hoaDonDAO.LayDSHoaDon();
            var hoaDonList = new List<HoaDon>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Optionally load details for each invoice
                    hoaDonList.Add(MapDataRowToHoaDon(row));
                }
            }
            return hoaDonList;
        }

        public bool CapNhatHoaDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTietList)
        {
            // --- Business Logic ---
            // 1. Validation
            if (hoaDon == null || string.IsNullOrWhiteSpace(hoaDon.MaHoaDon) || chiTietList == null) return false;
            // Cannot change MaHoaDon. Check if invoice is already paid?

            // 2. Recalculate totals
            hoaDon.TongTienGoc = chiTietList.Sum(ct => ct.SoLuong * ct.DonGia);
            hoaDon.SoTienGiam = TinhTienGiam(hoaDon.MaUuDai, hoaDon.TongTienGoc);
            hoaDon.TongThu = hoaDon.TongTienGoc - hoaDon.SoTienGiam;

            // --- Database Operations (Transaction Recommended) ---
            // 1. Update HoaDon Header
            int updateHeaderResult = hoaDonDAO.CapNhatHoaDon(hoaDon);
            if (updateHeaderResult <= 0) return false; // Update failed

            // 2. Update Details (Common approach: Delete existing, Insert new)
            bool deleteDetailsResult = chiTietHoaDonBUS.XoaChiTietTheoMaHoaDon(hoaDon.MaHoaDon);
            // Check deleteDetailsResult if needed, though proceeding might be acceptable if inserts handle uniqueness

            foreach (var chiTiet in chiTietList)
            {
                chiTiet.MaHoaDon = hoaDon.MaHoaDon; // Ensure link
                if (!chiTietHoaDonBUS.ThemChiTietHoaDon(chiTiet))
                {
                    // Handle error, rollback...
                    return false;
                }
            }

            return true; // Success
        }

        public bool CapNhatTrangThaiThanhToan(string maHoaDon, string phuongThuc, string maGiaoDich = null)
        {
            var hoaDon = LayHoaDon(maHoaDon);
            if (hoaDon == null || hoaDon.TrangThaiTT == "DaThanhToan")
            {
                return false; // Not found or already paid
            }

            hoaDon.TrangThaiTT = "DaThanhToan";
            hoaDon.NgayThanhToan = DateTime.Now;
            hoaDon.PhuongThuc = phuongThuc;
            hoaDon.MaGiaoDich = maGiaoDich; // Can be null for cash

            return hoaDonDAO.CapNhatHoaDon(hoaDon) > 0;
        }


        public bool XoaHoaDon(string maHoaDon)
        {
            // Business logic: Cannot delete if already paid?
            var hoaDon = LayHoaDon(maHoaDon);
            if (hoaDon != null && hoaDon.TrangThaiTT == "DaThanhToan")
            {
                return false;
            }

            // --- Database Operations (Transaction Recommended) ---
            // 1. Delete Details first
            bool deleteDetailsResult = chiTietHoaDonBUS.XoaChiTietTheoMaHoaDon(maHoaDon);
            // Handle deleteDetailsResult? If details fail to delete, should header be deleted?

            // 2. Delete Header
            int deleteHeaderResult = hoaDonDAO.XoaHoaDon(maHoaDon);

            return deleteHeaderResult > 0; // Return success if header deletion worked
        }

        // --- Helper Methods ---
        private decimal TinhTienGiam(string maUuDai, decimal tongTienGoc)
        {
            if (string.IsNullOrWhiteSpace(maUuDai)) return 0;

            UuDaiBUS uuDaiBus = new UuDaiBUS(); // Dependency
            var uuDai = uuDaiBus.LayUuDai(maUuDai);

            if (uuDai == null || uuDai.TrangThai != "HoatDong" || DateTime.Now < uuDai.NgayBD || DateTime.Now > uuDai.NgayKT)
            {
                return 0; // Invalid or inactive promotion
            }

            // Add logic based on uuDai.Loai ("PhanTram", "SoTien") and uuDai.GiaTri
            // Example:
            // if (uuDai.Loai == "PhanTram") {
            //     return tongTienGoc * (uuDai.GiaTri / 100);
            // } else if (uuDai.Loai == "SoTien") {
            //     return Math.Min(uuDai.GiaTri, tongTienGoc); // Cannot reduce below zero
            // }

            return 0; // Default if type not handled
        }

        // Kiểm tra phiếu đăng ký đã có hóa đơn hay chưa
        public bool KiemTraPhieuDKDaCoHoaDon(string maPhieuDK)
        {
            return hoaDonDAO.KiemTraPhieuDKDaCoHoaDon(maPhieuDK);
        }

        // Lấy hóa đơn theo mã phiếu đăng ký
        public HoaDon LayHoaDonTheoPhieuDK(string maPhieuDK)
        {
            return hoaDonDAO.LayHoaDonTheoPhieuDK(maPhieuDK);
        }

        private HoaDon MapDataRowToHoaDon(DataRow row)
        {
            return new HoaDon
            {
                MaHoaDon = row["MaHoaDon"].ToString(),
                MaPhieuDK = row["MaPhieuDK"] != DBNull.Value ? row["MaPhieuDK"].ToString() : null,
                MaPhieuGiaHan = row["MaPhieuGiaHan"] != DBNull.Value ? row["MaPhieuGiaHan"].ToString() : null,
                MaUuDai = row["MaUuDai"] != DBNull.Value ? row["MaUuDai"].ToString() : null,
                MaNV_KeToan = row["MaNV_KeToan"].ToString(),
                NgayLap = Convert.ToDateTime(row["NgayLap"]),
                PhuongThuc = row["PhuongThuc"].ToString(),
                MaGiaoDich = row["MaGiaoDich"] != DBNull.Value ? row["MaGiaoDich"].ToString() : null,
                TongTienGoc = Convert.ToDecimal(row["TongTienGoc"]),
                SoTienGiam = Convert.ToDecimal(row["SoTienGiam"]),
                TongThu = Convert.ToDecimal(row["TongThu"]),
                NgayThanhToan = row["NgayThanhToan"] != DBNull.Value ? Convert.ToDateTime(row["NgayThanhToan"]) : (DateTime?)null,
                TrangThaiTT = row["TrangThaiTT"].ToString()
            };
        }
    }
}