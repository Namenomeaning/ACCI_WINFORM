using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.DataAccess
{
    public class PhieuGiaHanDAO
    {
        public void ThemPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            string query = "INSERT INTO PhieuGiaHan (MaPhieuDK, ThuTu_CT, MaLichThi_Cu, MaLichThi_Moi, LyDo, NgayYC, MaNV_XuLy, TrangThai, MaPhiGiaHan) VALUES (@MaPhieuDK, @ThuTu_CT, @MaLichThi_Cu, @MaLichThi_Moi, @LyDo, @NgayYC, @MaNV_XuLy, @TrangThai, @MaPhiGiaHan)";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuDK", phieuGiaHan.MaPhieuDK),
                new MySqlParameter("@ThuTu_CT", phieuGiaHan.ThuTu_CT),
                new MySqlParameter("@MaLichThi_Cu", phieuGiaHan.MaLichThi_Cu),
                new MySqlParameter("@MaLichThi_Moi", phieuGiaHan.MaLichThi_Moi),
                new MySqlParameter("@LyDo", phieuGiaHan.LyDo),
                new MySqlParameter("@NgayYC", phieuGiaHan.NgayYC),
                new MySqlParameter("@MaNV_XuLy", phieuGiaHan.MaNV_XuLy),
                new MySqlParameter("@TrangThai", phieuGiaHan.TrangThai),
                new MySqlParameter("@MaPhiGiaHan", phieuGiaHan.MaPhiGiaHan ?? (object)DBNull.Value)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public PhieuGiaHan LayPhieuGiaHan(string maPhieuGiaHan)
        {
            string query = "SELECT * FROM PhieuGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhieuGiaHan", maPhieuGiaHan) };
            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            var row = result.Rows[0];
            return new PhieuGiaHan
            {
                MaPhieuGiaHan = row["MaPhieuGiaHan"].ToString(),
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu_CT = Convert.ToInt32(row["ThuTu_CT"]),
                MaLichThi_Cu = row["MaLichThi_Cu"].ToString(),
                MaLichThi_Moi = row["MaLichThi_Moi"].ToString(),
                LyDo = row["LyDo"].ToString(),
                NgayYC = Convert.ToDateTime(row["NgayYC"]),
                MaNV_XuLy = row["MaNV_XuLy"].ToString(),
                TrangThai = row["TrangThai"].ToString(),
                MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null
            };
        }

        public List<PhieuGiaHan> LayDSPhieuGiaHan()
        {
            string query = "SELECT * FROM PhieuGiaHan";
            DataTable result = DatabaseHelper.ExecuteQuery(query);
            var phieuGiaHanList = new List<PhieuGiaHan>();

            foreach (DataRow row in result.Rows)
            {
                phieuGiaHanList.Add(new PhieuGiaHan
                {
                    MaPhieuGiaHan = row["MaPhieuGiaHan"].ToString(),
                    MaPhieuDK = row["MaPhieuDK"].ToString(),
                    ThuTu_CT = Convert.ToInt32(row["ThuTu_CT"]),
                    MaLichThi_Cu = row["MaLichThi_Cu"].ToString(),
                    MaLichThi_Moi = row["MaLichThi_Moi"].ToString(),
                    LyDo = row["LyDo"].ToString(),
                    NgayYC = Convert.ToDateTime(row["NgayYC"]),
                    MaNV_XuLy = row["MaNV_XuLy"].ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null
                });
            }
            return phieuGiaHanList;
        }

        public void CapNhatPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            string query = "UPDATE PhieuGiaHan SET MaPhieuDK = @MaPhieuDK, ThuTu_CT = @ThuTu_CT, MaLichThi_Cu = @MaLichThi_Cu, MaLichThi_Moi = @MaLichThi_Moi, LyDo = @LyDo, NgayYC = @NgayYC, MaNV_XuLy = @MaNV_XuLy, TrangThai = @TrangThai, MaPhiGiaHan = @MaPhiGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = new[]
            {
                new MySqlParameter("@MaPhieuGiaHan", phieuGiaHan.MaPhieuGiaHan),
                new MySqlParameter("@MaPhieuDK", phieuGiaHan.MaPhieuDK),
                new MySqlParameter("@ThuTu_CT", phieuGiaHan.ThuTu_CT),
                new MySqlParameter("@MaLichThi_Cu", phieuGiaHan.MaLichThi_Cu),
                new MySqlParameter("@MaLichThi_Moi", phieuGiaHan.MaLichThi_Moi),
                new MySqlParameter("@LyDo", phieuGiaHan.LyDo),
                new MySqlParameter("@NgayYC", phieuGiaHan.NgayYC),
                new MySqlParameter("@MaNV_XuLy", phieuGiaHan.MaNV_XuLy),
                new MySqlParameter("@TrangThai", phieuGiaHan.TrangThai),
                new MySqlParameter("@MaPhiGiaHan", phieuGiaHan.MaPhiGiaHan ?? (object)DBNull.Value)
            };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }

        public void XoaPhieuGiaHan(string maPhieuGiaHan)
        {
            string query = "DELETE FROM PhieuGiaHan WHERE MaPhieuGiaHan = @MaPhieuGiaHan";
            var parameters = new[] { new MySqlParameter("@MaPhieuGiaHan", maPhieuGiaHan) };
            DatabaseHelper.ExecuteQuery(query, parameters);
        }
    }
}