using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class NhanVienDAO
    {
        public void ThemNhanVien(NhanVien nhanVien)
        {
            string query = "INSERT INTO NhanVien (HoTen, VaiTro, TrangThai) VALUES (@HoTen, @VaiTro, @TrangThai)";
            var parameters = new[]
            {
                new MySqlParameter("@HoTen", nhanVien.HoTen),
                new MySqlParameter("@VaiTro", nhanVien.VaiTro),
                new MySqlParameter("@TrangThai", nhanVien.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public NhanVien LayNhanVien(string maNhanVien)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[] { new MySqlParameter("@MaNhanVien", maNhanVien) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new NhanVien
            {
                MaNhanVien = row["MaNhanVien"].ToString(),
                HoTen = row["HoTen"].ToString(),
                VaiTro = row["VaiTro"].ToString(),
                TrangThai = row["TrangThai"].ToString()
            };
        }

        public List<NhanVien> LayDSNhanVien()
        {
            string query = "SELECT * FROM NhanVien";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var nhanVienList = new List<NhanVien>();

            foreach (DataRow row in result.Rows)
            {
                nhanVienList.Add(new NhanVien
                {
                    MaNhanVien = row["MaNhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    VaiTro = row["VaiTro"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                });
            }
            return nhanVienList;
        }

        public void CapNhatNhanVien(NhanVien nhanVien)
        {
            string query = "UPDATE NhanVien SET HoTen = @HoTen, VaiTro = @VaiTro, TrangThai = @TrangThai WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[]
            {
                new MySqlParameter("@MaNhanVien", nhanVien.MaNhanVien),
                new MySqlParameter("@HoTen", nhanVien.HoTen),
                new MySqlParameter("@VaiTro", nhanVien.VaiTro),
                new MySqlParameter("@TrangThai", nhanVien.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaNhanVien(string maNhanVien)
        {
            string query = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
            var parameters = new[] { new MySqlParameter("@MaNhanVien", maNhanVien) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}