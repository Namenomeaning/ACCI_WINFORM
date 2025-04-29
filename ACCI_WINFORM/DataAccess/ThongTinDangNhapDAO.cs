using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class ThongTinDangNhapDAO
    {
        public void ThemThongTinDangNhap(ThongTinDangNhap thongTin)
        {
            string query = "INSERT INTO ThongTinDangNhap (TenDangNhap, MatKhauHash, MaNhanVien) VALUES (@TenDangNhap, @MatKhauHash, @MaNhanVien)";
            var parameters = new[]
            {
                new MySqlParameter("@TenDangNhap", thongTin.TenDangNhap),
                new MySqlParameter("@MatKhauHash", thongTin.MatKhauHash),
                new MySqlParameter("@MaNhanVien", thongTin.MaNhanVien)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public ThongTinDangNhap LayThongTinDangNhap(string maThongTinDangNhap)
        {
            string query = "SELECT * FROM ThongTinDangNhap WHERE MaThongTinDangNhap = @MaThongTinDangNhap";
            var parameters = new[] { new MySqlParameter("@MaThongTinDangNhap", maThongTinDangNhap) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ThongTinDangNhap
            {
                MaThongTinDangNhap = row["MaThongTinDangNhap"].ToString(),
                TenDangNhap = row["TenDangNhap"].ToString(),
                MatKhauHash = row["MatKhauHash"].ToString(),
                MaNhanVien = row["MaNhanVien"].ToString()
            };
        }

        public List<ThongTinDangNhap> LayDSThongTinDangNhap()
        {
            string query = "SELECT * FROM ThongTinDangNhap";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var thongTinList = new List<ThongTinDangNhap>();

            foreach (DataRow row in result.Rows)
            {
                thongTinList.Add(new ThongTinDangNhap
                {
                    MaThongTinDangNhap = row["MaThongTinDangNhap"].ToString(),
                    TenDangNhap = row["TenDangNhap"].ToString(),
                    MatKhauHash = row["MatKhauHash"].ToString(),
                    MaNhanVien = row["MaNhanVien"].ToString()
                });
            }
            return thongTinList;
        }

        public void CapNhatThongTinDangNhap(ThongTinDangNhap thongTin)
        {
            string query = "UPDATE ThongTinDangNhap SET TenDangNhap = @TenDangNhap, MatKhauHash = @MatKhauHash, MaNhanVien = @MaNhanVien WHERE MaThongTinDangNhap = @MaThongTinDangNhap";
            var parameters = new[]
            {
                new MySqlParameter("@MaThongTinDangNhap", thongTin.MaThongTinDangNhap),
                new MySqlParameter("@TenDangNhap", thongTin.TenDangNhap),
                new MySqlParameter("@MatKhauHash", thongTin.MatKhauHash),
                new MySqlParameter("@MaNhanVien", thongTin.MaNhanVien)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaThongTinDangNhap(string maThongTinDangNhap)
        {
            string query = "DELETE FROM ThongTinDangNhap WHERE MaThongTinDangNhap = @MaThongTinDangNhap";
            var parameters = new[] { new MySqlParameter("@MaThongTinDangNhap", maThongTinDangNhap) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}