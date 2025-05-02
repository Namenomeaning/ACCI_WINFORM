using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class ChungChiDAO
    {
        public void ThemChungChi(ChungChi chungChi)
        {
            string query = "INSERT INTO ChungChi (SoHieu, MaPhieuDK, ThuTu, MaThiSinh, NgayCap, NgayHetHan, PhuongThucNhan, DiaChiNhan, NgayNhan, TrangThaiNhan, MaNV_CapNhat) VALUES (@SoHieu, @MaPhieuDK, @ThuTu, @MaThiSinh, @NgayCap, @NgayHetHan, @PhuongThucNhan, @DiaChiNhan, @NgayNhan, @TrangThaiNhan, @MaNV_CapNhat)";
            var parameters = new[]
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
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public ChungChi LayChungChi(string soHieu)
        {
            string query = "SELECT * FROM ChungChi WHERE SoHieu = @SoHieu";
            var parameters = new[] { new MySqlParameter("@SoHieu", soHieu) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ChungChi
            {
                SoHieu = row["SoHieu"].ToString(),
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu = Convert.ToInt32(row["ThuTu"]),
                MaThiSinh = row["MaThiSinh"].ToString(),
                NgayCap = Convert.ToDateTime(row["NgayCap"]),
                NgayHetHan = row["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(row["NgayHetHan"]) : (DateTime?)null,
                PhuongThucNhan = row["PhuongThucNhan"].ToString(),
                DiaChiNhan = row["DiaChiNhan"] != DBNull.Value ? row["DiaChiNhan"].ToString() : null,
                NgayNhan = row["NgayNhan"] != DBNull.Value ? Convert.ToDateTime(row["NgayNhan"]) : (DateTime?)null,
                TrangThaiNhan = row["TrangThaiNhan"].ToString(),
                MaNV_CapNhat = row["MaNV_CapNhat"].ToString()
            };
        }

        public List<ChungChi> LayDSChungChi()
        {
            string query = "SELECT * FROM ChungChi";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var chungChiList = new List<ChungChi>();

            foreach (DataRow row in result.Rows)
            {
                chungChiList.Add(new ChungChi
                {
                    SoHieu = row["SoHieu"].ToString(),
                    MaPhieuDK = row["MaPhieuDK"].ToString(),
                    ThuTu = Convert.ToInt32(row["ThuTu"]),
                    MaThiSinh = row["MaThiSinh"].ToString(),
                    NgayCap = Convert.ToDateTime(row["NgayCap"]),
                    NgayHetHan = row["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(row["NgayHetHan"]) : (DateTime?)null,
                    PhuongThucNhan = row["PhuongThucNhan"].ToString(),
                    DiaChiNhan = row["DiaChiNhan"] != DBNull.Value ? row["DiaChiNhan"].ToString() : null,
                    NgayNhan = row["NgayNhan"] != DBNull.Value ? Convert.ToDateTime(row["NgayNhan"]) : (DateTime?)null,
                    TrangThaiNhan = row["TrangThaiNhan"].ToString(),
                    MaNV_CapNhat = row["MaNV_CapNhat"].ToString()
                });
            }
            return chungChiList;
        }

        public void CapNhatChungChi(ChungChi chungChi)
        {
            string query = "UPDATE ChungChi SET MaPhieuDK = @MaPhieuDK, ThuTu = @ThuTu, MaThiSinh = @MaThiSinh, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan, PhuongThucNhan = @PhuongThucNhan, DiaChiNhan = @DiaChiNhan, NgayNhan = @NgayNhan, TrangThaiNhan = @TrangThaiNhan, MaNV_CapNhat = @MaNV_CapNhat WHERE SoHieu = @SoHieu";
            var parameters = new[]
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
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaChungChi(string soHieu)
        {
            string query = "DELETE FROM ChungChi WHERE SoHieu = @SoHieu";
            var parameters = new[] { new MySqlParameter("@SoHieu", soHieu) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public bool CapNhatTrangThaiNhan(string soHieu, string trangThaiNhan, string nv)
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
                new MySqlParameter("@NgayNhan", trangThaiNhan == "DaNhan" ? DateTime.Now : (object)DBNull.Value),
                new MySqlParameter("@SoHieu", soHieu),
                new MySqlParameter("@NV", nv),
                new MySqlParameter("@PhuongThuc", "TaiTT"),
                new MySqlParameter("@DiaChi", "123 Lê Lợi")
            };
            try
            {
                DatabaseHelper.ExecuteQuery(query, parameters);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in CapNhatTrangThaiNhan: {ex.Message}");
                return false;
            }
        }
        public DataRow LayChungChi(string maPhieuDK, int thuTu)
        {
            string query = "SELECT SoHieu, NgayCap, NgayNhan, TrangThaiNhan " +
                           "FROM ChungChi WHERE MaPhieuDK = @MaPhieuDK AND ThuTu = @ThuTu";
            var parameters = new[]
            {
            new MySqlParameter("@MaPhieuDK", maPhieuDK),
            new MySqlParameter("@ThuTu", thuTu)
        };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}