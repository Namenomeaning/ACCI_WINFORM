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

        public ChungChi LayChungChi(string maChungChi)
        {
            string query = "SELECT * FROM ChungChi WHERE MaChungChi = @MaChungChi";
            var parameters = new[] { new MySqlParameter("@MaChungChi", maChungChi) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new ChungChi
            {
                MaChungChi = row["MaChungChi"].ToString(),
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
                    MaChungChi = row["MaChungChi"].ToString(),
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
            string query = "UPDATE ChungChi SET SoHieu = @SoHieu, MaPhieuDK = @MaPhieuDK, ThuTu = @ThuTu, MaThiSinh = @MaThiSinh, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan, PhuongThucNhan = @PhuongThucNhan, DiaChiNhan = @DiaChiNhan, NgayNhan = @NgayNhan, TrangThaiNhan = @TrangThaiNhan, MaNV_CapNhat = @MaNV_CapNhat WHERE MaChungChi = @MaChungChi";
            var parameters = new[]
            {
                new MySqlParameter("@MaChungChi", chungChi.MaChungChi),
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

        public void XoaChungChi(string maChungChi)
        {
            string query = "DELETE FROM ChungChi WHERE MaChungChi = @MaChungChi";
            var parameters = new[] { new MySqlParameter("@MaChungChi", maChungChi) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}