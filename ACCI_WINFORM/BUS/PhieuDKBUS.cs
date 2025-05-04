using ACCI_WINFORM.DAO; // Added DAO namespace
using MySqlConnector; // Add this
using ACCI_WINFORM.Models;
using ACCI_WINFORM.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class PhieuDKBUS
    {
        private PhieuDKDAO phieuDKDAO = new PhieuDKDAO();



        public bool ThemPhieuDK(PhieuDK phieuDK, out string maPhieuDK)
        {
            maPhieuDK = null;
            if (!IsValidPhieuDK(phieuDK))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(phieuDK.MaPhieuDK))
            {
                phieuDK.MaPhieuDK = GenerateMaPhieuDK();
            }

            string tempMaPhieuDK = null;
            bool success = DatabaseHelper.ExecuteTransaction((connection, transaction) =>
            {
                tempMaPhieuDK = phieuDKDAO.ThemPhieuDK(phieuDK, connection, transaction);
                return tempMaPhieuDK != null;
            }, out bool result);

            maPhieuDK = tempMaPhieuDK;
            return success && result;
        }
        private string GenerateMaPhieuDK()
            {
                string query = "SELECT COALESCE(MAX(CAST(SUBSTRING(MaPhieuDK, 4) AS UNSIGNED)), 0) AS MaxId FROM PhieuDK WHERE MaPhieuDK LIKE 'PDK%'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                int maxId = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["MaxId"]) : 0;
                return $"PDK{maxId + 1}";
            }

            private bool IsValidPhieuDK(PhieuDK phieuDK)
            {
                if (phieuDK == null ||
                    string.IsNullOrWhiteSpace(phieuDK.MaKhachHang) ||
                    string.IsNullOrWhiteSpace(phieuDK.MaNV_TiepNhan) ||
                    string.IsNullOrWhiteSpace(phieuDK.TrangThai))
                {
                    return false;
                }
                return true;
            }

            public PhieuDK LayPhieuDK(string maPhieuDK)
        {
            DataTable dt = phieuDKDAO.LayPhieuDK(maPhieuDK);

            if (dt == null || dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            return MapDataRowToPhieuDK(row);
        }

        public List<PhieuDK> LayDSPhieuDK()
        {
            DataTable dt = phieuDKDAO.LayDSPhieuDK();
            var phieuDKList = new List<PhieuDK>();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    phieuDKList.Add(MapDataRowToPhieuDK(row));
                }
            }
            return phieuDKList;
        }

        public bool CapNhatPhieuDK(PhieuDK phieuDK)
        {
            // Business logic/validation can be added here
            int result = phieuDKDAO.CapNhatPhieuDK(phieuDK);
            return result > 0; // Return true if update was successful
        }

        public bool XoaPhieuDK(string maPhieuDK)
        {
            // Business logic/validation (e.g., check dependencies) can be added here
            int result = phieuDKDAO.XoaPhieuDK(maPhieuDK);
            return result > 0; // Return true if deletion was successful
        }

        // Helper method to map DataRow to PhieuDK object
        private PhieuDK MapDataRowToPhieuDK(DataRow row)
        {
            return new PhieuDK
            {
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                MaKhachHang = row["MaKhachHang"].ToString(),
                MaNV_TiepNhan = row["MaNV_TiepNhan"].ToString(),
                NgayTao = Convert.ToDateTime(row["NgayTao"]),
                SoLanGiaHan = Convert.ToInt32(row["SoLanGiaHan"]),
                TrangThai = row["TrangThai"].ToString(),
                KhachHang = new KhachHang // Assuming KhachHang model exists and has these properties
                {
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    LoaiKhach = row["LoaiKhach"].ToString(),
                    HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                    TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                    DiaChi = row["DiaChi"].ToString(),
                    Email = row["Email"].ToString(),
                    DienThoai = row["DienThoai"].ToString()
                }
            };
        }
    }
}