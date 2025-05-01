using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class ChiTietPhieuDKDAO
    {
        public void ThemChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            string query = "INSERT INTO ChiTietPhieuDK (MaPhieuDK, ThuTu, MaThiSinh, MaLichThi, SoBaoDanh, TrangThaiCT, Diem, KetQua, NgayCoKetQua, MaNV_NhapLieu) VALUES (@MaPhieuDK, @ThuTu, @MaThiSinh, @MaLichThi, @SoBaoDanh, @TrangThaiCT, @Diem, @KetQua, @NgayCoKetQua, @MaNV_NhapLieu)";
            var parameters = new[]
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
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public ChiTietPhieuDK LayChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ChiTietPhieuDK
            {
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu = Convert.ToInt32(row["ThuTu"]),
                MaThiSinh = row["MaThiSinh"] != DBNull.Value ? row["MaThiSinh"].ToString() : null,
                MaLichThi = row["MaLichThi"].ToString(),
                SoBaoDanh = row["SoBaoDanh"] != DBNull.Value ? row["SoBaoDanh"].ToString() : null,
                TrangThaiCT = row["TrangThaiCT"].ToString(),
                Diem = row["Diem"] != DBNull.Value ? Convert.ToDecimal(row["Diem"]) : (decimal?)null,
                KetQua = row["KetQua"] != DBNull.Value ? row["KetQua"].ToString() : null,
                NgayCoKetQua = row["NgayCoKetQua"] != DBNull.Value ? Convert.ToDateTime(row["NgayCoKetQua"]) : (DateTime?)null,
                MaNV_NhapLieu = row["MaNV_NhapLieu"] != DBNull.Value ? row["MaNV_NhapLieu"].ToString() : null
            };
        }

        public List<ChiTietPhieuDK> LayDSChiTietPhieuDK(string maPhieuDK)
        {
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);
            var chiTietList = new List<ChiTietPhieuDK>();

            foreach (DataRow row in result.Rows)
            {
                chiTietList.Add(new ChiTietPhieuDK
                {
                    MaPhieuDK = row["MaPhieuDK"].ToString(),
                    ThuTu = Convert.ToInt32(row["ThuTu"]),
                    MaThiSinh = row["MaThiSinh"] != DBNull.Value ? row["MaThiSinh"].ToString() : null,
                    MaLichThi = row["MaLichThi"].ToString(),
                    SoBaoDanh = row["SoBaoDanh"] != DBNull.Value ? row["SoBaoDanh"].ToString() : null,
                    TrangThaiCT = row["TrangThaiCT"].ToString(),
                    Diem = row["Diem"] != DBNull.Value ? Convert.ToDecimal(row["Diem"]) : (decimal?)null,
                    KetQua = row["KetQua"] != DBNull.Value ? row["KetQua"].ToString() : null,
                    NgayCoKetQua = row["NgayCoKetQua"] != DBNull.Value ? Convert.ToDateTime(row["NgayCoKetQua"]) : (DateTime?)null,
                    MaNV_NhapLieu = row["MaNV_NhapLieu"] != DBNull.Value ? row["MaNV_NhapLieu"].ToString() : null
                });
            }
            return chiTietList;
        }

        public ChiTietPhieuDK LayChiTietPhieuDKTheoMaThiSinh(string maThiSinh)
        {
            string query = "SELECT * FROM ChiTietPhieuDK WHERE MaThiSinh = @MaThiSinh AND TrangThaiCT = 'DK'";
            var parameters = new[] { new MySqlParameter("@MaThiSinh", maThiSinh) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ChiTietPhieuDK
            {
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu = Convert.ToInt32(row["ThuTu"]),
                MaThiSinh = row["MaThiSinh"] != DBNull.Value ? row["MaThiSinh"].ToString() : null,
                MaLichThi = row["MaLichThi"].ToString(),
                SoBaoDanh = row["SoBaoDanh"] != DBNull.Value ? row["SoBaoDanh"].ToString() : null,
                TrangThaiCT = row["TrangThaiCT"].ToString(),
                Diem = row["Diem"] != DBNull.Value ? Convert.ToDecimal(row["Diem"]) : (decimal?)null,
                KetQua = row["KetQua"] != DBNull.Value ? row["KetQua"].ToString() : null,
                NgayCoKetQua = row["NgayCoKetQua"] != DBNull.Value ? Convert.ToDateTime(row["NgayCoKetQua"]) : (DateTime?)null,
                MaNV_NhapLieu = row["MaNV_NhapLieu"] != DBNull.Value ? row["MaNV_NhapLieu"].ToString() : null
            };
        }

        public void CapNhatChiTietPhieuDK(ChiTietPhieuDK chiTiet)
        {
            string query = "UPDATE ChiTietPhieuDK SET MaThiSinh = @MaThiSinh, MaLichThi = @MaLichThi, SoBaoDanh = @SoBaoDanh, TrangThaiCT = @TrangThaiCT, Diem = @Diem, KetQua = @KetQua, NgayCoKetQua = @NgayCoKetQua, MaNV_NhapLieu = @MaNV_NhapLieu WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
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
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaChiTietPhieuDK(string maPhieuDK, int thuTu)
        {
            string query = "DELETE FROM ChiTietPhieuDK WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}