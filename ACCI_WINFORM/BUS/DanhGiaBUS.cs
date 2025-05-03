using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class DanhGiaBUS
    {
        private DanhGiaDAO danhGiaDAO = new DanhGiaDAO();

        public bool ThemDanhGia(DanhGia danhGia)
        {
            // Validation: TenDanhGia not empty? DonGia >= 0?
            if (string.IsNullOrWhiteSpace(danhGia.TenDanhGia) || danhGia.DonGia < 0)
            {
                // Handle validation failure (e.g., throw exception or return false)
                return false;
            }
            return danhGiaDAO.ThemDanhGia(danhGia) > 0;
        }

        public DanhGia LayDanhGia(string maDanhGia)
        {
            DataTable dt = danhGiaDAO.LayDanhGia(maDanhGia);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToDanhGia(dt.Rows[0]);
        }

        public List<DanhGia> LayDSDanhGia()
        {
            DataTable dt = danhGiaDAO.LayDSDanhGia();
            var danhGiaList = new List<DanhGia>();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    danhGiaList.Add(MapDataRowToDanhGia(row));
                }
            }
            return danhGiaList;
        }

        public bool CapNhatDanhGia(DanhGia danhGia)
        {
            // Validation: TenDanhGia not empty? DonGia >= 0?
            if (string.IsNullOrWhiteSpace(danhGia.TenDanhGia) || danhGia.DonGia < 0)
            {
                return false;
            }
            return danhGiaDAO.CapNhatDanhGia(danhGia) > 0;
        }

        public bool XoaDanhGia(string maDanhGia)
        {
            // Business logic: Check if this DanhGia is used in any LichThi?
            // Example (requires LichThiBUS dependency):
            // LichThiBUS lichThiBUS = new LichThiBUS();
            // if (lichThiBUS.LayDSLichThiTheoDanhGia(maDanhGia).Count > 0) {
            //     // Cannot delete, show error or return false
            //     return false;
            // }
            return danhGiaDAO.XoaDanhGia(maDanhGia) > 0;
        }

        private DanhGia MapDataRowToDanhGia(DataRow row)
        {
            return new DanhGia
            {
                MaDanhGia = row["MaDanhGia"].ToString(),
                TenDanhGia = row["TenDanhGia"].ToString(),
                MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                DonGia = Convert.ToDecimal(row["DonGia"])
            };
        }
    }
}