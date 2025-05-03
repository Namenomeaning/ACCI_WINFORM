using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAO nhanVienDAO = new NhanVienDAO();

        public bool ThemNhanVien(NhanVien nhanVien)
        {
            // Add validation logic here if needed
            return nhanVienDAO.ThemNhanVien(nhanVien) > 0;
        }

        public NhanVien LayNhanVien(string maNhanVien)
        {
            DataTable dt = nhanVienDAO.LayNhanVien(maNhanVien);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToNhanVien(dt.Rows[0]);
        }

        public List<NhanVien> LayDSNhanVien()
        {
            DataTable dt = nhanVienDAO.LayDSNhanVien();
            var nhanVienList = new List<NhanVien>();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    nhanVienList.Add(MapDataRowToNhanVien(row));
                }
            }
            return nhanVienList;
        }

        public bool CapNhatNhanVien(NhanVien nhanVien)
        {
            // Add validation logic here
            return nhanVienDAO.CapNhatNhanVien(nhanVien) > 0;
        }

        public bool XoaNhanVien(string maNhanVien)
        {
            // Add business logic (e.g., check if employee can be deleted)
            return nhanVienDAO.XoaNhanVien(maNhanVien) > 0;
        }

        private NhanVien MapDataRowToNhanVien(DataRow row)
        {
            return new NhanVien
            {
                MaNhanVien = row["MaNhanVien"].ToString(),
                HoTen = row["HoTen"].ToString(),
                VaiTro = row["VaiTro"].ToString(),
                TrangThai = row["TrangThai"].ToString()
            };
        }
    }
}