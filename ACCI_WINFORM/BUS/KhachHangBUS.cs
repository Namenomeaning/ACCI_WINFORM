using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // Needed for Where in parameter mapping if done in BUS

namespace ACCI_WINFORM.BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        public bool ThemKhachHang(KhachHang khachHang)
        {
            // Validation: Check LoaiKhach, ensure HoTen or TenDonVi is provided based on LoaiKhach
            // Ensure Email format is valid, DienThoai format is valid
            if (!IsValidKhachHang(khachHang))
            {
                return false; // Or throw validation exception
            }
            return khachHangDAO.ThemKhachHang(khachHang) > 0;
        }

        public KhachHang LayKhachHang(string maKhachHang)
        {
            DataTable dt = khachHangDAO.LayKhachHang(maKhachHang);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToKhachHang(dt.Rows[0]);
        }

        public List<KhachHang> LayDSKhachHang()
        {
            DataTable dt = khachHangDAO.LayDSKhachHang();
            var khachHangList = new List<KhachHang>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    khachHangList.Add(MapDataRowToKhachHang(row));
                }
            }
            return khachHangList;
        }

        public bool CapNhatKhachHang(KhachHang khachHang)
        {
            if (string.IsNullOrWhiteSpace(khachHang.MaKhachHang) || !IsValidKhachHang(khachHang))
            {
                return false; // Or throw validation exception
            }
            return khachHangDAO.CapNhatKhachHang(khachHang) > 0;
        }

        public bool XoaKhachHang(string maKhachHang)
        {
            // Business logic: Check if customer has existing PhieuDK
            // PhieuDKBUS phieuDKBUS = new PhieuDKBUS(); // Dependency needed
            // var phieuDKs = phieuDKBUS.LayDSPhieuDK().Where(p => p.MaKhachHang == maKhachHang).ToList();
            // if (phieuDKs.Count > 0) { return false; /* Cannot delete */ }

            return khachHangDAO.XoaKhachHang(maKhachHang) > 0;
        }

        // --- Helper Methods ---
        private bool IsValidKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            if (string.IsNullOrWhiteSpace(khachHang.LoaiKhach) ||
                string.IsNullOrWhiteSpace(khachHang.DiaChi) ||
                string.IsNullOrWhiteSpace(khachHang.Email) || // Add email format validation
                string.IsNullOrWhiteSpace(khachHang.DienThoai)) // Add phone format validation
            {
                return false;
            }
            if (khachHang.LoaiKhach == "CaNhan" && string.IsNullOrWhiteSpace(khachHang.HoTen)) // Assuming "CaNhan" type
            {
                return false;
            }
            if (khachHang.LoaiKhach == "DonVi" && string.IsNullOrWhiteSpace(khachHang.TenDonVi)) // Assuming "DonVi" type
            {
                return false;
            }
            // Add more specific validations (email format, phone format)
            return true;
        }

        private KhachHang MapDataRowToKhachHang(DataRow row)
        {
            return new KhachHang
            {
                MaKhachHang = row["MaKhachHang"].ToString(),
                LoaiKhach = row["LoaiKhach"].ToString(),
                HoTen = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : null,
                TenDonVi = row["TenDonVi"] != DBNull.Value ? row["TenDonVi"].ToString() : null,
                DiaChi = row["DiaChi"].ToString(),
                Email = row["Email"].ToString(),
                DienThoai = row["DienThoai"].ToString()
            };
        }
    }
}