using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class HoaDonDAO
    {
        public void ThemHoaDon(HoaDon hoaDon)
        {
            string query = "INSERT INTO HoaDon (MaPhieuDK, MaPhieuGiaHan, MaUuDai, MaNV_KeToan, NgayLap, PhuongThuc, MaGiaoDich, TongTienGoc, SoTienGiam, TongThu, NgayThanhToan, TrangThaiTT) VALUES (@MaPhieuDK, @MaPhieuGiaHan, @MaUuDai, @MaNV_KeToan, @NgayLap, @PhuongThuc, @MaGiaoDich, @TongTienGoc, @SoTienGiam, @TongThu, @NgayThanhToan, @TrangThaiTT)";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhieuGiaHan", hoaDon.MaPhieuGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@MaUuDai", hoaDon.MaUuDai ?? (object)DBNull.Value),
                new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan),
                new MySqlParameter("@NgayLap", hoaDon.NgayLap),
                new MySqlParameter("@PhuongThuc", hoaDon.PhuongThuc),
                new MySqlParameter("@MaGiaoDich", hoaDon.MaGiaoDich ?? (object)DBNull.Value),
                new MySqlParameter("@TongTienGoc", hoaDon.TongTienGoc),
                new MySqlParameter("@SoTienGiam", hoaDon.SoTienGiam),
                new MySqlParameter("@TongThu", hoaDon.TongThu),
                new MySqlParameter("@NgayThanhToan", hoaDon.NgayThanhToan ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiTT", hoaDon.TrangThaiTT)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public HoaDon LayHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
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

        public List<HoaDon> LayDSHoaDon()
        {
            string query = "SELECT * FROM HoaDon";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var hoaDonList = new List<HoaDon>();

            foreach (DataRow row in result.Rows)
            {
                hoaDonList.Add(new HoaDon
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
                });
            }
            return hoaDonList;
        }

        public void CapNhatHoaDon(HoaDon hoaDon)
        {
            string query = "UPDATE HoaDon SET MaPhieuDK = @MaPhieuDK, MaPhieuGiaHan = @MaPhieuGiaHan, MaUuDai = @MaUuDai, MaNV_KeToan = @MaNV_KeToan, NgayLap = @NgayLap, PhuongThuc = @PhuongThuc, MaGiaoDich = @MaGiaoDich, TongTienGoc = @TongTienGoc, SoTienGiam = @SoTienGiam, TongThu = @TongThu, NgayThanhToan = @NgayThanhToan, TrangThaiTT = @TrangThaiTT WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[]
            {
                new MySqlParameter("@MaHoaDon", hoaDon.MaHoaDon),
                new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhieuGiaHan", hoaDon.MaPhieuGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@MaUuDai", hoaDon.MaUuDai ?? (object)DBNull.Value),
                new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan),
                new MySqlParameter("@NgayLap", hoaDon.NgayLap),
                new MySqlParameter("@PhuongThuc", hoaDon.PhuongThuc),
                new MySqlParameter("@MaGiaoDich", hoaDon.MaGiaoDich ?? (object)DBNull.Value),
                new MySqlParameter("@TongTienGoc", hoaDon.TongTienGoc),
                new MySqlParameter("@SoTienGiam", hoaDon.SoTienGiam),
                new MySqlParameter("@TongThu", hoaDon.TongThu),
                new MySqlParameter("@NgayThanhToan", hoaDon.NgayThanhToan ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiTT", hoaDon.TrangThaiTT)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaHoaDon(string maHoaDon)
        {
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}