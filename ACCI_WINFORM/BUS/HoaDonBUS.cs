using ACCI_WINFORM.DAO;
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        private ChiTietHoaDonBUS chiTietHoaDonBUS = new ChiTietHoaDonBUS();
        private DanhGiaBUS danhGiaBUS = new DanhGiaBUS();

        public string ThemHoaDon(string maPhieuDK, string maNhanVien)
        {
            try
            {
                var chiTietPhieuDKBus = new ChiTietPhieuDKBUS();
                var danhSachChiTiet = chiTietPhieuDKBus.LayDSChiTietPhieuDK(maPhieuDK);

                if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
                {
                    Console.WriteLine("Không có chi tiết phiếu đăng ký để tạo hóa đơn.");
                    return null;
                }

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
                                SoLuong = 1,
                                DonGia = danhGia.DonGia
                            };
                            chiTietHoaDon.ThanhTien = chiTietHoaDon.SoLuong * chiTietHoaDon.DonGia;
                            tongTienGoc += chiTietHoaDon.ThanhTien;

                            chiTietHoaDonList.Add(chiTietHoaDon);
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy đánh giá cho lịch thi: {chiTiet.MaLichThi}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Không tìm thấy lịch thi: {chiTiet.MaLichThi}");
                    }
                }

                var hoaDon = new HoaDon
                {
                    MaPhieuDK = maPhieuDK,
                    MaNV_KeToan = maNhanVien,
                    NgayLap = DateTime.Now,
                    TongTienGoc = tongTienGoc,
                    SoTienGiam = 0,
                    TongThu = tongTienGoc,
                    TrangThaiTT = "ChuaTT"
                };

                int result = hoaDonDAO.ThemHoaDon(hoaDon);
                if (result > 0)
                {
                    var maHoaDon = hoaDon.MaHoaDon;

                    foreach (var chiTietHoaDon in chiTietHoaDonList)
                    {
                        chiTietHoaDon.MaHoaDon = maHoaDon;
                        if (!chiTietHoaDonBUS.ThemChiTietHoaDon(chiTietHoaDon))
                        {
                            Console.WriteLine($"Lỗi khi thêm chi tiết hóa đơn: {chiTietHoaDon.MaDanhGia}");
                        }
                    }

                    return maHoaDon;
                }
                else
                {
                    Console.WriteLine("Lỗi khi thêm hóa đơn vào cơ sở dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong ThemHoaDon: {ex.Message}");
            }

            return null;
        }

        public string ThemHoaDonTheoPhieuGiaHan(HoaDon hoaDon)
        {
            if (string.IsNullOrEmpty(hoaDon.MaPhieuGiaHan))
            {
                throw new ArgumentException("Mã phiếu gia hạn không được để trống khi tạo hóa đơn!");
            }

            hoaDon.MaPhieuDK = null;

            try
            {
                int result = hoaDonDAO.ThemHoaDon(hoaDon);
                if (result > 0)
                {
                    return hoaDon.MaHoaDon; // Trả về MaHoaDon đã được gán trong HoaDonDAO
                }
                throw new Exception("Không thể thêm hóa đơn vào cơ sở dữ liệu!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm hóa đơn theo phiếu gia hạn: {ex.Message}");
            }
        }

        public HoaDon LayHoaDon(string maHoaDon)
        {
            DataTable dt = hoaDonDAO.LayHoaDon(maHoaDon);
            if (dt == null || dt.Rows.Count == 0)
                return null;

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
                    hoaDonList.Add(MapDataRowToHoaDon(row));
                }
            }
            return hoaDonList;
        }

        public bool CapNhatHoaDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTietList)
        {
            if (hoaDon == null || string.IsNullOrWhiteSpace(hoaDon.MaHoaDon) || chiTietList == null) return false;

            hoaDon.TongTienGoc = chiTietList.Sum(ct => ct.SoLuong * ct.DonGia);
            hoaDon.SoTienGiam = TinhTienGiam(hoaDon.MaUuDai, hoaDon.TongTienGoc);
            hoaDon.TongThu = hoaDon.TongTienGoc - hoaDon.SoTienGiam;

            int updateHeaderResult = hoaDonDAO.CapNhatHoaDon(hoaDon);
            if (updateHeaderResult <= 0) return false;

            bool deleteDetailsResult = chiTietHoaDonBUS.XoaChiTietTheoMaHoaDon(hoaDon.MaHoaDon);

            foreach (var chiTiet in chiTietList)
            {
                chiTiet.MaHoaDon = hoaDon.MaHoaDon;
                if (!chiTietHoaDonBUS.ThemChiTietHoaDon(chiTiet))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CapNhatTrangThaiThanhToan(string maHoaDon, string phuongThuc, string maGiaoDich = null)
        {
            var hoaDon = LayHoaDon(maHoaDon);
            if (hoaDon == null || hoaDon.TrangThaiTT == "DaThanhToan")
            {
                return false;
            }

            hoaDon.TrangThaiTT = "DaThanhToan";
            hoaDon.NgayThanhToan = DateTime.Now;
            hoaDon.PhuongThuc = phuongThuc;
            hoaDon.MaGiaoDich = maGiaoDich;

            return hoaDonDAO.CapNhatHoaDon(hoaDon) > 0;
        }

        public bool XoaHoaDon(string maHoaDon)
        {
            var hoaDon = LayHoaDon(maHoaDon);
            if (hoaDon != null && hoaDon.TrangThaiTT == "DaThanhToan")
            {
                return false;
            }

            bool deleteDetailsResult = chiTietHoaDonBUS.XoaChiTietTheoMaHoaDon(maHoaDon);
            int deleteHeaderResult = hoaDonDAO.XoaHoaDon(maHoaDon);

            return deleteHeaderResult > 0;
        }

        private decimal TinhTienGiam(string maUuDai, decimal tongTienGoc)
        {
            if (string.IsNullOrWhiteSpace(maUuDai)) return 0;

            UuDaiBUS uuDaiBus = new UuDaiBUS();
            var uuDai = uuDaiBus.LayUuDai(maUuDai);

            if (uuDai == null || uuDai.TrangThai != "HoatDong" || DateTime.Now < uuDai.NgayBD || DateTime.Now > uuDai.NgayKT)
            {
                return 0;
            }

            return 0;
        }

        public bool KiemTraPhieuDKDaCoHoaDon(string maPhieuDK)
        {
            return hoaDonDAO.KiemTraPhieuDKDaCoHoaDon(maPhieuDK);
        }

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

        public bool CapNhatThanhToan(string maHoaDon, string phuongThuc, string maGiaoDich = null)
        {
            var hoaDon = LayHoaDon(maHoaDon);
            if (hoaDon == null || hoaDon.NgayThanhToan != null)
            {
                return false;
            }

            hoaDon.NgayThanhToan = DateTime.Now;
            hoaDon.PhuongThuc = phuongThuc;
            hoaDon.MaGiaoDich = maGiaoDich;

            hoaDon.TrangThaiTT = "DaTT";

            return hoaDonDAO.CapNhatHoaDon(hoaDon) > 0;
        }
    }
}