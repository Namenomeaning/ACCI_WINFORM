using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System; // For Convert
using System.Collections.Generic;
using System.Data;

namespace ACCI_WINFORM.BUS
{
    public class PhongThiBUS
    {
        private PhongThiDAO phongThiDAO = new PhongThiDAO();

        public bool ThemPhongThi(PhongThi phongThi)
        {
            // Validation: TenPhong not empty? SucChua > 0?
            if (string.IsNullOrWhiteSpace(phongThi.TenPhong) || phongThi.SucChua <= 0)
            {
                return false; // Basic validation
            }
            return phongThiDAO.ThemPhongThi(phongThi) > 0;
        }

        public PhongThi LayPhongThi(string maPhongThi)
        {
            DataTable dt = phongThiDAO.LayPhongThi(maPhongThi);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToPhongThi(dt.Rows[0]);
        }

        public List<PhongThi> LayDSPhongThi()
        {
            DataTable dt = phongThiDAO.LayDSPhongThi();
            var phongThiList = new List<PhongThi>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    phongThiList.Add(MapDataRowToPhongThi(row));
                }
            }
            return phongThiList;
        }

        public bool CapNhatPhongThi(PhongThi phongThi)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(phongThi.MaPhongThi) || string.IsNullOrWhiteSpace(phongThi.TenPhong) || phongThi.SucChua <= 0)
            {
                return false;
            }
            return phongThiDAO.CapNhatPhongThi(phongThi) > 0;
        }

        public bool XoaPhongThi(string maPhongThi)
        {
            // Business Logic: Check if room is scheduled for any upcoming exams
            // LichThiBUS lichThiBus = new LichThiBUS(); // Dependency
            // var futureExams = lichThiBus.LayDSLichThi().Where(lt => lt.MaPhongThi == maPhongThi && lt.NgayThi >= DateTime.Today).ToList();
            // if (futureExams.Count > 0) { return false; /* Cannot delete */ }

            return phongThiDAO.XoaPhongThi(maPhongThi) > 0;
        }

        // Helper method to map DataRow to PhongThi object
        private PhongThi MapDataRowToPhongThi(DataRow row)
        {
            return new PhongThi
            {
                MaPhongThi = row["MaPhongThi"].ToString(),
                TenPhong = row["TenPhong"].ToString(),
                SucChua = Convert.ToInt32(row["SucChua"])
            };
        }
    }
}