using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class PhieuGiaHanBUS
    {
        private PhieuGiaHanDAO phieuGiaHanDAO = new PhieuGiaHanDAO();

        public bool ThemPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            // Set defaults before saving?
            phieuGiaHan.NgayYC = DateTime.Now;
            phieuGiaHan.TrangThai = "ChoXuLy"; // Example initial state
                                               // MaNV_XuLy should probably be null initially
            phieuGiaHan.MaNV_XuLy = null;

            // Validation: MaPhieuDK/ThuTu_CT exists? MaLichThi_Cu/Moi exists?
            return phieuGiaHanDAO.ThemPhieuGiaHan(phieuGiaHan) > 0;
        }

        public PhieuGiaHan LayPhieuGiaHan(string maPhieuGiaHan)
        {
            DataTable dt = phieuGiaHanDAO.LayPhieuGiaHan(maPhieuGiaHan);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToPhieuGiaHan(dt.Rows[0]);
        }

        public List<PhieuGiaHan> LayDSPhieuGiaHan()
        {
            DataTable dt = phieuGiaHanDAO.LayDSPhieuGiaHan();
            var phieuGiaHanList = new List<PhieuGiaHan>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    phieuGiaHanList.Add(MapDataRowToPhieuGiaHan(row));
                }
            }
            return phieuGiaHanList;
        }

        public bool CapNhatPhieuGiaHan(PhieuGiaHan phieuGiaHan)
        {
            // Business Logic: If TrangThai changes to "DaXuLy", update related tables?
            // (e.g., Update MaLichThi in ChiTietPhieuDK, decrement/increment SoLuongDK in LichThi)
            // This logic should reside here, calling other BUS/DAO classes as needed.
            // Example:
            // if (phieuGiaHan.TrangThai == "DaXuLy") {
            //     // Update ChiTietPhieuDK...
            //     // Update LichThi counts...
            // }
            return phieuGiaHanDAO.CapNhatPhieuGiaHan(phieuGiaHan) > 0;
        }

        public bool XoaPhieuGiaHan(string maPhieuGiaHan)
        {
            // Can only delete if not processed?
            var phieu = LayPhieuGiaHan(maPhieuGiaHan);
            if (phieu != null && phieu.TrangThai != "ChoXuLy") // Example state check
            {
                return false; // Cannot delete processed request
            }
            return phieuGiaHanDAO.XoaPhieuGiaHan(maPhieuGiaHan) > 0;
        }

        // Helper method to map DataRow to PhieuGiaHan object
        private PhieuGiaHan MapDataRowToPhieuGiaHan(DataRow row)
        {
            return new PhieuGiaHan
            {
                MaPhieuGiaHan = row["MaPhieuGiaHan"].ToString(),
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu_CT = Convert.ToInt32(row["ThuTu_CT"]),
                MaLichThi_Cu = row["MaLichThi_Cu"].ToString(),
                MaLichThi_Moi = row["MaLichThi_Moi"].ToString(),
                LyDo = row["LyDo"].ToString(),
                NgayYC = Convert.ToDateTime(row["NgayYC"]),
                // Handle potential DBNull for MaNV_XuLy if it's allowed
                MaNV_XuLy = row["MaNV_XuLy"] != DBNull.Value ? row["MaNV_XuLy"].ToString() : null,
                TrangThai = row["TrangThai"].ToString(),
                MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null
            };
        }
    }
}