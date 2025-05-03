using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class HoaDonDAO
    {
        public int ThemHoaDon(HoaDon hoaDon)
        {
            string query = "INSERT INTO HoaDon (MaPhieuDK, MaPhieuGiaHan, MaUuDai, MaNV_KeToan, NgayLap, PhuongThuc, MaGiaoDich, TongTienGoc, SoTienGiam, TongThu, NgayThanhToan, TrangThaiTT) VALUES (@MaPhieuDK, @MaPhieuGiaHan, @MaUuDai, @MaNV_KeToan, @NgayLap, @PhuongThuc, @MaGiaoDich, @TongTienGoc, @SoTienGiam, @TongThu, @NgayThanhToan, @TrangThaiTT)";
            var parameters = MapHoaDonToParameters(hoaDon);
            parameters = parameters.Where(p => p.ParameterName != "@MaHoaDon").ToArray(); // Remove ID for insert
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
            // Consider returning the new MaHoaDon if it's auto-generated
        }

        public DataTable LayHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSHoaDon()
        {
            string query = "SELECT * FROM HoaDon";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatHoaDon(HoaDon hoaDon)
        {
            string query = "UPDATE HoaDon SET MaPhieuDK = @MaPhieuDK, MaPhieuGiaHan = @MaPhieuGiaHan, MaUuDai = @MaUuDai, MaNV_KeToan = @MaNV_KeToan, NgayLap = @NgayLap, PhuongThuc = @PhuongThuc, MaGiaoDich = @MaGiaoDich, TongTienGoc = @TongTienGoc, SoTienGiam = @SoTienGiam, TongThu = @TongThu, NgayThanhToan = @NgayThanhToan, TrangThaiTT = @TrangThaiTT WHERE MaHoaDon = @MaHoaDon";
            var parameters = MapHoaDonToParameters(hoaDon);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaHoaDon(string maHoaDon)
        {
            // Important: Deleting an invoice might require deleting its details first,
            // or setting up cascading deletes in the database.
            // This DAO method only deletes the main invoice record.
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map object to parameters
        private MySqlParameter[] MapHoaDonToParameters(HoaDon hoaDon)
        {
            return new[]
           {
                new MySqlParameter("@MaHoaDon", hoaDon.MaHoaDon), // Needed for update/delete
                new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhieuGiaHan", hoaDon.MaPhieuGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@MaUuDai", hoaDon.MaUuDai ?? (object)DBNull.Value),
                new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan),
                new MySqlParameter("@NgayLap", hoaDon.NgayLap),
                new MySqlParameter("@PhuongThuc", hoaDon.PhuongThuc),
                new MySqlParameter("@MaGiaoDich", hoaDon.MaGiaoDich ?? (object)DBNull.Value),
                new MySqlParameter("@TongTienGoc", hoaDon.TongTienGoc),
                new MySqlParameter("@SoTienGiam", hoaDon.SoTienGiam),
                new MySqlParameter("@TongThu", hoaDon.TongThu), // Should be calculated
                new MySqlParameter("@NgayThanhToan", hoaDon.NgayThanhToan ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiTT", hoaDon.TrangThaiTT)
            };
        }
    }
}