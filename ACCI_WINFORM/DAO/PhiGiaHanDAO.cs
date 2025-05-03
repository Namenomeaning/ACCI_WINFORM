using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class PhiGiaHanDAO
    {
        public int ThemPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            string query = "INSERT INTO PhiGiaHan (TenLoaiPhi, DonGia) VALUES (@TenLoaiPhi, @DonGia)";
            var parameters = MapPhiGiaHanToParameters(phiGiaHan);
            parameters = parameters.Where(p => p.ParameterName != "@MaPhiGiaHan").ToArray(); // Remove ID for insert
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayPhiGiaHan(string maPhiGiaHan)
        {
            string query = "SELECT * FROM PhiGiaHan WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhiGiaHan", maPhiGiaHan) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSPhiGiaHan()
        {
            string query = "SELECT * FROM PhiGiaHan";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            string query = "UPDATE PhiGiaHan SET TenLoaiPhi = @TenLoaiPhi, DonGia = @DonGia WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = MapPhiGiaHanToParameters(phiGiaHan);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaPhiGiaHan(string maPhiGiaHan)
        {
            // Check if this fee is used in any PhieuGiaHan or ChiTietHoaDon before deleting
            string query = "DELETE FROM PhiGiaHan WHERE MaPhiGiaHan = @MaPhiGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhiGiaHan", maPhiGiaHan) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map object to parameters
        private MySqlParameter[] MapPhiGiaHanToParameters(PhiGiaHan phiGiaHan)
        {
            return new[]
           {
                new MySqlParameter("@MaPhiGiaHan", phiGiaHan.MaPhiGiaHan), // Needed for update/delete
                new MySqlParameter("@TenLoaiPhi", phiGiaHan.TenLoaiPhi),
                new MySqlParameter("@DonGia", phiGiaHan.DonGia)
            };
        }
    }
}