using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class KhachHangDAO
    {
        public string ThemKhachHang(KhachHang khachHang, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO KhachHang (MaKhachHang, LoaiKhach, HoTen, TenDonVi, DiaChi, Email, DienThoai) VALUES (@MaKhachHang, @LoaiKhach, @HoTen, @TenDonVi, @DiaChi, @Email, @DienThoai)";
            var parameters = MapKhachHangToParameters(khachHang);
            using var command = new MySqlCommand(query, connection, transaction);
            command.Parameters.AddRange(parameters);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0 ? khachHang.MaKhachHang : null; // Return the generated MaKhachHang
        }

        public DataTable LayKhachHang(string maKhachHang)
        {
            string query = "SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            var parameters = new[] { new MySqlParameter("@MaKhachHang", maKhachHang) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSKhachHang()
        {
            string query = "SELECT * FROM KhachHang";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatKhachHang(KhachHang khachHang)
        {
            string query = "UPDATE KhachHang SET LoaiKhach = @LoaiKhach, HoTen = @HoTen, TenDonVi = @TenDonVi, DiaChi = @DiaChi, Email = @Email, DienThoai = @DienThoai WHERE MaKhachHang = @MaKhachHang";
            var parameters = MapKhachHangToParameters(khachHang);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaKhachHang(string maKhachHang)
        {
            // Add check for dependencies (e.g., PhieuDK) before deleting
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            var parameters = new[] { new MySqlParameter("@MaKhachHang", maKhachHang) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to create parameters
        private MySqlParameter[] MapKhachHangToParameters(KhachHang khachHang)
        {
            return new[]
            {
                new MySqlParameter("@MaKhachHang", khachHang.MaKhachHang),
                new MySqlParameter("@LoaiKhach", khachHang.LoaiKhach),
                new MySqlParameter("@HoTen", khachHang.HoTen ?? (object)DBNull.Value),
                new MySqlParameter("@TenDonVi", khachHang.TenDonVi ?? (object)DBNull.Value),
                new MySqlParameter("@DiaChi", khachHang.DiaChi),
                new MySqlParameter("@Email", khachHang.Email),
                new MySqlParameter("@DienThoai", khachHang.DienThoai)
            };
        }
    }
}