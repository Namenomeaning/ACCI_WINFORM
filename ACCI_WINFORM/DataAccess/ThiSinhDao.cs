using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class ThiSinhDAO
    {
        public void ThemThiSinh(ThiSinh thiSinh)
        {
            string query = "INSERT INTO ThiSinh (HoTen, NgaySinh, GioiTinh) VALUES (@HoTen, @NgaySinh, @GioiTinh)";
            var parameters = new[]
            {
                new MySqlParameter("@HoTen", thiSinh.HoTen),
                new MySqlParameter("@NgaySinh", thiSinh.NgaySinh ?? (object)DBNull.Value),
                new MySqlParameter("@GioiTinh", thiSinh.GioiTinh ?? (object)DBNull.Value)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public ThiSinh LayThiSinh(string maThiSinh)
        {
            string query = "SELECT * FROM ThiSinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ThiSinh
            {
                MaThiSinh = row["MaThiSinh"].ToString(),
                HoTen = row["HoTen"].ToString(),
                NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                GioiTinh = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : null
            };
        }

        public List<ThiSinh> LayDSThiSinh()
        {
            string query = "SELECT * FROM ThiSinh";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var thiSinhList = new List<ThiSinh>();

            foreach (DataRow row in result.Rows)
            {
                thiSinhList.Add(new ThiSinh
                {
                    MaThiSinh = row["MaThiSinh"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                    GioiTinh = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : null
                });
            }
            return thiSinhList;
        }

        public void CapNhatThiSinh(ThiSinh thiSinh)
        {
            string query = "UPDATE ThiSinh SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[]
            {
                new MySqlParameter("@MaThiSinh", thiSinh.MaThiSinh),
                new MySqlParameter("@HoTen", thiSinh.HoTen),
                new MySqlParameter("@NgaySinh", thiSinh.NgaySinh ?? (object)DBNull.Value),
                new MySqlParameter("@GioiTinh", thiSinh.GioiTinh ?? (object)DBNull.Value)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaThiSinh(string maThiSinh)
        {
            string query = "DELETE FROM ThiSinh WHERE MaThiSinh = @MaThiSinh";
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayThiSinhTheoTieuChi(string maThiSinh, string hoTen)
        {
            string query = "SELECT MaThiSinh, HoTen FROM ThiSinh WHERE 1=1";
            if (!string.IsNullOrEmpty(maThiSinh))
            {
                query += " AND MaThiSinh LIKE @MaThiSinh";
            }
            if (!string.IsNullOrEmpty(hoTen))
            {
                query += " AND HoTen LIKE @HoTen";
            }
            var parameters = new[]
            {
            new MySqlParameter("@MaThiSinh", $"%{maThiSinh}%"),
            new MySqlParameter("@HoTen", $"%{hoTen}%")
        };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }
        public DataTable LayDanhSachThiSinhTheoMa(List<string> maThiSinhList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaThiSinh", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));

            if (maThiSinhList == null || maThiSinhList.Count == 0)
            {
                return dt; // Return empty table if list is null or empty
            }

            // Build parameterized query with indexed parameters
            var parameters = new List<MySqlParameter>();
            string[] paramPlaceholders = new string[maThiSinhList.Count];
            for (int i = 0; i < maThiSinhList.Count; i++)
            {
                paramPlaceholders[i] = $"@TS{i}";
                parameters.Add(new MySqlParameter($"@TS{i}", maThiSinhList[i]));
            }

            string query = $"SELECT MaThiSinh, HoTen FROM ThiSinh WHERE MaThiSinh IN ({string.Join(",", paramPlaceholders)})";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }
    }
}