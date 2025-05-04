using ACCI_WINFORM.DAO; // Added DAO namespace
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

        public bool ThemThiSinh(ThiSinh thiSinh)
        {
            // Validation: HoTen not empty? NgaySinh valid? GioiTinh valid?
            if (string.IsNullOrWhiteSpace(thiSinh.HoTen) || (thiSinh.NgaySinh.HasValue && thiSinh.NgaySinh.Value > DateTime.Now))
            {
                return false; // Basic validation
            }
            return thiSinhDAO.ThemThiSinh(thiSinh) > 0;
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

        public DataTable LayThiSinhTheoMa(string maThiSinh)
        {
            return thiSinhDAO.LayThiSinhTheoMa(maThiSinh);
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