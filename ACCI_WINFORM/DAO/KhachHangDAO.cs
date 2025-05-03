using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class KhachHangDAO
    {
        public int ThemKhachHang(KhachHang khachHang)
        {
            string query = "INSERT INTO KhachHang (LoaiKhach, HoTen, TenDonVi, DiaChi, Email, DienThoai) VALUES (@LoaiKhach, @HoTen, @TenDonVi, @DiaChi, @Email, @DienThoai)";
            var parameters = MapKhachHangToParameters(khachHang);
            parameters = parameters.Where(p => p.ParameterName != "@MaKhachHang").ToArray(); // Remove MaKhachHang for INSERT
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
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
                new MySqlParameter("@MaKhachHang", khachHang.MaKhachHang), // Include for UPDATE/DELETE checks
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