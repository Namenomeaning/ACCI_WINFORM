using ACCI_WINFORM.DAO; // Added DAO namespace
using MySqlConnector; // Add this
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class ThiSinhBUS
    {
        private ThiSinhDAO thiSinhDAO = new ThiSinhDAO();

        public bool ThemThiSinh(ThiSinh thiSinh, out string maThiSinh)
        {
            maThiSinh = null;
            if (!IsValidThiSinh(thiSinh))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(thiSinh.MaThiSinh))
            {
                thiSinh.MaThiSinh = GenerateMaThiSinh();
            }

            string tempMaThiSinh = null;
            bool success = DatabaseHelper.ExecuteTransaction((connection, transaction) =>
            {
                tempMaThiSinh = thiSinhDAO.ThemThiSinh(thiSinh, connection, transaction);
                return tempMaThiSinh != null; // Return true if insertion succeeded
            }, out bool result);

            maThiSinh = tempMaThiSinh; // Assign to out parameter after lambda
            return success && result;
        }
        private string GenerateMaThiSinh()
        {
            string query = "SELECT COALESCE(MAX(CAST(SUBSTRING(MaThiSinh, 3) AS UNSIGNED)), 0) AS MaxId FROM ThiSinh WHERE MaThiSinh LIKE 'TS%'";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            int maxId = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["MaxId"]) : 0;
            return $"TS{maxId + 1}";
        }

        private bool IsValidThiSinh(ThiSinh thiSinh)
        {
            if (thiSinh == null || string.IsNullOrWhiteSpace(thiSinh.HoTen))
            {
                return false;
            }
            // Add more validation if needed (e.g., NgaySinh format)
            return true;
        }

        public ThiSinh LayThiSinh(string maThiSinh)
        {
            DataTable dt = thiSinhDAO.LayThiSinh(maThiSinh);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToThiSinh(dt.Rows[0]);
        }

        public List<ThiSinh> LayDSThiSinh()
        {
            DataTable dt = thiSinhDAO.LayDSThiSinh();
            var thiSinhList = new List<ThiSinh>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    thiSinhList.Add(MapDataRowToThiSinh(row));
                }
            }
            return thiSinhList;
        }

        public bool CapNhatThiSinh(ThiSinh thiSinh)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(thiSinh.MaThiSinh) || string.IsNullOrWhiteSpace(thiSinh.HoTen) || (thiSinh.NgaySinh.HasValue && thiSinh.NgaySinh.Value > DateTime.Now))
            {
                return false;
            }
            return thiSinhDAO.CapNhatThiSinh(thiSinh) > 0;
        }

        public bool XoaThiSinh(string maThiSinh)
        {
            // Business logic: Check if ThiSinh has related ChiTietPhieuDK records
            // ChiTietPhieuDKBUS chiTietBus = new ChiTietPhieuDKBUS(); // Dependency
            // if (chiTietBus.LayChiTietTheoThiSinhVaSoBaoDanh(maThiSinh, null).Rows.Count > 0) {
            //    return false; // Cannot delete
            // }
            return thiSinhDAO.XoaThiSinh(maThiSinh) > 0;
        }

        public DataTable LayThiSinhTheoTieuChi(string maThiSinh, string hoTen)
        {
            // Can add more complex search logic/combination here if needed
            return thiSinhDAO.LayThiSinhTheoTieuChi(maThiSinh, hoTen);
        }

        public DataTable LayDanhSachThiSinhTheoMa(List<string> maThiSinhList)
        {
            // Directly pass to DAO after basic checks
            if (maThiSinhList == null || maThiSinhList.Count == 0)
            {
                // Return empty structure if needed by calling code
                DataTable emptyDt = new DataTable();
                emptyDt.Columns.Add("MaThiSinh", typeof(string));
                emptyDt.Columns.Add("HoTen", typeof(string));
                return emptyDt;
            }
            return thiSinhDAO.LayDanhSachThiSinhTheoMa(maThiSinhList);
        }

        // --- Helper Method ---
        private ThiSinh MapDataRowToThiSinh(DataRow row)
        {
            return new ThiSinh
            {
                MaThiSinh = row["MaThiSinh"].ToString(),
                HoTen = row["HoTen"].ToString(),
                NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : (DateTime?)null,
                GioiTinh = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : null
            };
        }
    }
}