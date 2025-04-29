using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class ChiTietHoaDonDAO
    {
        public void ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaDanhGia, MaPhiGiaHan, SoLuong, DonGia, ThanhTien) VALUES (@MaHoaDon, @MaDanhGia, @MaPhiGiaHan, @SoLuong, @DonGia, @ThanhTien)";
            var parameters = new[]
            {
                new MySqlParameter("@MaHoaDon", chiTiet.MaHoaDon),
                new MySqlParameter("@MaDanhGia", chiTiet.MaDanhGia ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhiGiaHan", chiTiet.MaPhiGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@SoLuong", chiTiet.SoLuong),
                new MySqlParameter("@DonGia", chiTiet.DonGia),
                new MySqlParameter("@ThanhTien", chiTiet.ThanhTien)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public ChiTietHoaDon LayChiTietHoaDon(string maChiTietHoaDon)
        {
            string query = "SELECT * FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = new[] { new MySqlParameter("@MaChiTietHoaDon", maChiTietHoaDon) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ChiTietHoaDon
            {
                MaChiTietHoaDon = row["MaChiTietHoaDon"].ToString(),
                MaHoaDon = row["MaHoaDon"].ToString(),
                MaDanhGia = row["MaDanhGia"] != DBNull.Value ? row["MaDanhGia"].ToString() : null,
                MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null,
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                DonGia = Convert.ToDecimal(row["DonGia"]),
                ThanhTien = Convert.ToDecimal(row["ThanhTien"])
            };
        }

        public List<ChiTietHoaDon> LayDSChiTietHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            var chiTietList = new List<ChiTietHoaDon>();

            foreach (DataRow row in result.Rows)
            {
                chiTietList.Add(new ChiTietHoaDon
                {
                    MaChiTietHoaDon = row["MaChiTietHoaDon"].ToString(),
                    MaHoaDon = row["MaHoaDon"].ToString(),
                    MaDanhGia = row["MaDanhGia"] != DBNull.Value ? row["MaDanhGia"].ToString() : null,
                    MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null,
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    ThanhTien = Convert.ToDecimal(row["ThanhTien"])
                });
            }
            return chiTietList;
        }

        public void CapNhatChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "UPDATE ChiTietHoaDon SET MaHoaDon = @MaHoaDon, MaDanhGia = @MaDanhGia, MaPhiGiaHan = @MaPhiGiaHan, SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = new[]
            {
                new MySqlParameter("@MaChiTietHoaDon", chiTiet.MaChiTietHoaDon),
                new MySqlParameter("@MaHoaDon", chiTiet.MaHoaDon),
                new MySqlParameter("@MaDanhGia", chiTiet.MaDanhGia ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhiGiaHan", chiTiet.MaPhiGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@SoLuong", chiTiet.SoLuong),
                new MySqlParameter("@DonGia", chiTiet.DonGia),
                new MySqlParameter("@ThanhTien", chiTiet.ThanhTien)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaChiTietHoaDon(string maChiTietHoaDon)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
            var parameters = new[] { new MySqlParameter("@MaChiTietHoaDon", maChiTietHoaDon) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}