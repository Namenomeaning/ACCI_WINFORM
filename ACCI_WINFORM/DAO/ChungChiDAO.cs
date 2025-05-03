using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;

namespace ACCI_WINFORM.DAO
{
    public class ChungChiDAO
    {
        public int ThemChungChi(ChungChi chungChi)
        {
            string query = "INSERT INTO ChungChi (SoHieu, MaPhieuDK, ThuTu, MaThiSinh, NgayCap, NgayHetHan, PhuongThucNhan, DiaChiNhan, NgayNhan, TrangThaiNhan, MaNV_CapNhat) VALUES (@SoHieu, @MaPhieuDK, @ThuTu, @MaThiSinh, @NgayCap, @NgayHetHan, @PhuongThucNhan, @DiaChiNhan, @NgayNhan, @TrangThaiNhan, @MaNV_CapNhat)";
            var parameters = MapChungChiToParameters(chungChi);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayChungChi(string soHieu)
        {
            string query = "SELECT * FROM ChungChi WHERE SoHieu = @SoHieu";
            var parameters = new[] { new MySqlParameter("@SoHieu", soHieu) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayChungChi(string maPhieuDK, int thuTu) // Overload by MaPhieuDK and ThuTu
        {
            // Original query only selected a few columns, getting all for consistency
            string query = "SELECT * FROM ChungChi WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", maPhieuDK),
                new MySqlParameter("@ThuTu", thuTu)
            };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }


        public DataTable LayDSChungChi()
        {
            string query = "SELECT * FROM ChungChi";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatChungChi(ChungChi chungChi)
        {
            string query = "UPDATE ChungChi SET MaPhieuDK = @MaPhieuDK, ThuTu = @ThuTu, MaThiSinh = @MaThiSinh, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan, PhuongThucNhan = @PhuongThucNhan, DiaChiNhan = @DiaChiNhan, NgayNhan = @NgayNhan, TrangThaiNhan = @TrangThaiNhan, MaNV_CapNhat = @MaNV_CapNhat WHERE SoHieu = @SoHieu";
            var parameters = MapChungChiToParameters(chungChi);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaChungChi(string soHieu)
        {
            string query = "DELETE FROM ChungChi WHERE SoHieu = @SoHieu";
            var parameters = new[] { new MySqlParameter("@SoHieu", soHieu) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Keep the original logic as requested, including hardcoded values for now
        public int CapNhatTrangThaiNhan(string soHieu, string trangThaiNhan, DateTime? ngayNhan, string nv, string phuongThuc, string diaChi)
        {
            string query = @"UPDATE ChungChi
                            SET TrangThaiNhan = @TrangThaiNhan,
                                NgayNhan = @NgayNhan,
                                MaNV_CapNhat = @NV,
                                PhuongThucNhan = @PhuongThuc,
                                DiaChiNhan = @DiaChi
                            WHERE SoHieu = @SoHieu";
            var parameters = new[]
            {
                new MySqlParameter("@TrangThaiNhan", trangThaiNhan),
                new MySqlParameter("@NgayNhan", ngayNhan.HasValue ? (object)ngayNhan.Value : DBNull.Value),
                new MySqlParameter("@SoHieu", soHieu),
                new MySqlParameter("@NV", nv),
                new MySqlParameter("@PhuongThuc", phuongThuc), // Pass values from BUS
                new MySqlParameter("@DiaChi", string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi) // Handle null/empty DiaChi
            };
            // Use ExecuteNonQuery as it modifies data
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }


        // Helper to map object to parameters
        private MySqlParameter[] MapChungChiToParameters(ChungChi chungChi)
        {
            return new[]
           {
                new MySqlParameter("@SoHieu", chungChi.SoHieu),
                new MySqlParameter("@MaPhieuDK", chungChi.MaPhieuDK),
                new MySqlParameter("@ThuTu", chungChi.ThuTu),
                new MySqlParameter("@MaThiSinh", chungChi.MaThiSinh),
                new MySqlParameter("@NgayCap", chungChi.NgayCap),
                new MySqlParameter("@NgayHetHan", chungChi.NgayHetHan ?? (object)DBNull.Value),
                new MySqlParameter("@PhuongThucNhan", chungChi.PhuongThucNhan),
                new MySqlParameter("@DiaChiNhan", chungChi.DiaChiNhan ?? (object)DBNull.Value),
                new MySqlParameter("@NgayNhan", chungChi.NgayNhan ?? (object)DBNull.Value),
                new MySqlParameter("@TrangThaiNhan", chungChi.TrangThaiNhan),
                new MySqlParameter("@MaNV_CapNhat", chungChi.MaNV_CapNhat)
            };
        }
    }
}