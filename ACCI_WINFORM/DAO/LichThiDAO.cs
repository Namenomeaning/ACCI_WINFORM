using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class LichThiDAO
    {

        public string ThemLichThi(LichThi lichThi, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO LichThi (MaLichThi, MaDanhGia, MaPhongThi, NgayThi, GioThi, SoLuongMax, SoLuongDK, TrangThai) " +
                           "VALUES (@MaLichThi, @MaDanhGia, @MaPhongThi, @NgayThi, @GioThi, @SoLuongMax, @SoLuongDK, @TrangThai)";
            var parameters = new[]
            {
        new MySqlParameter("@MaLichThi", lichThi.MaLichThi),
        new MySqlParameter("@MaDanhGia", lichThi.MaDanhGia),
        new MySqlParameter("@MaPhongThi", lichThi.MaPhongThi),
        new MySqlParameter("@NgayThi", lichThi.NgayThi),
        new MySqlParameter("@GioThi", lichThi.GioThi),
        new MySqlParameter("@SoLuongMax", lichThi.SoLuongMax),
        new MySqlParameter("@SoLuongDK", lichThi.SoLuongDK),
        new MySqlParameter("@TrangThai", lichThi.TrangThai)
    };
            using var command = new MySqlCommand(query, connection, transaction);
            command.Parameters.AddRange(parameters);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0 ? lichThi.MaLichThi : null; // Return the generated MaLichThi
        }
        public DataTable LayLichThi(string maLichThi)
        {
            string query = "SELECT * FROM LichThi WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSLichThi()
        {
            string query = "SELECT * FROM LichThi";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public DataTable LayDSLichThiTheoDanhGia(string maDanhGia)
        {
            string query = "SELECT * FROM LichThi WHERE MaDanhGia = @MaDanhGia AND TrangThai = 'MoDangKy'"; // Consider making 'MoDangKy' a constant or enum
            var parameters = new[] { new MySqlParameter("@MaDanhGia", maDanhGia) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public int CapNhatLichThi(LichThi lichThi)
        {
            string query = "UPDATE LichThi SET MaDanhGia = @MaDanhGia, MaPhongThi = @MaPhongThi, NgayThi = @NgayThi, GioThi = @GioThi, SoLuongMax = @SoLuongMax, SoLuongDK = @SoLuongDK, TrangThai = @TrangThai WHERE MaLichThi = @MaLichThi";
            var parameters = new[]
            {
                new MySqlParameter("@MaLichThi", lichThi.MaLichThi),
                new MySqlParameter("@MaDanhGia", lichThi.MaDanhGia),
                new MySqlParameter("@MaPhongThi", lichThi.MaPhongThi),
                new MySqlParameter("@NgayThi", lichThi.NgayThi),
                new MySqlParameter("@GioThi", lichThi.GioThi),
                new MySqlParameter("@SoLuongMax", lichThi.SoLuongMax),
                new MySqlParameter("@SoLuongDK", lichThi.SoLuongDK),
                new MySqlParameter("@TrangThai", lichThi.TrangThai)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaLichThi(string maLichThi)
        {
            string query = "DELETE FROM LichThi WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int TangSoLuongDK(string maLichThi)
        {
            string query = "UPDATE LichThi SET SoLuongDK = SoLuongDK + 1 WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayNgayThi(string maLichThi) // Renamed from LayLichThi2 for clarity
        {
            string query = "SELECT NgayThi FROM LichThi WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}