using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class KhachHangDAO
    {
        public void ThemKhachHang(KhachHang khachHang)
        {
            string query = "INSERT INTO KhachHang (LoaiKhach, HoTen, TenDonVi, DiaChi, Email, DienThoai) VALUES (@LoaiKhach, @HoTen, @TenDonVi, @DiaChi, @Email, @DienThoai)";
            var parameters = new[]
            {
                new MySqlParameter("@LoaiKhach", khachHang.LoaiKhach),
                new MySqlParameter("@HoTen", khachHang.HoTen ?? (object)DBNull.Value),
                new MySqlParameter("@TenDonVi", khachHang.TenDonVi ?? (object)DBNull.Value),
                new MySqlParameter("@DiaChi", khachHang.DiaChi),
                new MySqlParameter("@Email", khachHang.Email),
                new MySqlParameter("@DienThoai", khachHang.DienThoai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public KhachHang LayKhachHang(string maKhachHang)
        {
            string query = "SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            var parameters = new[] { new MySqlParameter("@MaKhachHang", maKhachHang) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new KhachHang
            {
                MaKhachHang = row["MaKhachHang"].ToString(),
                LoaiKhach = row["LoaiKhach"].ToString(),
                HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                DiaChi = row["DiaChi"].ToString(),
                Email = row["Email"].ToString(),
                DienThoai = row["DienThoai"].ToString()
            };
        }

        public List<KhachHang> LayDSKhachHang()
        {
            string query = "SELECT * FROM KhachHang";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var khachHangList = new List<KhachHang>();

            foreach (DataRow row in result.Rows)
            {
                khachHangList.Add(new KhachHang
                {
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    LoaiKhach = row["LoaiKhach"].ToString(),
                    HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                    TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                });
            }
            return khachHangList;
        }

        public void CapNhatKhachHang(KhachHang khachHang)
        {
            string query = "UPDATE KhachHang SET LoaiKhach = @LoaiKhach, HoTen = @HoTen, TenDonVi = @TenDonVi, DiaChi = @DiaChi, Email = @Email, DienThoai = @DienThoai WHERE MaKhachHang = @MaKhachHang";
            var parameters = new[]
            {
                new MySqlParameter("@MaKhachHang", khachHang.MaKhachHang),
                new MySqlParameter("@LoaiKhach", khachHang.LoaiKhach),
                new MySqlParameter("@HoTen", khachHang.HoTen ?? (object)DBNull.Value),
                new MySqlParameter("@TenDonVi", khachHang.TenDonVi ?? (object)DBNull.Value),
                new MySqlParameter("@DiaChi", khachHang.DiaChi),
                new MySqlParameter("@Email", khachHang.Email),
                new MySqlParameter("@DienThoai", khachHang.DienThoai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaKhachHang(string maKhachHang)
        {
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
            var parameters = new[] { new MySqlParameter("@MaKhachHang", maKhachHang) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}