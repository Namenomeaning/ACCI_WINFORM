using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class DanhGiaDAO
    {
        public int ThemDanhGia(DanhGia danhGia)
        {
            string query = "INSERT INTO DanhGia (TenDanhGia, MoTa, DonGia) VALUES (@TenDanhGia, @MoTa, @DonGia)";
            var parameters = new[]
            {
                new MySqlParameter("@TenDanhGia", danhGia.TenDanhGia),
                new MySqlParameter("@MoTa", danhGia.MoTa ?? (object)DBNull.Value),
                new MySqlParameter("@DonGia", danhGia.DonGia)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayDanhGia(string maDanhGia)
        {
            string query = "SELECT * FROM DanhGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[] { new MySqlParameter("@MaDanhGia", maDanhGia) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSDanhGia()
        {
            string query = "SELECT * FROM DanhGia";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatDanhGia(DanhGia danhGia)
        {
            string query = "UPDATE DanhGia SET TenDanhGia = @TenDanhGia, MoTa = @MoTa, DonGia = @DonGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[]
            {
                new MySqlParameter("@MaDanhGia", danhGia.MaDanhGia),
                new MySqlParameter("@TenDanhGia", danhGia.TenDanhGia),
                new MySqlParameter("@MoTa", danhGia.MoTa ?? (object)DBNull.Value),
                new MySqlParameter("@DonGia", danhGia.DonGia)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaDanhGia(string maDanhGia)
        {
            // Consider potential foreign key constraints before deleting
            string query = "DELETE FROM DanhGia WHERE MaDanhGia = @MaDanhGia";
            var parameters = new[] { new MySqlParameter("@MaDanhGia", maDanhGia) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}