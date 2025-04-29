using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class LichThiDAO
    {
        public void ThemLichThi(LichThi lichThi)
        {
            string query = "INSERT INTO LichThi (MaDanhGia, MaPhongThi, NgayThi, GioThi, SoLuongMax, SoLuongDK, TrangThai) VALUES (@MaDanhGia, @MaPhongThi, @NgayThi, @GioThi, @SoLuongMax, @SoLuongDK, @TrangThai)";
            var parameters = new[]
            {
                new MySqlParameter("@MaDanhGia", lichThi.MaDanhGia),
                new MySqlParameter("@MaPhongThi", lichThi.MaPhongThi),
                new MySqlParameter("@NgayThi", lichThi.NgayThi),
                new MySqlParameter("@GioThi", lichThi.GioThi),
                new MySqlParameter("@SoLuongMax", lichThi.SoLuongMax),
                new MySqlParameter("@SoLuongDK", lichThi.SoLuongDK),
                new MySqlParameter("@TrangThai", lichThi.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public LichThi LayLichThi(string maLichThi)
        {
            string query = "SELECT * FROM LichThi WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new LichThi
            {
                MaLichThi = row["MaLichThi"].ToString(),
                MaDanhGia = row["MaDanhGia"].ToString(),
                MaPhongThi = row["MaPhongThi"].ToString(),
                NgayThi = Convert.ToDateTime(row["NgayThi"]),
                GioThi = TimeSpan.Parse(row["GioThi"].ToString()),
                SoLuongMax = Convert.ToInt32(row["SoLuongMax"]),
                SoLuongDK = Convert.ToInt32(row["SoLuongDK"]),
                TrangThai = row["TrangThai"].ToString()
            };
        }

        public List<LichThi> LayDSLichThi()
        {
            string query = "SELECT * FROM LichThi";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var lichThiList = new List<LichThi>();

            foreach (DataRow row in result.Rows)
            {
                lichThiList.Add(new LichThi
                {
                    MaLichThi = row["MaLichThi"].ToString(),
                    MaDanhGia = row["MaDanhGia"].ToString(),
                    MaPhongThi = row["MaPhongThi"].ToString(),
                    NgayThi = Convert.ToDateTime(row["NgayThi"]),
                    GioThi = TimeSpan.Parse(row["GioThi"].ToString()),
                    SoLuongMax = Convert.ToInt32(row["SoLuongMax"]),
                    SoLuongDK = Convert.ToInt32(row["SoLuongDK"]),
                    TrangThai = row["TrangThai"].ToString()
                });
            }
            return lichThiList;
        }

        public void CapNhatLichThi(LichThi lichThi)
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
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaLichThi(string maLichThi)
        {
            string query = "DELETE FROM LichThi WHERE MaLichThi = @MaLichThi";
            var parameters = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}