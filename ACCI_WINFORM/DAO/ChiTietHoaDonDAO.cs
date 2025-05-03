using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class ChiTietHoaDonDAO
    {
        public int ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaDanhGia, MaPhiGiaHan, SoLuong, DonGia, ThanhTien) VALUES (@MaHoaDon, @MaDanhGia, @MaPhiGiaHan, @SoLuong, @DonGia, @ThanhTien)";
            var parameters = MapChiTietToParameters(chiTiet);
            parameters = parameters.Where(p => p.ParameterName != "@MaChiTietHoaDon").ToArray(); // Remove ID for insert
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayChiTietHoaDon(string maChiTietHoaDon)
        {
            string query = "SELECT * FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = new[] { new MySqlParameter("@MaChiTietHoaDon", maChiTietHoaDon) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSChiTietHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public int CapNhatChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "UPDATE ChiTietHoaDon SET MaHoaDon = @MaHoaDon, MaDanhGia = @MaDanhGia, MaPhiGiaHan = @MaPhiGiaHan, SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = MapChiTietToParameters(chiTiet);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaChiTietHoaDon(string maChiTietHoaDon)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = new[] { new MySqlParameter("@MaChiTietHoaDon", maChiTietHoaDon) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaChiTietHoaDonTheoMaHD(string maHoaDon)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }


        // Helper to map object to parameters
        private MySqlParameter[] MapChiTietToParameters(ChiTietHoaDon chiTiet)
        {
            return new[]
           {
                new MySqlParameter("@MaChiTietHoaDon", chiTiet.MaChiTietHoaDon), // Needed for update/delete
                new MySqlParameter("@MaHoaDon", chiTiet.MaHoaDon),
                new MySqlParameter("@MaDanhGia", chiTiet.MaDanhGia ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhiGiaHan", chiTiet.MaPhiGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@SoLuong", chiTiet.SoLuong),
                new MySqlParameter("@DonGia", chiTiet.DonGia),
                new MySqlParameter("@ThanhTien", chiTiet.ThanhTien) // Should be calculated SoLuong * DonGia
            };
        }
    }
}