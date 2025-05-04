using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // For parameter building in LayDanhSachThiSinhTheoMa

namespace ACCI_WINFORM.DAO
{
    public class ThiSinhDAO
    {
        public string ThemThiSinh(ThiSinh thiSinh, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "INSERT INTO ThiSinh (MaThiSinh, HoTen, NgaySinh, GioiTinh) VALUES (@MaThiSinh, @HoTen, @NgaySinh, @GioiTinh)";
            var parameters = new[]
            {
        new MySqlParameter("@MaThiSinh", thiSinh.MaThiSinh),
        new MySqlParameter("@HoTen", thiSinh.HoTen),
        new MySqlParameter("@NgaySinh", thiSinh.NgaySinh ?? (object)DBNull.Value),
        new MySqlParameter("@GioiTinh", thiSinh.GioiTinh ?? (object)DBNull.Value)
    };
            using var command = new MySqlCommand(query, connection, transaction);
            command.Parameters.AddRange(parameters);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0 ? thiSinh.MaThiSinh : null; // Return the generated MaThiSinh
        }

        public DataTable LayThiSinh(string maThiSinh)
        {
            string query = "SELECT * FROM ThiSinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSThiSinh()
        {
            string query = "SELECT * FROM ThiSinh";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatThiSinh(ThiSinh thiSinh)
        {
            string query = "UPDATE ThiSinh SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[]
            {
                new MySqlParameter("@MaThiSinh", thiSinh.MaThiSinh),
                new MySqlParameter("@HoTen", thiSinh.HoTen),
                new MySqlParameter("@NgaySinh", thiSinh.NgaySinh ?? (object)DBNull.Value),
                new MySqlParameter("@GioiTinh", thiSinh.GioiTinh ?? (object)DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaThiSinh(string maThiSinh)
        {
            // Check dependencies (e.g., ChiTietPhieuDK) before deleting
            string query = "DELETE FROM ThiSinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayThiSinhTheoTieuChi(string maThiSinh, string hoTen)
        {
            string query = "SELECT MaThiSinh, HoTen FROM ThiSinh WHERE 1=1"; // Base query
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(maThiSinh))
            {
                query += " AND MaThiSinh LIKE @MaThiSinhPattern";
                parameters.Add(new MySqlParameter("@MaThiSinhPattern", $"%{maThiSinh}%"));
            }
            if (!string.IsNullOrEmpty(hoTen))
            {
                query += " AND HoTen LIKE @HoTenPattern";
                parameters.Add(new MySqlParameter("@HoTenPattern", $"%{hoTen}%"));
            }
            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        public DataTable LayDanhSachThiSinhTheoMa(List<string> maThiSinhList)
        {
            if (maThiSinhList == null || maThiSinhList.Count == 0)
            {
                // Return an empty DataTable with the expected structure
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("MaThiSinh", typeof(string));
                emptyDt.Columns.Add("HoTen", typeof(string));
                return emptyDt;
            }

            // Build parameterized query safely
            var parameters = new List<MySqlParameter>();
            string[] paramNames = new string[maThiSinhList.Count];
            for (int i = 0; i < maThiSinhList.Count; i++)
            {
                paramNames[i] = $"@MaThiSinh{i}";
                parameters.Add(new MySqlParameter(paramNames[i], maThiSinhList[i]));
            }

            string query = $"SELECT MaThiSinh, HoTen FROM ThiSinh WHERE MaThiSinh IN ({string.Join(",", paramNames)})";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }
    }
}