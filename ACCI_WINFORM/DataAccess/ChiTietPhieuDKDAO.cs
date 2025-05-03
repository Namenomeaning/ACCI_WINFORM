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

        public DataTable LayDanhSachThiSinhTheoLichThi(string maLichThi, DataTable thiSinhData)
        {
            // Lấy dữ liệu từ ChiTietPhieuDK
            string queryCT = @"SELECT MaPhieuDK, ThuTu, MaThiSinh, SoBaoDanh, Diem 
                              FROM ChiTietPhieuDK 
                              WHERE MaLichThi = @MaLichThi";
            var parametersCT = new[] { new MySqlParameter("@MaLichThi", maLichThi) };
            DataTable dtCT = DatabaseHelper.ExecuteQuery(queryCT, parametersCT);

            // Tạo dictionary từ thiSinhData để tra cứu nhanh HoTen
            var thiSinhDict = thiSinhData.AsEnumerable().ToDictionary(row => row["MaThiSinh"].ToString(),row => row["HoTen"].ToString());

            // Tạo DataTable kết quả
            DataTable result = new DataTable();
            result.Columns.Add("MaPhieuDK", typeof(string));
            result.Columns.Add("ThuTu", typeof(int));
            result.Columns.Add("MaThiSinh", typeof(string));
            result.Columns.Add("HoTen", typeof(string));
            result.Columns.Add("SoBaoDanh", typeof(string));
            result.Columns.Add("Diem", typeof(decimal));

            // Kết hợp dữ liệu
            foreach (DataRow rowCT in dtCT.Rows)
            {
                string maThiSinh = rowCT["MaThiSinh"].ToString();
                if (thiSinhDict.TryGetValue(maThiSinh, out string hoTen))
                {
                    DataRow newRow = result.NewRow();
                    newRow["MaPhieuDK"] = rowCT["MaPhieuDK"];
                    newRow["ThuTu"] = rowCT["ThuTu"];
                    newRow["MaThiSinh"] = maThiSinh;
                    newRow["HoTen"] = hoTen;
                    newRow["SoBaoDanh"] = rowCT["SoBaoDanh"];
                    newRow["Diem"] = rowCT["Diem"];
                    result.Rows.Add(newRow);
                }
            }

            // Log để kiểm tra
            string columnNames = string.Join(", ", result.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            System.Diagnostics.Debug.WriteLine($"LayDanhSachThiSinhTheoLichThi columns: {columnNames}");

            return result;
        }

        public bool CapNhatDiemThi(string maPhieuDK, int thuTu, double diem, string maNhanVien)
        {
            string query = @"UPDATE ChiTietPhieuDK 
                            SET Diem = @Diem, 
                                MaNV_NhapLieu = @MaNV_NhapLieu, 
                                NgayCoKetQua = CURDATE(), 
                                KetQua = CASE WHEN @Diem >= 5 THEN 'Dat' ELSE 'KhongDat' END, 
                                TrangThaiCT = 'DaThi' 
                            WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@Diem", diem),
                new MySqlParameter("@MaNV_NhapLieu", maNhanVien),
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
        public DataTable LayChiTietTheoThiSinh(string maThiSinh, string soBaoDanh)
        {
            string query = "SELECT MaPhieuDK, ThuTu, MaThiSinh, MaLichThi, SoBaoDanh, Diem, KetQua " +
                           "FROM ChiTietPhieuDK WHERE MaThiSinh = @MaThiSinh";
            if (!string.IsNullOrEmpty(soBaoDanh))
            {
                query += " AND SoBaoDanh LIKE @SoBaoDanh";
            }
            var parameters = new[]
            {
            new MySqlParameter("@MaThiSinh", maThiSinh),
            new MySqlParameter("@SoBaoDanh", $"%{soBaoDanh}%")
        };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}