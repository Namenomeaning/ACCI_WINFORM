using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;

namespace ACCI_WINFORM.DAO
{
    public class PhieuGiaHanDAO
    {
        public int ThemPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            string query = "INSERT INTO PhieuGiaHan (MaPhieuDK, ThuTu_CT, MaLichThi_Cu, MaLichThi_Moi, LyDo, NgayYC, MaNV_XuLy, TrangThai, MaPhiGiaHan) VALUES (@MaPhieuDK, @ThuTu_CT, @MaLichThi_Cu, @MaLichThi_Moi, @LyDo, @NgayYC, @MaNV_XuLy, @TrangThai, @MaPhiGiaHan)";
            var parameters = MapPhieuGiaHanToParameters(phieuGiaHan);
            parameters = parameters.Where(p => p.ParameterName != "@MaPhieuGiaHan").ToArray(); // Remove ID for insert
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public DataTable LayPhieuGiaHan(string maPhieuGiaHan)
        {
            string query = "SELECT * FROM PhieuGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhieuGiaHan", maPhieuGiaHan) };
            return DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public DataTable LayDSPhieuGiaHan()
        {
            string query = "SELECT * FROM PhieuGiaHan";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public int CapNhatPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            string query = "UPDATE PhieuGiaHan SET MaPhieuDK = @MaPhieuDK, ThuTu_CT = @ThuTu_CT, MaLichThi_Cu = @MaLichThi_Cu, MaLichThi_Moi = @MaLichThi_Moi, LyDo = @LyDo, NgayYC = @NgayYC, MaNV_XuLy = @MaNV_XuLy, TrangThai = @TrangThai, MaPhiGiaHan = @MaPhiGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = MapPhieuGiaHanToParameters(phieuGiaHan);
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public int XoaPhieuGiaHan(string maPhieuGiaHan)
        {
            string query = "DELETE FROM PhieuGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhieuGiaHan", maPhieuGiaHan) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        // Helper to map object to parameters
        private MySqlParameter[] MapPhieuGiaHanToParameters(PhieuGiaHan phieuGiaHan)
        {
            return new[]
            {
                new MySqlParameter("@MaPhieuGiaHan", phieuGiaHan.MaPhieuGiaHan), // Needed for update/delete
                new MySqlParameter("@MaPhieuDK", phieuGiaHan.MaPhieuDK),
                new MySqlParameter("@ThuTu_CT", phieuGiaHan.ThuTu_CT),
                new MySqlParameter("@MaLichThi_Cu", phieuGiaHan.MaLichThi_Cu),
                new MySqlParameter("@MaLichThi_Moi", phieuGiaHan.MaLichThi_Moi),
                new MySqlParameter("@LyDo", phieuGiaHan.LyDo),
                new MySqlParameter("@NgayYC", phieuGiaHan.NgayYC),
                new MySqlParameter("@MaNV_XuLy", phieuGiaHan.MaNV_XuLy), // Should be nullable if not processed yet?
                new MySqlParameter("@TrangThai", phieuGiaHan.TrangThai),
                new MySqlParameter("@MaPhiGiaHan", phieuGiaHan.MaPhiGiaHan ?? (object)DBNull.Value)
            };
        }
    }
}