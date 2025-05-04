using ACCI_WINFORM.DAO; // Added DAO namespace
using MySqlConnector; // Add this
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class LichThiBUS
    {
        private LichThiDAO lichThiDAO = new LichThiDAO();

        public bool ThemLichThi(LichThi lichThi, out string maLichThi)
        {
            maLichThi = null;
            if (!IsValidLichThi(lichThi))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(lichThi.MaLichThi))
            {
                lichThi.MaLichThi = GenerateMaLichThi();
            }

            string tempMaLichThi = null;
            bool success = DatabaseHelper.ExecuteTransaction((connection, transaction) =>
            {
                tempMaLichThi = lichThiDAO.ThemLichThi(lichThi, connection, transaction);
                return tempMaLichThi != null;
            }, out bool result);

            maLichThi = tempMaLichThi;
            return success && result;
        }

        private string GenerateMaLichThi()
            {
                string query = "SELECT COALESCE(MAX(CAST(SUBSTRING(MaLichThi, 3) AS UNSIGNED)), 0) AS MaxId FROM LichThi WHERE MaLichThi LIKE 'LT%'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                int maxId = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["MaxId"]) : 0;
                return $"LT{maxId + 1}";
            }

            private bool IsValidLichThi(LichThi lichThi)
            {
                if (lichThi == null ||
                    string.IsNullOrWhiteSpace(lichThi.MaDanhGia) ||
                    string.IsNullOrWhiteSpace(lichThi.MaPhongThi) ||
                    lichThi.SoLuongMax <= 0)
                {
                    return false;
                }
                return true;
            }

            public LichThi LayLichThi(string maLichThi)
        {
            DataTable dt = lichThiDAO.LayLichThi(maLichThi);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToLichThi(dt.Rows[0]);
        }

        public List<LichThi> LayDSLichThi()
        {
            DataTable dt = lichThiDAO.LayDSLichThi();
            return MapDataTableToLichThiList(dt);
        }

        public List<LichThi> LayDSLichThiMoDangKyTheoDanhGia(string maDanhGia)
        {
            DataTable dt = lichThiDAO.LayDSLichThiTheoDanhGia(maDanhGia);
            return MapDataTableToLichThiList(dt);
        }


        public bool CapNhatLichThi(LichThi lichThi)
        {
            // Add validation logic
            return lichThiDAO.CapNhatLichThi(lichThi) > 0;
        }

        public bool XoaLichThi(string maLichThi)
        {
            // Add business logic: Cannot delete if SoLuongDK > 0?
            return lichThiDAO.XoaLichThi(maLichThi) > 0;
        }

        public bool TangSoLuongDK(string maLichThi)
        {
            // Optional: Check if SoLuongDK < SoLuongMax before incrementing
            LichThi existing = LayLichThi(maLichThi);
            if (existing != null && existing.SoLuongDK < existing.SoLuongMax)
            {
                return lichThiDAO.TangSoLuongDK(maLichThi) > 0;
            }
            // Handle case where slot is full or lichThi doesn't exist
            return false; // Indicate failure or throw exception
        }

        public bool GiamSoLuongDK(string maLichThi)
        {
            LichThi existing = LayLichThi(maLichThi);
            if (existing != null && existing.SoLuongDK > 0)
            {
                return lichThiDAO.GiamSoLuongDK(maLichThi) > 0; // Giả sử DAO có phương thức này
            }
            return false;
        }
        public DateTime? LayNgayThi(string maLichThi)
        {
            DataTable dt = lichThiDAO.LayNgayThi(maLichThi);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["NgayThi"] != DBNull.Value)
            {
                return Convert.ToDateTime(dt.Rows[0]["NgayThi"]);
            }
            return null;
        }

        // Helper mapping methods
        private LichThi MapDataRowToLichThi(DataRow row)
        {
            return new LichThi
            {
                MaLichThi = row["MaLichThi"].ToString(),
                MaDanhGia = row["MaDanhGia"].ToString(),
                MaPhongThi = row["MaPhongThi"].ToString(),
                NgayThi = Convert.ToDateTime(row["NgayThi"]),
                GioThi = TimeSpan.Parse(row["GioThi"].ToString()),
                SoLuongMax = Convert.ToInt32(row["SoLuongMax"]),
                SoLuongDK = Convert.ToInt32(row["SoLuongDK"]),
                TrangThai = row["TrangThai"].ToString()
            };
        }
        public List<LichThi> LayDSLichThiTheoDanhGia(string maDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maDanhGia))
            {
                return new List<LichThi>(); // Return empty list instead of null for consistency
            }
            DataTable dt = lichThiDAO.LayDSLichThiTheoDanhGia(maDanhGia);
            return MapDataTableToLichThiList(dt);
        }
        private List<LichThi> MapDataTableToLichThiList(DataTable dt)
        {
            var list = new List<LichThi>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(MapDataRowToLichThi(row));
                }
            }
            return list;
        }
    }
}