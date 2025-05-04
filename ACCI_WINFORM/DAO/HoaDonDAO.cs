using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class HoaDonDAO
    {
        public int ThemHoaDon(HoaDon hoaDon)
        {
            try
            {
                // Bước 1: Thêm hóa đơn mới
                string insertQuery = "INSERT INTO HoaDon (MaPhieuDK, MaNV_KeToan, NgayLap, TongTienGoc, SoTienGiam, TongThu, TrangThaiTT) " +
                                  "VALUES (@MaPhieuDK, @MaNV_KeToan, @NgayLap, @TongTienGoc, @SoTienGiam, @TongThu, @TrangThaiTT)";

                var parameters = new[]
                {
                    new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK),
                    new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan),
                    new MySqlParameter("@NgayLap", hoaDon.NgayLap),
                    new MySqlParameter("@TongTienGoc", hoaDon.TongTienGoc),
                    new MySqlParameter("@SoTienGiam", hoaDon.SoTienGiam),
                    new MySqlParameter("@TongThu", hoaDon.TongThu),
                    new MySqlParameter("@TrangThaiTT", hoaDon.TrangThaiTT)
                };

                // Thực hiện thêm mới
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                if (rowsAffected > 0)
                {
                    // Bước 2: Lấy ID đầy đủ (HD1, HD2, ...) của hóa đơn vừa tạo
                    string selectQuery = "SELECT MaHoaDon FROM HoaDon WHERE MaPhieuDK = @MaPhieuDK AND MaNV_KeToan = @MaNV_KeToan ORDER BY NgayLap DESC LIMIT 1";
                    var selectParams = new[]
                    {
                        new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK),
                        new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan)
                    };

                    DataTable dt = DatabaseHelper.ExecuteQuery(selectQuery, selectParams);

                    if (dt.Rows.Count > 0)
                    {
                        // Cập nhật ID đúng định dạng cho đối tượng hoaDon
                        string actualInvoiceId = dt.Rows[0]["MaHoaDon"].ToString();
                        hoaDon.MaHoaDon = actualInvoiceId;

                        // Convert to numeric ID for legacy code compatibility
                        if (actualInvoiceId.StartsWith("HD") && int.TryParse(actualInvoiceId.Substring(2), out int numericId))
                        {
                            return numericId;
                        }

                        // If extraction fails, just return 1 to indicate success
                        return 1;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong ThemHoaDon (DAO): {ex.Message}");
                return 0;
            }
        }

        // Kiểm tra phiếu đăng ký đã có hóa đơn hay chưa
        public bool KiemTraPhieuDKDaCoHoaDon(string maPhieuDK)
        {
            string query = "SELECT COUNT(*) FROM HoaDon WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Lấy hóa đơn theo mã phiếu đăng ký
        public HoaDon LayHoaDonTheoPhieuDK(string maPhieuDK)
        {
            string query = "SELECT * FROM HoaDon WHERE MaPhieuDK = @MaPhieuDK";
            var parameters = new[] { new MySqlParameter("@MaPhieuDK", maPhieuDK) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new HoaDon
                {
                    MaHoaDon = row["MaHoaDon"].ToString(),
                    MaPhieuDK = row["MaPhieuDK"].ToString(),
                    MaPhieuGiaHan = row["MaPhieuGiaHan"] != DBNull.Value ? row["MaPhieuGiaHan"].ToString() : null,
                    MaUuDai = row["MaUuDai"] != DBNull.Value ? row["MaUuDai"].ToString() : null,
                    MaNV_KeToan = row["MaNV_KeToan"].ToString(),
                    NgayLap = Convert.ToDateTime(row["NgayLap"]),
                    PhuongThuc = row["PhuongThuc"] != DBNull.Value ? row["PhuongThuc"].ToString() : null,
                    MaGiaoDich = row["MaGiaoDich"] != DBNull.Value ? row["MaGiaoDich"].ToString() : null,
                    TongTienGoc = Convert.ToDecimal(row["TongTienGoc"]),
                    SoTienGiam = Convert.ToDecimal(row["SoTienGiam"]),
                    TongThu = Convert.ToDecimal(row["TongThu"]),
                    NgayThanhToan = row["NgayThanhToan"] != DBNull.Value ? Convert.ToDateTime(row["NgayThanhToan"]) : (DateTime?)null,
                    TrangThaiTT = row["TrangThaiTT"].ToString()
                };
            }

            return null;
        }

        public DataTable LayHoaDon(string maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSHoaDon()
        {
            string query = "SELECT * FROM HoaDon";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatHoaDon(HoaDon hoaDon)
        {
            string query = "UPDATE HoaDon SET MaPhieuDK = @MaPhieuDK, MaPhieuGiaHan = @MaPhieuGiaHan, MaUuDai = @MaUuDai, MaNV_KeToan = @MaNV_KeToan, NgayLap = @NgayLap, PhuongThuc = @PhuongThuc, MaGiaoDich = @MaGiaoDich, TongTienGoc = @TongTienGoc, SoTienGiam = @SoTienGiam, TongThu = @TongThu, NgayThanhToan = @NgayThanhToan, TrangThaiTT = @TrangThaiTT WHERE MaHoaDon = @MaHoaDon";
            var parameters = MapHoaDonToParameters(hoaDon);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaHoaDon(string maHoaDon)
        {
            // Important: Deleting an invoice might require deleting its details first,
            // or setting up cascading deletes in the database.
            // This DAO method only deletes the main invoice record.
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            var parameters = new[] { new MySqlParameter("@MaHoaDon", maHoaDon) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map object to parameters
        private MySqlParameter[] MapHoaDonToParameters(HoaDon hoaDon)
        {
            return new[]
           {
                new MySqlParameter("@MaHoaDon", hoaDon.MaHoaDon), // Needed for update/delete
                new MySqlParameter("@MaPhieuDK", hoaDon.MaPhieuDK ?? (object)DBNull.Value),
                new MySqlParameter("@MaPhieuGiaHan", hoaDon.MaPhieuGiaHan ?? (object)DBNull.Value),
                new MySqlParameter("@MaUuDai", hoaDon.MaUuDai ?? (object)DBNull.Value),
                new MySqlParameter("@MaNV_KeToan", hoaDon.MaNV_KeToan),
                new MySqlParameter("@NgayLap", hoaDon.NgayLap),
                new MySqlParameter("@PhuongThuc", hoaDon.PhuongThuc),
                new MySqlParameter("@MaGiaoDich", hoaDon.MaGiaoDich ?? (object)DBNull.Value),
                new MySqlParameter("@TongTienGoc", hoaDon.TongTienGoc),
                new MySqlParameter("@SoTienGiam", hoaDon.SoTienGiam),
                new MySqlParameter("@TongThu", hoaDon.TongThu), // Should be calculated
                new MySqlParameter("@NgayThanhToan", hoaDon.NgayThanhToan ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiTT", hoaDon.TrangThaiTT)
            };
        }
    }
}