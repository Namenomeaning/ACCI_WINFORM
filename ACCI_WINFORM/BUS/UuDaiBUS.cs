using ACCI_WINFORM.DAO; // Added DAO namespace
using ACCI_WINFORM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // Required for parameter filtering if done here

namespace ACCI_WINFORM.BUS
{
    public class UuDaiBUS
    {
        private UuDaiDAO uuDaiDAO = new UuDaiDAO();

        public bool ThemUuDai(UuDai uuDai)
        {
            // No additional logic added, just call DAO
            return uuDaiDAO.ThemUuDai(uuDai) > 0;
        }

        public UuDai LayUuDai(string maUuDai)
        {
            DataTable dt = uuDaiDAO.LayUuDai(maUuDai);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            return MapDataRowToUuDai(dt.Rows[0]);
        }

        public List<UuDai> LayDSUuDai()
        {
            DataTable dt = uuDaiDAO.LayDSUuDai();
            var uuDaiList = new List<UuDai>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    uuDaiList.Add(MapDataRowToUuDai(row));
                }
            }
            return uuDaiList;
        }

        public bool CapNhatUuDai(UuDai uuDai)
        {
            // No additional logic added
            return uuDaiDAO.CapNhatUuDai(uuDai) > 0;
        }

        public bool XoaUuDai(string maUuDai)
        {
            // No additional logic added
            return uuDaiDAO.XoaUuDai(maUuDai) > 0;
        }

        // Helper method to map DataRow to UuDai object
        private UuDai MapDataRowToUuDai(DataRow row)
        {
            return new UuDai
            {
                MaUuDai = row["MaUuDai"].ToString(),
                TenUuDai = row["TenUuDai"].ToString(),
                Loai = row["Loai"].ToString(),
                GiaTri = Convert.ToDecimal(row["GiaTri"]),
                DieuKien = row["DieuKien"].ToString(),
                NgayBD = Convert.ToDateTime(row["NgayBD"]),
                NgayKT = Convert.ToDateTime(row["NgayKT"]),
                TrangThai = row["TrangThai"].ToString()
            };
        }
    }
}