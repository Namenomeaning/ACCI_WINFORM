using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class NhanVienDAO
    {
        public int ThemNhanVien(NhanVien nhanVien)
        {
            string query = "INSERT INTO NhanVien (HoTen, VaiTro, TrangThai) VALUES (@HoTen, @VaiTro, @TrangThai)";
            var parameters = new[]
            {
                new MySqlParameter("@HoTen", nhanVien.HoTen),
                new MySqlParameter("@VaiTro", nhanVien.VaiTro),
                new MySqlParameter("@TrangThai", nhanVien.TrangThai)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayNhanVien(string maNhanVien)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[] { new MySqlParameter("@MaNhanVien", maNhanVien) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSNhanVien()
        {
            string query = "SELECT * FROM NhanVien";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatNhanVien(NhanVien nhanVien)
        {
            string query = "UPDATE NhanVien SET HoTen = @HoTen, VaiTro = @VaiTro, TrangThai = @TrangThai WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[]
            {
                new MySqlParameter("@MaNhanVien", nhanVien.MaNhanVien),
                new MySqlParameter("@HoTen", nhanVien.HoTen),
                new MySqlParameter("@VaiTro", nhanVien.VaiTro),
                new MySqlParameter("@TrangThai", nhanVien.TrangThai)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaNhanVien(string maNhanVien)
        {
            string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[] { new MySqlParameter("@MaNhanVien", maNhanVien) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}