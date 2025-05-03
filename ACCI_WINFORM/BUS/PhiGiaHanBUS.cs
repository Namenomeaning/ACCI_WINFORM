using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System; // For Convert
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class PhiGiaHanBUS
    {
        private PhiGiaHanDAO phiGiaHanDAO = new PhiGiaHanDAO();

        public bool ThemPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            // Validation: TenLoaiPhi not empty? DonGia >= 0?
            if (string.IsNullOrWhiteSpace(phiGiaHan.TenLoaiPhi) || phiGiaHan.DonGia < 0)
            {
                return false;
            }
            return phiGiaHanDAO.ThemPhiGiaHan(phiGiaHan) > 0;
        }

        public PhiGiaHan LayPhiGiaHan(string maPhiGiaHan)
        {
            DataTable dt = phiGiaHanDAO.LayPhiGiaHan(maPhiGiaHan);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToPhiGiaHan(dt.Rows[0]);
        }

        public List<PhiGiaHan> LayDSPhiGiaHan()
        {
            DataTable dt = phiGiaHanDAO.LayDSPhiGiaHan();
            var phiGiaHanList = new List<PhiGiaHan>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    phiGiaHanList.Add(MapDataRowToPhiGiaHan(row));
                }
            }
            return phiGiaHanList;
        }

        public bool CapNhatPhiGiaHan(PhiGiaHan phiGiaHan)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(phiGiaHan.MaPhiGiaHan) || string.IsNullOrWhiteSpace(phiGiaHan.TenLoaiPhi) || phiGiaHan.DonGia < 0)
            {
                return false;
            }
            return phiGiaHanDAO.CapNhatPhiGiaHan(phiGiaHan) > 0;
        }

        public bool XoaPhiGiaHan(string maPhiGiaHan)
        {
            // Business logic: Check dependencies (PhieuGiaHan, ChiTietHoaDon)
            // PhieuGiaHanBUS phieuGiaHanBus = new PhieuGiaHanBUS();
            // var linkedPhieu = phieuGiaHanBus.LayDSPhieuGiaHan().Any(p => p.MaPhiGiaHan == maPhiGiaHan);
            // if (linkedPhieu) return false;
            // Similar check for ChiTietHoaDon...

            return phiGiaHanDAO.XoaPhiGiaHan(maPhiGiaHan) > 0;
        }

        // Helper method to map DataRow to PhiGiaHan object
        private PhiGiaHan MapDataRowToPhiGiaHan(DataRow row)
        {
            return new PhiGiaHan
            {
                MaPhiGiaHan = row["MaPhiGiaHan"].ToString(),
                TenLoaiPhi = row["TenLoaiPhi"].ToString(),
                DonGia = Convert.ToDecimal(row["DonGia"])
            };
        }
    }
}