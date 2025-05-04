using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class PhieuDKDAO
    {
        public string ThemPhieuDK(PhieuDK phieuDK, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO PhieuDK (MaPhieuDK, MaKhachHang, MaNV_TiepNhan, NgayTao, SoLanGiaHan, TrangThai) " +
                           "VALUES (@MaPhieuDK, @MaKhachHang, @MaNV_TiepNhan, @NgayTao, @SoLanGiaHan, @TrangThai)";
            var parameters = new[]
            {
        new MySqlParameter("@MaPhieuDK", phieuDK.MaPhieuDK),
        new MySqlParameter("@MaKhachHang", phieuDK.MaKhachHang),
        new MySqlParameter("@MaNV_TiepNhan", phieuDK.MaNV_TiepNhan),
        new MySqlParameter("@NgayTao", phieuDK.NgayTao),
        new MySqlParameter("@SoLanGiaHan", phieuDK.SoLanGiaHan),
        new MySqlParameter("@TrangThai", phieuDK.TrangThai)
    };
            using var command = new MySqlCommand(query, connection, transaction);
            command.Parameters.AddRange(parameters);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0 ? phieuDK.MaPhieuDK : null; // Return the generated MaPhieuDK
        }
        public DataTable LayPhieuDK(string maPhieuDK)
        {
            string query = @"
                SELECT p.MaPhieuDK, p.MaKhachHang, p.MaNV_TiepNhan, p.NgayTao, p.SoLanGiaHan, p.TrangThai,
                       k.LoaiKhach, k.HoTen, k.TenDonVi, k.DiaChi, k.Email, k.DienThoai
                FROM PhieuDK p
                JOIN KhachHang k ON p.MaKhachHang = k.MaKhachHang
                WHERE p.MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSPhieuDK()
        {
            string query = @"
                SELECT p.MaPhieuDK, p.MaKhachHang, p.MaNV_TiepNhan, p.NgayTao, p.SoLanGiaHan, p.TrangThai,
                       k.LoaiKhach, k.HoTen, k.TenDonVi, k.DiaChi, k.Email, k.DienThoai
                FROM PhieuDK p
                JOIN KhachHang k ON p.MaKhachHang = k.MaKhachHang";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatPhieuDK(PhieuDK phieuDK)
        {
            string query = "UPDATE PhieuDK SET MaKhachHang = @MaKhachHang, MaNV_TiepNhan = @MaNV_TiepNhan, NgayTao = @NgayTao, SoLanGiaHan = @SoLanGiaHan, TrangThai = @TrangThai WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", phieuDK.MaPhieuDK),
                new MySqlParameter("@MaKhachHang", phieuDK.MaKhachHang),
                new MySqlParameter("@MaNV_TiepNhan", phieuDK.MaNV_TiepNhan),
                new MySqlParameter("@NgayTao", phieuDK.NgayTao),
                new MySqlParameter("@SoLanGiaHan", phieuDK.SoLanGiaHan),
                new MySqlParameter("@TrangThai", phieuDK.TrangThai)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaPhieuDK(string maPhieuDK)
        {
            string query = "DELETE FROM PhieuDK WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}