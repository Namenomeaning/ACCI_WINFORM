using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Data;

namespace ACCI_WINFORM.Services
{
    public class LoginService
    {
        public NhanVien Authenticate(string tenDangNhap, string matKhau)
        {
            string query = @"
                SELECT t.MaThongTinDangNhap, t.TenDangNhap, t.MatKhauHash, t.MaNhanVien,
                       n.HoTen, n.VaiTro, n.TrangThai
                FROM ThongTinDangNhap t
                JOIN NhanVien n ON t.MaNhanVien = n.MaNhanVien
                WHERE t.TenDangNhap = @TenDangNhap AND t.MatKhauHash = @MatKhau AND n.TrangThai = 'DangLam'";

            var parameters = new[]
            {
                new MySqlParameter("@TenDangNhap", tenDangNhap),
                new MySqlParameter("@MatKhau", matKhau)
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                var row = result.Rows[0];
                return new NhanVien
                {
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    VaiTro = row["VaiTro"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
            }
            return null;
        }
    }
}