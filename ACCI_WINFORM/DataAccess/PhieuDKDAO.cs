using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class PhieuDKDAO
    {
        public void ThemPhieuDK(PhieuDK phieuDK)
        {
            string query = "INSERT INTO PhieuDK (MaKhachHang, MaNV_TiepNhan, NgayTao, SoLanGiaHan, TrangThai) VALUES (@MaKhachHang, @MaNV_TiepNhan, @NgayTao, @SoLanGiaHan, @TrangThai)";
            var parameters = new[]
            {
                new MySqlParameter("@MaKhachHang", phieuDK.MaKhachHang),
                new MySqlParameter("@MaNV_TiepNhan", phieuDK.MaNV_TiepNhan),
                new MySqlParameter("@NgayTao", phieuDK.NgayTao),
                new MySqlParameter("@SoLanGiaHan", phieuDK.SoLanGiaHan),
                new MySqlParameter("@TrangThai", phieuDK.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public PhieuDK LayPhieuDK(string maPhieuDK)
        {
            string query = @"
                SELECT p.MaPhieuDK, p.MaKhachHang, p.MaNV_TiepNhan, p.NgayTao, p.SoLanGiaHan, p.TrangThai,
                       k.LoaiKhach, k.HoTen, k.TenDonVi, k.DiaChi, k.Email, k.DienThoai
                FROM PhieuDK p
                JOIN KhachHang k ON p.MaKhachHang = k.MaKhachHang
                WHERE p.MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new PhieuDK
            {
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                MaKhachHang = row["MaKhachHang"].ToString(),
                MaNV_TiepNhan = row["MaNV_TiepNhan"].ToString(),
                NgayTao = Convert.ToDateTime(row["NgayTao"]),
                SoLanGiaHan = Convert.ToInt32(row["SoLanGiaHan"]),
                TrangThai = row["TrangThai"].ToString(),
                KhachHang = new KhachHang
                {
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    LoaiKhach = row["LoaiKhach"].ToString(),
                    HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                    TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                }
            };
        }

        public List<PhieuDK> LayDSPhieuDK()
        {
            string query = @"
                SELECT p.MaPhieuDK, p.MaKhachHang, p.MaNV_TiepNhan, p.NgayTao, p.SoLanGiaHan, p.TrangThai,
                       k.LoaiKhach, k.HoTen, k.TenDonVi, k.DiaChi, k.Email, k.DienThoai
                FROM PhieuDK p
                JOIN KhachHang k ON p.MaKhachHang = k.MaKhachHang";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var phieuDKList = new List<PhieuDK>();

            foreach (DataRow row in result.Rows)
            {
                phieuDKList.Add(new PhieuDK
                {
                    MaPhieuDK = row["MaPhieuDK"].ToString(),
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    MaNV_TiepNhan = row["MaNV_TiepNhan"].ToString(),
                    NgayTao = Convert.ToDateTime(row["NgayTao"]),
                    SoLanGiaHan = Convert.ToInt32(row["SoLanGiaHan"]),
                    TrangThai = row["TrangThai"].ToString(),
                    KhachHang = new KhachHang
                    {
                        MaKhachHang = row["MaKhachHang"].ToString(),
                        LoaiKhach = row["LoaiKhach"].ToString(),
                        HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                        TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                        DiaChi = row["DiaChi"].ToString(),
                        Email = row["Email"].ToString(),
                        DienThoai = row["DienThoai"].ToString()
                    }
                });
            }
            return phieuDKList;
        }

        public void CapNhatPhieuDK(PhieuDK phieuDK)
        {
            string query = "UPDATE PhieuDK SET MaKhachHang = @MaKhachHang, MaNV_TiepNhan = @MaNV_TiepNhan, NgayTao = @NgayTao, SoLanGiaHan = @SoLanGiaHan, TrangThai = @TrangThai WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", phieuDK.MaPhieuDK),
                new MySqlParameter("@MaKhachHang", phieuDK.MaKhachHang),
                new MySqlParameter("@MaNV_TiepNhan", phieuDK.MaNV_TiepNhan),
                new MySqlParameter("@NgayTao", phieuDK.NgayTao),
                new MySqlParameter("@SoLanGiaHan", phieuDK.SoLanGiaHan),
                new MySqlParameter("@TrangThai", phieuDK.TrangThai)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaPhieuDK(string maPhieuDK)
        {
            string query = "DELETE FROM PhieuDK WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}