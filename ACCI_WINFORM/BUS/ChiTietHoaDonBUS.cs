using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System; // For Convert, DBNull
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class ChiTietHoaDonBUS
    {
        private ChiTietHoaDonDAO chiTietHoaDonDAO = new ChiTietHoaDonDAO();

        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            // Business logic: Calculate ThanhTien
            chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.DonGia;

            // Validation: MaHoaDon exists? MaDanhGia OR MaPhiGiaHan exists? SoLuong > 0?
            if (string.IsNullOrWhiteSpace(chiTiet.MaHoaDon) ||
                (string.IsNullOrWhiteSpace(chiTiet.MaDanhGia) && string.IsNullOrWhiteSpace(chiTiet.MaPhiGiaHan)) ||
                chiTiet.SoLuong <= 0 || chiTiet.DonGia < 0)
            {
                return false;
            }

            return chiTietHoaDonDAO.ThemChiTietHoaDon(chiTiet) > 0;
        }

        public ChiTietHoaDon LayChiTietHoaDon(string maChiTietHoaDon)
        {
            DataTable dt = chiTietHoaDonDAO.LayChiTietHoaDon(maChiTietHoaDon);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToChiTiet(dt.Rows[0]);
        }

        public List<ChiTietHoaDon> LayDSChiTietHoaDon(string maHoaDon)
        {
            DataTable dt = chiTietHoaDonDAO.LayDSChiTietHoaDon(maHoaDon);
            var chiTietList = new List<ChiTietHoaDon>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    chiTietList.Add(MapDataRowToChiTiet(row));
                }
            }
            return chiTietList;
        }

        public bool CapNhatChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            // Recalculate ThanhTien on update
            chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.DonGia;
            // Add validation similar to ThemChiTietHoaDon
            if (string.IsNullOrWhiteSpace(chiTiet.MaChiTietHoaDon))
            {
                return false;
            }

            return chiTietHoaDonDAO.CapNhatChiTietHoaDon(chiTiet) > 0;
        }

        public bool XoaChiTietHoaDon(string maChiTietHoaDon)
        {
            // No specific business logic mentioned, directly call DAO
            return chiTietHoaDonDAO.XoaChiTietHoaDon(maChiTietHoaDon) > 0;
        }

        // Method to delete all details for a given invoice ID
        public bool XoaChiTietTheoMaHoaDon(string maHoaDon)
        {
            // Potentially add checks before mass deletion
            return chiTietHoaDonDAO.XoaChiTietHoaDonTheoMaHD(maHoaDon) > 0;
        }


        // Helper method to map DataRow to ChiTietHoaDon object
        private ChiTietHoaDon MapDataRowToChiTiet(DataRow row)
        {
            return new ChiTietHoaDon
            {
                MaChiTietHoaDon = row["MaChiTietHoaDon"].ToString(),
                MaHoaDon = row["MaHoaDon"].ToString(),
                MaDanhGia = row["MaDanhGia"] != DBNull.Value ? row["MaDanhGia"].ToString() : null,
                MaPhiGiaHan = row["MaPhiGiaHan"] != DBNull.Value ? row["MaPhiGiaHan"].ToString() : null,
                SoLuong = Convert.ToInt32(row["SoLuong"]),
                DonGia = Convert.ToDecimal(row["DonGia"]),
                ThanhTien = Convert.ToDecimal(row["ThanhTien"])
            };
        }
    }
}