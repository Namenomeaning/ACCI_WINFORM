using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class ChungChiBUS
    {
        private ChungChiDAO chungChiDAO = new ChungChiDAO();

        public bool ThemChungChi(ChungChi chungChi)
        {
            // Validation: SoHieu unique? MaPhieuDK/ThuTu exists and has KetQua='Dat'? NgayCap <= Today?
            // Set initial state?
            chungChi.TrangThaiNhan = "ChuaNhan"; // Example initial state
            return chungChiDAO.ThemChungChi(chungChi) > 0;
        }

        public ChungChi LayChungChi(string soHieu)
        {
            DataTable dt = chungChiDAO.LayChungChi(soHieu);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToChungChi(dt.Rows[0]);
        }

        public ChungChi LayChungChi(string maPhieuDK, int thuTu)
        {
            DataTable dt = chungChiDAO.LayChungChi(maPhieuDK, thuTu);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            // Return full ChungChi object based on the DAO method now returning all columns
            return MapDataRowToChungChi(dt.Rows[0]);

            // If you strictly need just the columns from the original LayChungChi(maPhieuDK, thuTu) method:
            /*
            DataRow row = dt.Rows[0];
            return new ChungChi // Create a partial or specific DTO if needed
            {
                SoHieu = row["SoHieu"].ToString(),
                NgayCap = Convert.ToDateTime(row["NgayCap"]),
                NgayNhan = row["NgayNhan"] != DBNull.Value ? Convert.ToDateTime(row["NgayNhan"]) : (DateTime?)null,
                TrangThaiNhan = row["TrangThaiNhan"].ToString(),
                // Add other required fields if necessary
                MaPhieuDK = maPhieuDK, // Populate known values
                ThuTu = thuTu
            };
            */
        }

        public List<ChungChi> LayDSChungChi()
        {
            DataTable dt = chungChiDAO.LayDSChungChi();
            var chungChiList = new List<ChungChi>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    chungChiList.Add(MapDataRowToChungChi(row));
                }
            }
            return chungChiList;
        }

        public bool CapNhatChungChi(ChungChi chungChi)
        {
            // Add validation
            return chungChiDAO.CapNhatChungChi(chungChi) > 0;
        }

        public bool XoaChungChi(string soHieu)
        {
            // No specific business logic mentioned
            return chungChiDAO.XoaChungChi(soHieu) > 0;
        }

        // Pass necessary parameters, including calculated/determined ones
        public bool CapNhatTrangThaiNhanTaiQuay(string soHieu, string maNhanVien)
        {
            string trangThaiNhan = "DaNhan";
            DateTime ngayNhan = DateTime.Now;
            string phuongThuc = "TaiTT"; // Hardcoded as in original
            string diaChi = "123 Lê Lợi"; // Hardcoded as in original

            // Validation: Check if SoHieu exists, MaNhanVien exists
            var chungChi = LayChungChi(soHieu);
            if (chungChi == null || chungChi.TrangThaiNhan == "DaNhan")
            {
                return false; // Not found or already received
            }

            try
            {
                int result = chungChiDAO.CapNhatTrangThaiNhan(soHieu, trangThaiNhan, ngayNhan, maNhanVien, phuongThuc, diaChi);
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log error (consider a proper logging framework)
                System.Diagnostics.Debug.WriteLine($"Error in CapNhatTrangThaiNhanTaiQuay BUS: {ex.Message}");
                return false;
            }
        }

        // Add other methods like CapNhatTrangThaiNhanQuaBuuDien if needed


        // Helper method to map DataRow to ChungChi object
        private ChungChi MapDataRowToChungChi(DataRow row)
        {
            return new ChungChi
            {
                SoHieu = row["SoHieu"].ToString(),
                MaPhieuDK = row["MaPhieuDK"].ToString(),
                ThuTu = Convert.ToInt32(row["ThuTu"]),
                MaThiSinh = row["MaThiSinh"].ToString(),
                NgayCap = Convert.ToDateTime(row["NgayCap"]),
                NgayHetHan = row["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(row["NgayHetHan"]) : (DateTime?)null,
                PhuongThucNhan = row["PhuongThucNhan"].ToString(),
                DiaChiNhan = row["DiaChiNhan"] != DBNull.Value ? row["DiaChiNhan"].ToString() : null,
                NgayNhan = row["NgayNhan"] != DBNull.Value ? Convert.ToDateTime(row["NgayNhan"]) : (DateTime?)null,
                TrangThaiNhan = row["TrangThaiNhan"].ToString(),
                MaNV_CapNhat = row["MaNV_CapNhat"] != DBNull.Value ? row["MaNV_CapNhat"].ToString() : null // Handle potential null
            };
        }
    }
}