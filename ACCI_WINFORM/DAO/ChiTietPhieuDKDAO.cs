using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class ChiTietPhieuDKDAO
    {
        public int ThemChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            string query = "INSERT INTO ChiTietPhieuDK (MaPhieuDK, ThuTu, MaThiSinh, MaLichThi, SoBaoDanh, TrangThaiCT, Diem, KetQua, NgayCoKetQua, MaNV_NhapLieu) VALUES (@MaPhieuDK, @ThuTu, @MaThiSinh, @MaLichThi, @SoBaoDanh, @TrangThaiCT, @Diem, @KetQua, @NgayCoKetQua, @MaNV_NhapLieu)";
            var parameters = MapChiTietToParameters(chiTiet);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSChiTietPhieuDK(string maPhieuDK)
        {
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayChiTietPhieuDKTheoMaThiSinh(string maThiSinh)
        {
            // Consider if you need more criteria, e.g., only active registrations
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaThiSinh = @MaThiSinh AND TrangThaiCT = 'DK'"; // DK might mean 'Registered'?
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public int CapNhatChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            string query = "UPDATE ChiTietPhieuDK SET MaThiSinh = @MaThiSinh, MaLichThi = @MaLichThi, SoBaoDanh = @SoBaoDanh, TrangThaiCT = @TrangThaiCT, Diem = @Diem, KetQua = @KetQua, NgayCoKetQua = @NgayCoKetQua, MaNV_NhapLieu = @MaNV_NhapLieu WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = MapChiTietToParameters(chiTiet); // Re-use mapping helper
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            string query = "DELETE FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayDanhSachThiSinhTheoLichThi(string maLichThi)
        {
            // This method only needs data from ChiTietPhieuDK based on the original query
            string queryCT = @"SELECT MaPhieuDK, ThuTu, MaThiSinh, SoBaoDanh, Diem
                              FROM ChiTietPhieuDK
                              WHERE MaLichThi = @MaLichThi";
            var parametersCT = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            return DatabaseHelper.ExecuteQuery(queryCT, parametersCT);
        }

        public int CapNhatDiemThi(string maPhieuDK, int thuTu, double diem, string maNhanVien, string ketQua, string trangThai)
        {
            string query = @"UPDATE ChiTietPhieuDK
                            SET Diem = @Diem,
                                MaNV_NhapLieu = @MaNV_NhapLieu,
                                NgayCoKetQua = CURDATE(),
                                KetQua = @KetQua,
                                TrangThaiCT = @TrangThai
                            WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@Diem", diem),
                new MySqlParameter("@MaNV_NhapLieu", maNhanVien),
                new MySqlParameter("@KetQua", ketQua),
                new MySqlParameter("@TrangThai", trangThai),
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayChiTietTheoThiSinhVaSoBaoDanh(string maThiSinh, string soBaoDanh)
        {
            // Renamed parameter for clarity
            string query = "SELECT MaPhieuDK, ThuTu, MaThiSinh, MaLichThi, SoBaoDanh, Diem, KetQua " +
                           "FROM ChiTietPhieuDK WHERE MaThiSinh = @MaThiSinh";
            var parameters = new List<MySqlParameter> { new MySqlParameter("@MaThiSinh", maThiSinh) };

            if (!string.IsNullOrEmpty(soBaoDanh))
            {
                query += " AND SoBaoDanh LIKE @SoBaoDanhPattern";
                parameters.Add(new MySqlParameter("@SoBaoDanhPattern", $"%{soBaoDanh}%"));
            }

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        // Helper to create parameters from ChiTietPhieuDK object
        private MySqlParameter[] MapChiTietToParameters(ChiTietPhieuDK chiTiet)
        {
            return new[]
           {
                new MySqlParameter("@MaPhieuDK", chiTiet.MaPhieuDK),
                new MySqlParameter("@ThuTu", chiTiet.ThuTu),
                new MySqlParameter("@MaThiSinh", chiTiet.MaThiSinh ?? (object)DBNull.Value),
                new MySqlParameter("@MaLichThi", chiTiet.MaLichThi),
                new MySqlParameter("@SoBaoDanh", chiTiet.SoBaoDanh ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiCT", chiTiet.TrangThaiCT),
                new MySqlParameter("@Diem", chiTiet.Diem ?? (object)DBNull.Value),
                new MySqlParameter("@KetQua", chiTiet.KetQua ?? (object)DBNull.Value),
                new MySqlParameter("@NgayCoKetQua", chiTiet.NgayCoKetQua ?? (object)DBNull.Value),
                new MySqlParameter("@MaNV_NhapLieu", chiTiet.MaNV_NhapLieu ?? (object)DBNull.Value)
            };
        }
    }
}